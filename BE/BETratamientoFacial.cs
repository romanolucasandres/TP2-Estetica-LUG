using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BETratamientoFacial:BETratamiento
    {
        #region Constructores
        public BETratamientoFacial()
        {

        }
        //Constructor sobrecargado
        public BETratamientoFacial(int codigo, string nombre, decimal costo,string tipo)
        {
            Id = codigo;
            Nombre = nombre;
            Costo = costo;
            Tipo = tipo;
        }
        public BETratamientoFacial(string nombre, String tipo)
        {

            Nombre = nombre;

            Tipo = tipo;
        } 
        public BETratamientoFacial(string nombre)
        {

            Nombre = nombre;

        }
        #endregion

        public override string ToString()
        {
            return Nombre;
        }
    }
}
