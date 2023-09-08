using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion
{
    public partial class BusquedaXML : Form
    {
        BETratamiento trat;
        public BusquedaXML()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public List<BETratamientoCorporal> Buscar(string criterio)
        {
            // busco la rutina segun el criterio establecido
            var consulta = from tratamientos in XElement.Load("Tratamientos.xml").Elements("tratamientos")
                           where tratamientos.Element("tipo").Value == criterio
                           select new BETratamientoCorporal
                           {
                               Id = Convert.ToInt32(Convert.ToString(tratamientos.Attribute("id").Value).Trim()),
                               Nombre = Convert.ToString(tratamientos.Element("nombre").Value).Trim(),
                               Costo = Convert.ToDecimal(Convert.ToString(tratamientos.Element("costo").Value)),
                               Tipo = Convert.ToString(tratamientos.Element("tipo").Value).Trim()
                           };

            return consulta.ToList<BETratamientoCorporal>();
        }

        public List<BETratamientoFacial> Buscarf(string criterio)
        {
            
            var consulta = from tratamientos in XElement.Load("Tratamientos.xml").Elements("tratamientos")
                           where tratamientos.Element("tipo").Value == criterio
                           select new BETratamientoFacial
                           {
                               Id = Convert.ToInt32(Convert.ToString(tratamientos.Attribute("id").Value).Trim()),
                               Nombre = Convert.ToString(tratamientos.Element("nombre").Value).Trim(),
                               Costo = Convert.ToDecimal(Convert.ToString(tratamientos.Element("costo").Value)),
                               Tipo = Convert.ToString(tratamientos.Element("tipo").Value).Trim()
                           };

            return consulta.ToList<BETratamientoFacial>();
        }

        private void BusquedaXML_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(Tipos));
            comboBox1.SelectedIndex = 0;
            comboBox1.Text = "Selecciona";
        }
        private void Vaciar()
        {
            
            comboBox1 = null;
        }
        private void ModoSeleccion()
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Facial")
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Buscarf(comboBox1.Text);
                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Buscar(comboBox1.Text);
                }
                
                Vaciar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
