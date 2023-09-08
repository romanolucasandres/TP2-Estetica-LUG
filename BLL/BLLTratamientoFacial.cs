using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLTratamientoFacial : BLLTratamiento
    {
        #region IMPLEMENTACION METODO ABSTRACTO

        /// <summary>
        /// Calculo el descuento de 10% si supero los 3000
        /// </summary>
        public override decimal CalculaDescuento(decimal Total)
        {
            if (Total > 3000)
            {
                return Total - (Total * 0.1m); 
            }
            else
            {
                return Total;
            }
        }

        #endregion
    }
}
