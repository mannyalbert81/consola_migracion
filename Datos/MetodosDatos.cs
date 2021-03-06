﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Globalization;

namespace Datos
{
   public class MetodosDatos
    {
        //public static string cadenaConexion = @"Server=18.218.148.189;Port=5432;User Id=postgres;Password=Capremci2018;Database=web_capremci;Preload Reader = true;";
       //  public static string cadenaConexion = @"Server=192.168.1.231;Port=5432;User Id=postgres;Password=Programadores2018;Database=rp_capremci;Preload Reader = true;";
        public static string cadenaConexion = @"Server=192.168.1.231;Port=5432;User Id=postgres;Password=Programadores2018;Database=rp_capremci;Preload Reader = true;";

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


        public static DataTable EjecutarComando1(NpgsqlCommand comando)
        {

            DataTable resultado = new DataTable();
            
            try
            {

                comando.Connection.Open();
                comando.CommandTimeout=0;
                NpgsqlDataAdapter comando1 = new NpgsqlDataAdapter(comando);
                comando1.Fill(resultado);

            }
            catch
            {
                resultado = null;
            }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }


            return resultado;



        }
    }
}
