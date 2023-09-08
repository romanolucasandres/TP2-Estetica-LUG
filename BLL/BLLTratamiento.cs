using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class BLLTratamiento 
    {
        //declaro objeto mapper
        MPPTratamiento mppTratamiento;
        public BLLTratamiento()
        {
            //instancio
            mppTratamiento = new MPPTratamiento();
        }
        public void Alta(BETratamiento x)
        {
            mppTratamiento.Alta(x);
        }

        public void Baja(BETratamiento x)
        {
            mppTratamiento.Baja(x);
        }

        public List<BETratamiento> Listar()
        {
            List<BETratamiento>Lista=new List<BETratamiento>();
            Lista = mppTratamiento.Listar();
            return Lista;
        }  
        public List<BETratamiento> Listar2()
        {
            List<BETratamiento>Lista=new List<BETratamiento>();
            Lista = mppTratamiento.Listar2();
            return Lista;
        }    
          

        public void Modifcacion(BETratamiento x)
        {
            mppTratamiento.Modificacion(x);
        }

        #region METODO ABSTRACTO

        /// <summary>
        /// Metodo abstracto para calcular el descuento según el tipo de tratamiento
        /// a ser implementado en las clases derivadas
        /// </summary>
        public abstract decimal CalculaDescuento(decimal Total);

        #endregion
    }
}
