using BE.ExcepcionesPersonalizadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BETratamiento:Entidad
    {
        #region CAMPOS
        
        private string _Nombre;
        private decimal _Costo;
        private string _Tipo;

        #endregion
        #region PROPIEDADES
        public string Nombre 
        {
            get { return _Nombre; }
            set
            { _Nombre = value; }
            
        }
        public decimal Costo
        {
            get { return _Costo; }
            set 
            {
                if (value < 0)
                {
                    throw new NegativoExp<decimal>(value);
                }
                _Costo = value; }
        }

        public string Tipo
        {
            get { return _Tipo; }
            set
            { _Tipo = value; }

        }

        #endregion

        #region Constructores
        public BETratamiento()
        {
            
        }
        //Constructor sobrecargado
        public BETratamiento(int codigo, string nombre, decimal costo, string tipo)
        {
            Id = codigo;
            Nombre = nombre;
            Costo = costo;
            Tipo = tipo;
        }

        #endregion 

        public override string ToString()
        {
            return Nombre;
        }





    }
    public enum Tipos
    {
        Facial, Corporal
    };
}
