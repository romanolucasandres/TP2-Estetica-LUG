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
using System.Windows.Forms.DataVisualization.Charting;

namespace Presentacion
{
    public partial class Chart : Form
    {
        BETratamiento trat;
        BLLTratamiento blltrat;
        
        public Chart()
        {
            InitializeComponent();
            trat=new BETratamientoCorporal();
            trat=new BETratamientoFacial();
            
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            try
            {
                // busco la lista y la paso al diccionario
                blltrat = new BLLTratamientoFacial();
                blltrat = new BLLTratamientoCorporal();
                List<BETratamiento> lista = blltrat.Listar();

                if (lista != null)
                {
                    Dictionary<string, decimal> diccionario = new Dictionary<string, decimal>();

                    foreach (BETratamiento _trat in lista)
                    {
                        diccionario.Add(_trat.Nombre, _trat.Costo);
                    }

                    chart1.Titles.Clear();
                    chart1.Series.Clear();

                    chart1.Titles.Add("Tratamientos de costo mas altos");

                    Series serie = new Series("Costo");
                    serie.ChartType = SeriesChartType.Column;
                    serie.Points.DataBindXY(diccionario.Keys, diccionario.Values);
                    chart1.Series.Add(serie);
                }
                else
                    throw new Exception("No se encontraron empleados en el sistema.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
