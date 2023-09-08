using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BETratamientoCorporal:BETratamiento
    {
        #region Constructores
        public BETratamientoCorporal()
        {

        }
        //Constructor sobrecargado
        public BETratamientoCorporal(int codigo, string nombre, decimal costo, string tipo)
        {
            Id = codigo;
            Nombre = nombre;
            Costo = costo;
            Tipo = tipo;
        }
        public BETratamientoCorporal(string nombre, String tipo)
        {
          
            Nombre = nombre;
          
            Tipo = tipo;
        }
        public BETratamientoCorporal(string nombre)
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
