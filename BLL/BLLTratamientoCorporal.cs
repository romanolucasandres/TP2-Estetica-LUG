using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLTratamientoCorporal : BLLTratamiento
    {
        #region IMPLEMENTACION DEL METODO ABSTRACTO

        /// <summary>
        /// Calculo el descuento el 20% si supero lo 5000 
        /// </summary>
        public override decimal CalculaDescuento(decimal Total)
        {

            if (Total > 5000)
            {
                return Total -  (Total * 0.2m);
            }
            else
            {
                return Total;
            }
        }

        #endregion
    }
}
