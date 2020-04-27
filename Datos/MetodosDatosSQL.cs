using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Datos
{
    class MetodosDatosSQL
    {

      //  public static string cadenaConexion = @"Data Source=192.168.1.208;Initial Catalog=one.capremci_PROD;User ID=sa;Password=$software$01";
        public static string cadenaConexion = @"Data Source=186.4.157.125;Initial Catalog=one.capremci_PROD;User ID=sa;Password=$software$01";

        //public static string cadenaConexion = @"Data Source=MASOFT-SERVER;Initial Catalog=agro;User ID=sa;Password=Met@fr@me640";
        //Data Source = 192.168.1.206; Initial Catalog = one.capremci_PROD; User ID = sa; Password=***********

        //186.65.24.196

        public static DataTable EjecutarConsula(string comando)
        {
            DataTable data = new DataTable();
            try
            {
                
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                
               // SqlDataAdapter consulta = new SqlDataAdapter(comando, conexion);

                SqlCommand consulta = new SqlCommand(comando, conexion);
                consulta.CommandTimeout = 0;
                conexion.Close();

                SqlDataAdapter sqlAdp = new SqlDataAdapter(consulta);
                sqlAdp.Fill(data);

                //consulta.Fill(data);
               
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de Conexion -> " + ex);
                Console.ReadLine();
            }

            return data;
        }

        public static SqlCommand CrearComandoProc(string nombre_proc)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand(nombre_proc, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            return comando;
        }

        public static int EjecutarComando(SqlCommand comando)
        {
            try
            {
                comando.Connection.Open();
                return comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }
    }
}
