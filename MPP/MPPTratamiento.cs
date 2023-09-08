using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MPP
{
    public class MPPTratamiento
    {
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;

        public MPPTratamiento()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
        }

        #region METODOS DE CONSULTA      

     
        // Lista los Tratamientos de la BD segun criterio utilizado.
       
        public List<BETratamiento> Listar()
        {
           
            query = "SP_Tratamientos_Listar";
         
            DataTable Tabla = oAccesoDatos.RetornaTabla(query, null);
            List<BETratamiento> ListaTratamientos = new List<BETratamiento>();
            foreach (DataRow fila in Tabla.Rows)
            {
                //veo que tipo de tratamiento
                string Tipo = fila["Tipo"].ToString();
                if (Tipo == "Facial")
                {
                    BETratamientoFacial TF = new BETratamientoFacial();
                    TF.Id = int.Parse(fila["Id"].ToString());
                    TF.Nombre = fila["Nombre"].ToString();
                    TF.Costo = decimal.Parse(fila["Costo"].ToString());
                    TF.Tipo =(fila["Tipo"].ToString());

                    ListaTratamientos.Add(TF);
                }
                else
                {
                    BETratamientoCorporal TC = new BETratamientoCorporal();
                    TC.Id = int.Parse(fila["Id"].ToString());
                    TC.Nombre = fila["Nombre"].ToString();
                    TC.Costo = decimal.Parse(fila["Costo"].ToString());
                    TC.Tipo = (fila["Tipo"].ToString());

                    ListaTratamientos.Add(TC);
                }
            }
            return ListaTratamientos;
        }

        public List<BETratamiento> Listar2()
        {

            query = "SP_Tratamientos_Listar_Nombres";

            DataTable Tabla = oAccesoDatos.RetornaTabla(query, null);
            List<BETratamiento> ListaTratamientos = new List<BETratamiento>();
            foreach (DataRow fila in Tabla.Rows)
            {
                //veo que tipo de tratamiento
                string Tipo = fila["Tipo"].ToString();
                if (Tipo == "Facial")
                {
                    BETratamientoFacial TF = new BETratamientoFacial();
                    
                    TF.Nombre = fila["Nombre"].ToString();

                    ListaTratamientos.Add(TF);
                }
                else
                {
                    BETratamientoCorporal TC = new BETratamientoCorporal();
                    
                    TC.Nombre = fila["Nombre"].ToString();
                 

                    ListaTratamientos.Add(TC);
                }
            }
            return ListaTratamientos;
        }

        #endregion

        #region METODOS ABM

        public void Alta(BETratamiento T)
        {
            //Reemplazo "," por "." 
            string Costo = T.Costo.ToString().Replace(',', '.');

            Hashtable Alta = new Hashtable();

            Alta.Add("@Nom", T.Nombre);
            Alta.Add("@Costo", T.Costo);
           


            if (T is BETratamientoFacial)
            {  //Instancio Tratamiento Facial
                BETratamientoFacial TT = new BETratamientoFacial();
                TT = (BETratamientoFacial)T;
                Alta.Add("@Tipo", T.Tipo);
            }
            else
            {
                //Instancio Tratamiento Corporal
                BETratamientoCorporal TC = new BETratamientoCorporal();
                TC = (BETratamientoCorporal)T;
                Alta.Add("@Tipo", T.Tipo);
                
            }

            oAccesoDatos.Escribir("SP_Tratamiento_Alta", Alta);

        }


        public void Modificacion(BETratamiento T)
        {
            //Reemplazo "," por "." 
            string Costo = T.Costo.ToString().Replace(',', '.');

            Hashtable Modificacion = new Hashtable();

            Modificacion.Add("@Nombre", T.Nombre);
            Modificacion.Add("@Costo", T.Costo);

            if (T is BETratamientoFacial)
            {  //Instancio Tratamiento Facial
                BETratamientoFacial TT = new BETratamientoFacial();
                TT = (BETratamientoFacial)T;
                Modificacion.Add("@Tipo", T.Tipo);
            }
            else
            {
                if (T is BETratamientoCorporal)
                {  //Instancio Tratamiento Corporal
                    BETratamientoCorporal TC = new BETratamientoCorporal();
                    TC = (BETratamientoCorporal)T;
                    Modificacion.Add("@Tipo", T.Tipo);
                }
            }
            oAccesoDatos.Escribir("SP_Tratamiento_Modificacion", Modificacion);
        }


        public void Baja(BETratamiento T)
        {
            if(TratamientoAsociado(T) == false)
            {
                Hashtable Borrar = new Hashtable();
                Borrar.Add("@Id", T.Id);
                oAccesoDatos.Escribir("SP_Tratamiento_Borrar", Borrar);
            }         
        }
        private bool TratamientoAsociado(BETratamiento T)
        {
            Hashtable Turno = new Hashtable();
            Turno.Add("@Id", T.Id);
            return oAccesoDatos.LeerScalar("SP_Turno_X_Id_Turno", Turno);
        }
        #endregion
    }
}
