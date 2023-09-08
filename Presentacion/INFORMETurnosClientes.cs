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

namespace Presentacion
{
    public partial class INFORMETurnosClientes : Form
    {
        BLLCliente _BLLcliente;
        BECliente _BECliente;
        BETurno _BEturno;
        BLLTurno _BLLturno;
        BETratamiento _BETratamiento;

        public INFORMETurnosClientes()
        {
            InitializeComponent();
            _BLLcliente = new BLLCliente();
            _BECliente = new BECliente();
            _BLLturno = new BLLTurno();
        }

        private void TurnosClientes_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        
       public void Mostrar()
        {
            comboBoxCliente.DataSource = _BLLcliente.Listar();
            comboBoxCliente.DisplayMember = "NroCliente";
            comboBoxCliente.Text = "Selecciona cliente";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _BECliente = (BECliente)comboBoxCliente.SelectedItem;
            _BETratamiento = new BETratamientoCorporal();
            dataInforme.DataSource = null;
            dataInforme.DataSource = _BLLturno.Listar2(_BECliente, _BETratamiento);
            this.dataInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void Click(object sender, MouseEventArgs e)
        {
           
        }

        private void dobleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void doble(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
