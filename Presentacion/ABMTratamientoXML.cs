using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.IO;
using BE.REGEX;

namespace Presentacion
{
    public partial class ABMTratamientoXML : Form
    {
        BETratamiento T;
        public ABMTratamientoXML()
        {
            InitializeComponent();
        }

        private void ABMTratamientoXML_Load(object sender, EventArgs e)
        {
            ModoSeleccion();
            comboBoxTratamiento.DataSource = Enum.GetValues(typeof(Tipos));
            comboBoxTratamiento.SelectedIndex = 0;
            comboBoxTratamiento.Text = "Selecciona";
            Mostrar();
        }
        private void AltaXML()
        {
            try
            {
                if (ExpresionesRegulares.ValidarSoloNumeros(textBox1.Text) == false)
                {
                    throw new Exception("El DNI solo debe contener números");
                }
                XDocument XMLEstetica = XDocument.Load("Tratamientos.xml");

                XMLEstetica.Element("Tratamientos").Add(new XElement("tratamientos",
                                                new XAttribute("id", textBox1.Text.Trim()),
                                                new XElement("nombre", textBox2.Text.Trim()),
                                                new XElement("costo", textBox3.Text.Trim()),
                                                new XElement("tipo", comboBoxTratamiento.SelectedItem)
                                                ));
                XMLEstetica.Save("Tratamientos.xml");
                Vaciar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void ModificarXML()
        {
            try
            {
                if (textBox1.Text != null)
                {
                    XDocument XMLEstetica = XDocument.Load("Tratamientos.xml");

                    var leer = from tratamientos in XMLEstetica.Descendants("tratamientos")
                               where tratamientos.Attribute("id").Value == textBox1.Text.Trim()
                               select tratamientos;

                    foreach (var item in leer)
                    {
                        item.Element("nombre").Value = textBox2.Text.Trim();
                        item.Element("costo").Value = textBox3.Text.Trim();
                        item.Element("tipo").Value = comboBoxTratamiento.Text;

                    }

                    XMLEstetica.Save("Tratamientos.xml");
                    MessageBox.Show("Modificado", "Aviso");


                }
                else { MessageBox.Show("El id no corresponde", "Aviso"); }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BajaXML()
        {
            try
            {
                if (textBox1.Text != null)
                {
                    XDocument XMLEstetica = XDocument.Load("Tratamientos.xml");

                    var leer = from tratamientos in XMLEstetica.Descendants("tratamientos")
                               where tratamientos.Attribute("id").Value == textBox1.Text.Trim()
                               select tratamientos;

                    leer.Remove();
                    XMLEstetica.Save("Tratamientos.xml");



                }
                else { MessageBox.Show("El id no corresponde", "Aviso"); }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void Mostrar()
        {

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = MostrarXML();
            

        }
        private List<BETratamientoCorporal> MostrarXML()
        {
            string filePath = "Tratamientos.xml";

            if (!File.Exists(filePath))
            {
                // El archivo no existe, crearlo con una estructura inicial
                XDocument newXml = new XDocument(
                    new XElement("tratamientos")
                );
                newXml.Save(filePath);
            }

            var leer = from tratamientos in XElement.Load("Tratamientos.xml").Elements("tratamientos")
                       select new BETratamientoCorporal
                       {
                           Id = Convert.ToInt32(Convert.ToString(tratamientos.Attribute("id").Value).Trim()),
                           Nombre = Convert.ToString(tratamientos.Element("nombre").Value).Trim(),
                           Costo = Convert.ToDecimal(Convert.ToString(tratamientos.Element("costo").Value)),
                           Tipo = Convert.ToString(tratamientos.Element("tipo").Value).Trim()   

                       };

            List<BETratamientoCorporal> Lista = leer.ToList();
            return Lista;
        }

        private void ModoSeleccion()
        {
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private void CargarDatos()
        {
            


        }

        private void Vaciar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBoxTratamiento = null;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AltaXML();
                Mostrar();
                dataGridView2.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1 != null)
            {
                BajaXML();
                Vaciar();
                Mostrar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1 != null)
            {
                ModificarXML();
                Vaciar();
                Mostrar();
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {


                
                int columnaNombre = 0;
                int columnaCosto = 1;
                int columnaTipo = 2;
                int columnaId = 3;

                int filaIndex = e.RowIndex;

                
                DataGridViewCell celdaNombre = dataGridView2[columnaNombre, filaIndex];
                DataGridViewCell celdaCosto = dataGridView2[columnaCosto, filaIndex];
                DataGridViewCell celdaTipo = dataGridView2[columnaTipo, filaIndex];
                DataGridViewCell celdaId = dataGridView2[columnaId, filaIndex];

                textBox1.Text = celdaId.Value?.ToString();
                textBox2.Text = celdaNombre.Value?.ToString();
                textBox3.Text = celdaCosto.Value?.ToString();
                comboBoxTratamiento.Text = celdaTipo.Value?.ToString();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    
}
