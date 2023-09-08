﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Menu : Form
    {
        ABMCliente cliente;
        ABMAdministrativo administrativo;
        ABMProfesional profesional;
        ABMTratamiento tratamiento;
        ABMTurnos turno;
        INFORMETurnosClientes clientet;
        Chart chart;
        ABMTratamientoXML xml;
        BusquedaXML busqueda;

        public Menu()
        {
            InitializeComponent();
        }

        private void aBMClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (cliente != null)
                cliente.BringToFront();
            else
            {
                cliente = new ABMCliente();
                cliente.FormClosed += (o, args) => cliente = null;
                cliente.MdiParent = this;
                cliente.Show();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Ud. está por salir del programa. Presione Aceptar para confirmar.", "Aviso", MessageBoxButtons.OKCancel);
            if (dialog is DialogResult.OK) 
            { 
                Application.Exit(); 
            }
        }

        private void aBMAdministrativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (administrativo != null)
                administrativo.BringToFront();
            else
            {
                administrativo = new ABMAdministrativo();
                administrativo.FormClosed += (o, args) => administrativo = null;
                administrativo.MdiParent = this;
                administrativo.Show();
            }
            
        }

        private void aBMProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (profesional != null)
                profesional.BringToFront();
            else
            {
                profesional = new ABMProfesional();
                profesional.FormClosed += (o, args) => profesional = null;
                profesional.MdiParent = this;
                profesional.Show();
            }
            
           
        }

        private void aBMTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tratamiento != null)
                tratamiento.BringToFront();
            else
            {
                tratamiento = new ABMTratamiento();
                tratamiento.FormClosed += (o, args) => tratamiento = null;
                tratamiento.MdiParent = this;
                tratamiento.Show();
            }
            
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void turnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (turno != null)
                turno.BringToFront();
            else
            {
                turno = new ABMTurnos();
                turno.FormClosed += (o, args) => turno = null;
                turno.MdiParent = this;
                turno.Show();
            }
        }

        private void listadoDeTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientet != null)
                clientet.BringToFront();
            else
            {
                clientet = new INFORMETurnosClientes();
                clientet.FormClosed += (o, args) => clientet = null;
                clientet.MdiParent = this;
                clientet.Show();
            }
        }

        private void turnosConElPrecioMasAltoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chart != null)
                chart.BringToFront();
            else
            {
                chart = new Chart();
                chart.FormClosed += (o, args) => chart = null;
                chart.MdiParent = this;
                chart.Show();
            }
        }

        private void aBMTratamientoXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (xml != null)
                xml.BringToFront();
            else
            {
                xml = new ABMTratamientoXML();
                xml.FormClosed += (o, args) => xml = null;
                xml.MdiParent = this;
                xml.Show();
            }
        }

        private void buscarPorTipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (busqueda != null)
                busqueda.BringToFront();
            else
            {
                busqueda = new BusquedaXML();
                busqueda.FormClosed += (o, args) => busqueda = null;
                busqueda.MdiParent = this;
                busqueda.Show();
            }
        }
    }
}
