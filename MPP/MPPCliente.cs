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
using DAL;

namespace MPP
{
    public class MPPCliente
    {
        //declaro objeto para acceso a datos
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;
        ArrayList oarray;

        public MPPCliente()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
            oarray = new ArrayList();
        }
        #region ABM
        public void Alta(BECliente x)
        {
            Hashtable Alta = new Hashtable();

            Alta.Add("DNI", x.DNI);
            Alta.Add("Nom", x.Nombre);
            Alta.Add("Ape", x.Apellido);
            Alta.Add("Tel", x.Telefono);
            Alta.Add("Email", x.Email);
            Alta.Add("FN", x.FechaNac);
            Alta.Add("Edad", x.Edad);
            Alta.Add("NC", x.NroCliente);
            Alta.Add("dir", x.Direccion);
           

            oAccesoDatos.Escribir("SP_Clientes_Alta", Alta);
            
        }
       
        public void Baja(BECliente x)
        {
            if (ExisteClienteAsociado(x) == false)
            {
                Hashtable Borrar = new Hashtable();
                Borrar.Add("@Id", x.Id);
                oAccesoDatos.Escribir("SP_Cliente_Baja", Borrar);
               
            }
            else
            {
                throw new Exception("El Cliente se encuentra en un turno");
            }

        }
        private bool ExisteClienteAsociado(BECliente oBEcliente)
        {
            try
            {
                //Busco en la BD el mail y password
                Hashtable User = new Hashtable();

                User.Add("id", oBEcliente.Id);
                
                return oAccesoDatos.LeerScalar("SP_Cliente_Asociado", User);


            }
            catch (Exception ex) { throw ex; }

        }


        public void Modifcacion(BECliente x)
        {
            Hashtable Modificar = new Hashtable();

            Modificar.Add("DNI", x.DNI);
            Modificar.Add("Nom", x.Nombre);
            Modificar.Add("Ape", x.Apellido);
            Modificar.Add("Tel", x.Telefono);
            Modificar.Add("Email", x.Email);
            Modificar.Add("FN", x.FechaNac);
            Modificar.Add("Edad", x.Edad);
            Modificar.Add("NC", x.NroCliente);
            Modificar.Add("dir", x.Direccion);


            oAccesoDatos.Escribir("SP_Cliente_Modificar", Modificar);
        }

        #endregion

        #region METODOS
        public List<BECliente> Listar()
        {
            try
            {
                //Me traigo toda la tabla de Administrativos de la Bd
                DataTable Tabla = oAccesoDatos.RetornaTabla("SP_Clientes_Listar", null);
                //declaro una lista de Clientes
                List<BECliente> lst = new List<BECliente>();    

                foreach (DataRow dr in Tabla.Rows)
                {
                    BECliente bECliente = new BECliente();
                    bECliente.Id = Convert.ToInt32(dr["Id"].ToString());
                    bECliente.DNI = dr["DNI"].ToString();
                    bECliente.Nombre = dr["Nombre"].ToString();
                    bECliente.Apellido = dr["Apellido"].ToString();
                    bECliente.Telefono = dr["Telefono"].ToString();
                    bECliente.Email = dr["Email"].ToString();
                    bECliente.FechaNac = Convert.ToDateTime(dr["FechaNac"]);
                    bECliente.Edad = Convert.ToInt32(dr["Edad"].ToString());
                    bECliente.NroCliente = Convert.ToInt32(dr["NroCliente"].ToString());
                    bECliente.Direccion = dr["Direccion"].ToString();
                    bECliente.Turnos = ListarTodoRM(bECliente);
                    //agrego a la lista
                    lst.Add(bECliente);
                }
                //retorno lista
                return lst;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
        public List<BETurno> ListarTodoRM(BECliente cli)
            {
            try
            {
                AccesoDatos oDatos2 = new AccesoDatos();
                Hashtable Hdatos = new Hashtable();
                Hdatos.Add("@cli", cli.Id);              
                           
                DataTable Tabla = oAccesoDatos.RetornaTabla("SP_Listar_Turno_Cli", Hdatos);
                List<BETurno> Lista_Turnos = new List<BETurno>();
               
                   
                foreach(DataRow x in Tabla.Rows)
                {
                    BETurno oTurno = new BETurno();
                    BECliente bECliente = new BECliente();
                    bECliente.Apellido = x["Cliente"].ToString();
                    oTurno.Cliente = bECliente;
                    BEProfesional bEProfesional = new BEProfesional();
                    bEProfesional.Apellido= x["Profesional"].ToString();
                    oTurno.Profesional= bEProfesional;
                    oTurno.Fecha = Convert.ToDateTime(x["Fecha"].ToString());
                    oTurno.Hora = x["Hora"].ToString();
                    oTurno.Consultorio = x["Consultorio"].ToString();
                    oTurno.Total = Convert.ToInt32(x["Total"].ToString());
                    BETratamiento tratamiento;
                    tratamiento = new BETratamientoCorporal();
                    tratamiento.Nombre= x["Tratamiento"].ToString();
                    oTurno.Tratamiento=tratamiento;

                    Lista_Turnos.Add(oTurno);
                }

                return Lista_Turnos;              
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
       

        

    }
    #endregion
}
