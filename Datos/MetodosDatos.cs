using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Datos
{
    class MetodosDatos
    {
        //public static string cadenaConexion = @"Server=18.218.148.189;Port=5432;User Id=postgres;Password=Capremci2018;Database=web_capremci;Preload Reader = true;";
       //  public static string cadenaConexion = @"Server=192.168.1.231;Port=5432;User Id=postgres;Password=Programadores2018;Database=rp_capremci;Preload Reader = true;";
        public static string cadenaConexion = @"Server=186.4.157.125;Port=5432;User Id=postgres;Password=Programadores2018;Database=rp_capremci;Preload Reader = true;";
        
        //186.65.24.196

        public static DataTable EjecutarConsula(string comando)
        {
            DataTable data = new DataTable();
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
                conexion.Open();
                NpgsqlDataAdapter consulta = new NpgsqlDataAdapter(comando, conexion);
               
                conexion.Close();
                consulta.Fill(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;

            

        }

        public static NpgsqlCommand CrearComandoProc(string nombre_proc)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
            NpgsqlCommand comando = new NpgsqlCommand(nombre_proc, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            return comando;
        }

        public static int EjecutarComando(NpgsqlCommand comando)
        {
            try
            {

               // Console.WriteLine(comando);


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
