using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DAL;

namespace MPP
{
    public class MPPTurno : IAccion<BETurno>
    {
        //declaro objeto para acceso a datos
        DAL.AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;

        public MPPTurno()
        {
            //instancio el acceso
            oAccesoDatos = new DAL.AccesoDatos();
        }

        public void Alta(BETurno T)
        {
           
            Hashtable Alta = new Hashtable();

            Alta.Add("@Cliente", T.Cliente.Id);
            Alta.Add("@Profesional", T.Profesional.Id);
            Alta.Add("@Fecha", T.Fecha);
            Alta.Add("@Hora", T.Hora);
            Alta.Add("@Consultorio", T.Consultorio);
            Alta.Add("@Total", T.Total);
            Alta.Add("@Tratamiento", T.Tratamiento.Id);
        

            oAccesoDatos.Escribir("SP_Turno_Alta", Alta);
            
        }

        public void Baja(BETurno T)
        {
            Hashtable Baja = new Hashtable();
            Baja.Add("@Id", T.Id);
            oAccesoDatos.Escribir("SP_Turno_Baja", Baja);
        }

       

        public void Modifcacion(BETurno T)
        {
            Hashtable Modificacion = new Hashtable();

            Modificacion.Add("@Cli", T.Cliente.Id);
            Modificacion.Add("@Pro", T.Profesional.Id);
            Modificacion.Add("@Fecha", T.Fecha);
            Modificacion.Add("@Hora", T.Hora);
            Modificacion.Add("@Consul", T.Consultorio);
            Modificacion.Add("@Total", T.Total);
            Modificacion.Add("@Trat", T.Tratamiento.Id);
            Modificacion.Add("@Id", T.Id);


            oAccesoDatos.Escribir("SP_Turno_Modificar", Modificacion);
        }

        public List<BETurno> Listar()
        {
            List<BETurno> listaTurnos = new List<BETurno>();

            DataTable dt = oAccesoDatos.RetornaTabla("SP_Turnos_Listar", null);


            foreach (DataRow x in dt.Rows)
            {
                BETurno oTurno = new BETurno();
                oTurno.Id = Convert.ToInt32(x["Id"]);
                BECliente cliente = new BECliente(x["Cliente"].ToString());
                oTurno.Cliente = cliente;
                BEProfesional prof = new BEProfesional(x["Profesional"].ToString());
                oTurno.Profesional = prof;
                oTurno.Fecha = Convert.ToDateTime(x["Fecha"].ToString());
                oTurno.Hora = x["Hora"].ToString();
                oTurno.Consultorio = x["Consultorio"].ToString();
                oTurno.Total = Convert.ToInt32(x["Total"].ToString());

                string tipoTratamiento = x["Tipo"].ToString();
                string nombreTratamiento = x["Tratamiento"].ToString();
                BETratamiento tratamiento;

                if (tipoTratamiento == "Facial")
                {
                    tratamiento = new BETratamientoFacial(nombreTratamiento);
                    oTurno.Tratamiento = tratamiento;
                }
                else if (tipoTratamiento == "Corporal")
                {
                    tratamiento = new BETratamientoCorporal(nombreTratamiento);
                    oTurno.Tratamiento = tratamiento;
                }
                else
                {
                    continue;
                }




                listaTurnos.Add(oTurno);


            }

            return listaTurnos;

        }

        public List<BETurno> Listar2(BECliente cli,BETratamiento trat)
        {
            try
            {
                AccesoDatos oDatos2 = new AccesoDatos();
                Hashtable Hdatos = new Hashtable();
                Hdatos.Add("@cli", cli.Id);
                Hdatos.Add("@trat", trat.Id);

                DataTable Tabla = oAccesoDatos.RetornaTabla("SP_Turnos_Listar_Id_Cliente", Hdatos);
                List<BETurno> Lista_Turnos = new List<BETurno>();


                foreach (DataRow x in Tabla.Rows)
                {
                    BETurno oTurno = new BETurno();
                    BECliente bECliente = new BECliente();
                    bECliente.Apellido = x["Cliente"].ToString();
                    oTurno.Cliente = bECliente;
                    BEProfesional bEProfesional = new BEProfesional();
                    bEProfesional.Apellido = x["Profesional"].ToString();
                    oTurno.Profesional = bEProfesional;
                    oTurno.Fecha = Convert.ToDateTime(x["Fecha"].ToString());
                    oTurno.Hora = x["Hora"].ToString();
                    oTurno.Consultorio = x["Consultorio"].ToString();
                    oTurno.Total = Convert.ToInt32(x["Total"].ToString());
                    BETratamiento tratamiento;
                    tratamiento = new BETratamientoCorporal();
                    tratamiento.Nombre = x["Tratamiento"].ToString();
                    oTurno.Tratamiento = tratamiento;

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
}
