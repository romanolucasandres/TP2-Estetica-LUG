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
    public class MPPProfesional
    {
        //declaro objeto para acceso a datos
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;

        public MPPProfesional()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
        }
        #region METODOS DE CONSULTA      


        //Listar todos los Profesional
        public List<BEProfesional> Listar()
        {
            //Me traigo toda la tabla de Profesionales de la Bd
            DataTable Tabla = oAccesoDatos.RetornaTabla("SP_Profesional_Listar", null);
            List<BEProfesional> ListaProf = new List<BEProfesional>();
            //Por cada fila en la lista de Profesionales
            foreach (DataRow fila in Tabla.Rows)
            {
                //Instancio un Profesional
                BEProfesional P = new BEProfesional();
                //Cargo datos del Profesional
                P.Id = int.Parse(fila["Id"].ToString());
                P.DNI = fila["DNI"].ToString();
                P.Nombre = fila["Nombre"].ToString();
                P.Apellido = fila["Apellido"].ToString();
                P.Telefono = fila["Telefono"].ToString();
                P.Email = fila["Email"].ToString();
                P.FechaNac = Convert.ToDateTime(fila["FechaNac"]);
                P.Edad = int.Parse(fila["Edad"].ToString());
                P.Titulo = fila["Titulo"].ToString();
                ListaProf.Add(P);
            }

            return ListaProf;
        }
        // listo un Profesional 

        public BEProfesional ListarAdmin(string pP)
        {
            Hashtable User = new Hashtable();
            User.Add("@Apellido", pP);
            DataTable Tabla = oAccesoDatos.RetornaTabla("SP_Profesional_Listar", User);
            BEProfesional P = new BEProfesional();
            foreach (DataRow fila in Tabla.Rows)
            {
             
                P.DNI = fila["DNI"].ToString();
                P.Nombre = fila["Nombre"].ToString();
                P.Apellido = fila["Apellido"].ToString();
                P.Telefono = fila["Telefono"].ToString();
                P.Email = fila["Email"].ToString();
                P.FechaNac = Convert.ToDateTime(fila["FechaNac"]);
                P.Edad = int.Parse(fila["Edad"].ToString());
                P.Titulo = fila["Titulo"].ToString();
            }
            return P;
        }


        #endregion

        #region METODOS ABM

        public void Alta(BEProfesional P)
        {
            Hashtable Alta = new Hashtable();

            Alta.Add("@DNI", P.DNI);
            Alta.Add("@Nom", P.Nombre);
            Alta.Add("@Ape", P.Apellido);
            Alta.Add("@Tel", P.Telefono);
            Alta.Add("@Email", P.Email);
            Alta.Add("@FN", P.FechaNac);
            Alta.Add("@Edad", P.Edad);
            Alta.Add("@Tit", P.Titulo);

            oAccesoDatos.Escribir("SP_Profesional_Alta", Alta);
        }


        public void Modificacion(BEProfesional P)
        {
            Hashtable Modificacion = new Hashtable();

            Modificacion.Add("@DNI", P.DNI);
            Modificacion.Add("@Nom", P.Nombre);
            Modificacion.Add("@Ape", P.Apellido);
            Modificacion.Add("@Tel", P.Telefono);
            Modificacion.Add("@Email", P.Email);
            Modificacion.Add("@FN", P.FechaNac);
            Modificacion.Add("@Edad", P.Edad);
            Modificacion.Add("@Tit", P.Titulo);

            oAccesoDatos.Escribir("SP_Profesional_Modificar", Modificacion);
        }


        public void Baja(BEProfesional P)
        {
            Hashtable Baja = new Hashtable();
            Baja.Add("@Id", P.Id);
            oAccesoDatos.Escribir("SP_Profesional_Baja", Baja);

        }

        #endregion

    }
}
