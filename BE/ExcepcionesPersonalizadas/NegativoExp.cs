using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.ExcepcionesPersonalizadas
{
    //Excepcion personalizada que recibe un parametro del tipo T, donde T tiene que ser struct. 
    public class NegativoExp<T> : Exception where T : struct
    {

        #region PROPIEDADES

        //Declaro una variable del tipo T
        public T Numero { get; set; }

        #endregion

        #region CONSTRUCTORES

        //Genero un Constructor con un parametro del tipo T 
        public NegativoExp(T pNumero)
        {
            Numero = pNumero;
        }

        #endregion

        #region METODOS

        //sobrecarga de la excepcion. Mostrando el numero que me llega por referencia
        public override string Message => "No se pueden ingresar valores negativos. Usted ingresó: " + Numero;

        #endregion
    }
    }
