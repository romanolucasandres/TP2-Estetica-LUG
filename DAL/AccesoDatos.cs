using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

using System.Collections;

namespace DAL
{
    public class AccesoDatos
    {


        private SqlConnection conexion;

        private SqlCommand command;
        private SqlTransaction sqltrans;

        public AccesoDatos()
        {
            conexion = new SqlConnection(@"Data Source=LAPTOP-RJIKNK5J\SQLEXPRESS01;Initial Catalog=Estetica;Integrated Security=True");
        }

        
        

        public void Cerrar()
        {
            try
            {
                conexion.Close();
                conexion.Dispose();
                conexion = null;
            }
            catch (SqlException ex)
            {

                throw ex;
            }


        }

      
        

        public bool LeerScalar(string Consulta, Hashtable Hdatos)
        {
            conexion.Open();
            //uso el constructor del objeto Command al instanciar el objeto
            command = new SqlCommand(Consulta, conexion);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                if ((Hdatos != null))
                {
                    //si la hashtable no esta vacia, y tiene el dato q busco 
                    foreach (string dato in Hdatos.Keys)
                    {
                        //cargo los parametros que le estoy pasando con la Hash
                        command.Parameters.AddWithValue(dato, Hdatos[dato]);
                    }
                }

                int Respuesta = Convert.ToInt32(command.ExecuteScalar());
                conexion.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }
        }
        

     


        //Escribir generico con StoreProcedure
        //recibe un string con SP y una lista de parametros en un HashTable
        public void Escribir(string NombreSp, Hashtable pParametros)
        {
            if(conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            
            //creo el objeto transaction
            SqlTransaction oTrans;

            //asigno la coneccionn al objeto  transaction
            oTrans = conexion.BeginTransaction();

            SqlCommand cmd = new SqlCommand();
            //le indico al command qye es un StoreProcedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;
            cmd.CommandText = NombreSp;

            //le paso la transaction
            cmd.Transaction = oTrans;

            try
            {
                if (pParametros != null)
                {
                    foreach (string dato in pParametros.Keys)
                    {
                        //cargo los parametros 
                        cmd.Parameters.AddWithValue(dato, pParametros[dato]);
                    }
                }

                ///Ejecuto la consulta
                cmd.ExecuteNonQuery();
                //si esta todo ok la transaction se ejecuta
                oTrans.Commit();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                //si no se realizo la transaction OK se hace un rollback
                oTrans.Rollback(); throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Cierro la conexion
            Cerrar();

        }


        public DataTable RetornaTabla(string NombreSp, Hashtable pParametros)
        {
            if (conexion == null)
            {
                // Inicializa la conexión aquí, ya sea creando una nueva instancia o recuperándola de otro lugar
                conexion = new SqlConnection(@"Data Source=LAPTOP-RJIKNK5J\SQLEXPRESS01;Initial Catalog=Estetica;Integrated Security=True");
            }

            DataTable tabla = new DataTable();
            SqlDataAdapter Da;
            //uso el constructor del objeto Command
            command = new SqlCommand(NombreSp, conexion);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                Da = new SqlDataAdapter(command);
                Da.SelectCommand.Connection = conexion;
                if ((pParametros != null))
                {
                    //si la hashtable no esta vacia, y tiene el dato q busco 
                    foreach (string dato in pParametros.Keys)
                    {
                        //cargo los parametros que le estoy pasando con la Hash
                        command.Parameters.AddWithValue(dato, pParametros[dato]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Da.Fill(tabla);
            return tabla;
        }




        //Metodo para guardar el Dataset en la Base en modo desconectado
        //utilizando Transaction
        public void GuardarDatasetDesconectado(DataSet Ds, string pStore)
        {
            //Abro la conexion
            conexion.Open();
            //creo el objeto transaction
            SqlTransaction oTrans;
            //asigno la coneccionn al objeto  transaction
            oTrans = conexion.BeginTransaction();
            //SETEO DATAADAPTER CON el Store Y CONNECTIONSTRING
            SqlDataAdapter Da = new SqlDataAdapter(pStore, conexion);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Transaction = oTrans;
            //SE SETEAN LOS METODOS PARA GUARDAR DATOS EN BASE DE DATOS
            SqlCommandBuilder Cb = new SqlCommandBuilder(Da);

            Da.UpdateCommand = Cb.GetUpdateCommand();
            Da.DeleteCommand = Cb.GetDeleteCommand();
            Da.InsertCommand = Cb.GetInsertCommand();
            Da.ContinueUpdateOnError = true;

            Da.UpdateCommand.Transaction = oTrans;
            Da.DeleteCommand.Transaction = oTrans;
            Da.InsertCommand.Transaction = oTrans;
            try
            {
                //SE INTENTAN PERSISTIR LOS CAMBIOS EN LA BASE DE DATOS
                Da.Update(Ds.Tables[0]);
                oTrans.Commit();

            }
            catch (SqlException ex)
            {
                //si no se realizo la transaction OK se hace un rollback
                oTrans.Rollback(); throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            Cerrar();

        }

    



    }

}

