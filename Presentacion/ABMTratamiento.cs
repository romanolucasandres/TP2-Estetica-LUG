﻿using BE;
using BE.REGEX;
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

namespace Presentacion
{
    public partial class ABMTratamiento : Form
    {
        BETratamiento _BEtratamiento;
        BLLTratamientoCorporal _BLLtratamiento;
        public ABMTratamiento()
        {
            InitializeComponent();
            _BLLtratamiento= new BLLTratamientoCorporal();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            CargarDatos();
            _BLLtratamiento.Alta(_BEtratamiento);
            Mostrar();
            Vaciar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxTratamiento.SelectedIndex == 0)
                {
                    _BEtratamiento = new BETratamientoFacial();
                    _BEtratamiento.Id = Convert.ToInt32(textBox1.Text); ;
                }
                else
                {
                    _BEtratamiento = new BETratamientoCorporal();
                    _BEtratamiento.Id = Convert.ToInt32(textBox1.Text);
                }
                

                DialogResult resultado = MessageBox.Show("Está por eliminar el tratamiento  " +
                    _BEtratamiento.Nombre + "¿Confirma esta acción?", "Confirmar", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    _BLLtratamiento.Baja(_BEtratamiento);
                    Mostrar();
                    Vaciar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BETratamiento aux = dataGridViewTratamiento.SelectedRows[0].DataBoundItem as BETratamiento;
                _BEtratamiento.Id = aux.Id;
                _BEtratamiento.Nombre = textBox2.Text;
                Vaciar();

                // mando el BEProfesional con las propiedades cargadas a la BLL
                _BLLtratamiento.Modifcacion(_BEtratamiento);

                Mostrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ABMTratamiento_Load(object sender, EventArgs e)
        {
            Mostrar();
            ModoSeleccion();
        }

        private void Dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                BETratamiento aux = dataGridViewTratamiento.SelectedRows[0].DataBoundItem as BETratamiento;
                textBox1.Text = aux.Id.ToString();
                textBox2.Text = aux.Nombre;
                textBox3.Text = aux.Costo.ToString();
                comboBoxTratamiento.Text = aux.Tipo.ToString();
            


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        #region METODOS
        private void Mostrar()
        {
            dataGridViewTratamiento.DataSource = null;
            dataGridViewTratamiento.DataSource = _BLLtratamiento.Listar();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            if (dataGridViewTratamiento.DataSource != null)
            {
                //pongo el id al principio del dgv
                dataGridViewTratamiento.Columns["Id"].DisplayIndex = 0;
                
            }
            comboBoxTratamiento.DataSource = Enum.GetValues(typeof(Tipos));
            comboBoxTratamiento.SelectedIndex = 0;
            comboBoxTratamiento.Text = "Selecciona";

        }


        private void ModoSeleccion()
        {
            dataGridViewTratamiento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTratamiento.MultiSelect = false;
            dataGridViewTratamiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
        private void CargarDatos()
        {
            if(comboBoxTratamiento.SelectedIndex==0) {
                _BEtratamiento = new BETratamientoFacial();
                if (ExpresionesRegulares.ValidarAlfanumérico(textBox3.Text) == false)
                {
                    throw new Exception("El nombre solo debe tener caracteres alfanuméricos");
                }
                _BEtratamiento.Nombre = textBox2.Text;
                _BEtratamiento.Costo = Convert.ToDecimal(textBox3.Text);
                _BEtratamiento.Tipo = comboBoxTratamiento.SelectedItem.ToString();
            }
            else
            {
                _BEtratamiento = new BETratamientoCorporal();
                _BEtratamiento.Nombre = textBox2.Text;
                _BEtratamiento.Costo = Convert.ToDecimal(textBox3.Text);
                _BEtratamiento.Tipo = comboBoxTratamiento.SelectedItem.ToString();
            }
            
            
        }

        private void Vaciar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        #endregion
    }
}
