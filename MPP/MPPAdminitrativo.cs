using Abstraccion;
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPAdminitrativo
    {
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;

        public MPPAdminitrativo()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
        }

        #region METODOS DE CONSULTA      


        //Listar todos los admin
        public List<BEAdministrativo> Listar()
        {
            //Me traigo toda la tabla de Administrativos de la Bd
            DataTable Tabla = oAccesoDatos.RetornaTabla("SP_Administrativos_Listar", null);
            List<BEAdministrativo> ListaAdmin = new List<BEAdministrativo>();
            //Por cada fila en la lista de Administrativos
            foreach (DataRow fila in Tabla.Rows)
            {
                //Instancio un Administrativo
                BEAdministrativo A = new BEAdministrativo();
                //Cargo datos del Administrativo
                A.Id= int.Parse(fila["Id"].ToString());
                A.DNI = fila["DNI"].ToString();
                A.Nombre = fila["Nombre"].ToString();
                A.Apellido = fila["Apellido"].ToString();
                A.Telefono = fila["Telefono"].ToString();
                A.Email = fila["Email"].ToString();
                A.FechaNac = Convert.ToDateTime(fila["FechaNac"]);
                A.Edad = int.Parse(fila["Edad"].ToString());
                A.Tarea= fila["Tarea"].ToString();
                A.Contraseña= fila["Contraseña"].ToString();
                ListaAdmin.Add(A);
            }

            return ListaAdmin;
        }
        //lista a un admin
        public BEAdministrativo ListarAdmin(string pA)
        {
            Hashtable User = new Hashtable();
            User.Add("@Apellido", pA);
            //Traigo la tabla con el administrativo
            DataTable Tabla = oAccesoDatos.RetornaTabla("SP_Un_Administrativo_Listar", User);
            BEAdministrativo A = new BEAdministrativo();
            foreach (DataRow fila in Tabla.Rows)
            {
                //Cargo datos del Administrativo
                A.DNI = fila["DNI"].ToString();
                A.Nombre = fila["Nombre"].ToString();
                A.Apellido = fila["Apellido"].ToString();
                A.Telefono = fila["Telefono"].ToString();
                A.Email = fila["Email"].ToString();
                A.FechaNac = Convert.ToDateTime(fila["FechaNac"]);
                A.Edad = int.Parse(fila["Edad"].ToString());
                A.Tarea = fila["Tarea"].ToString();
                A.Contraseña = fila["Contraseña"].ToString();

            }
            return A;
        }
        
        
        #endregion

        #region METODOS ABM

        public void Alta(BEAdministrativo A)
        {
            
            Hashtable Alta = new Hashtable();

            Alta.Add("DNI", A.DNI);
            Alta.Add("Nom", A.Nombre);
            Alta.Add("Ape", A.Apellido);
            Alta.Add("Tel", A.Telefono);
            Alta.Add("Email", A.Email);
            Alta.Add("FN", A.FechaNac);
            Alta.Add("Edad", A.Edad);
            Alta.Add("Tarea", A.Tarea);
            Alta.Add("Con", A.Contraseña);

            oAccesoDatos.Escribir("SP_Administrativo_Alta", Alta);

        }


        public void Modificacion(BEAdministrativo A)
        {
            Hashtable Alta = new Hashtable();

            Alta.Add("DNI", A.DNI);
            Alta.Add("Nom", A.Nombre);
            Alta.Add("Ape", A.Apellido);
            Alta.Add("Tel", A.Telefono);
            Alta.Add("Email", A.Email);
            Alta.Add("FN", A.FechaNac);
            Alta.Add("Edad", A.Edad);
            Alta.Add("Tarea", A.Tarea);
            Alta.Add("Con", A.Contraseña);

            oAccesoDatos.Escribir("SP_Administrativo_Modificar", Alta);
        }
       

        public void Baja(BEAdministrativo A)
        {           
            Hashtable Borrar = new Hashtable();
            Borrar.Add("@Id", A.Id);
            oAccesoDatos.Escribir("SP_Administrativo_Baja", Borrar);

        }

        #endregion
       
        public bool ExistePassword (BELogin oBELogin)
        {           
            try
            {
                //Busco en la BD el mail y password
                Hashtable User = new Hashtable();
          
                User.Add("cont", oBELogin.Password);
                User.Add("email", oBELogin.Email);
                return oAccesoDatos.LeerScalar("SP_ListarAdminXMail", User);
                    
                
            }
            catch (Exception ex) { throw ex; }      
        }
 
    }
}
