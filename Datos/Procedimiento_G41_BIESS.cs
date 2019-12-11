using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using System.Data.SqlClient;

namespace Datos
{
  public  class Procedimiento_G41_BIESS
    {

        public DataTable G41_BIESS(DateTime fecha)
        {

            //    string cone = MetodosDatosSQL.cadenaConexion;


            DataTable g41 = new DataTable();

            try
            {

                SqlConnection conexion = new SqlConnection(MetodosDatosSQL.cadenaConexion);
                conexion.Open();

                SqlCommand sqlCm = new SqlCommand("SP_BIESS_G41", conexion);
                sqlCm.CommandType = CommandType.StoredProcedure;

                sqlCm.Parameters.Add("@FECHA", SqlDbType.Date).Value = fecha;
                sqlCm.CommandTimeout = 0;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCm);
                sqlAdp.Fill(g41);

            }
            catch
            {
                g41 = null;
            }
            return g41;
        }






        public DataTable G42_BIESS(DateTime fecha)
        {

            //    string cone = MetodosDatosSQL.cadenaConexion;


            DataTable g42 = new DataTable();

            try
            {

                SqlConnection conexion = new SqlConnection(MetodosDatosSQL.cadenaConexion);
                conexion.Open();

                SqlCommand sqlCm = new SqlCommand("SP_BIESS_G42", conexion);
                sqlCm.CommandType = CommandType.StoredProcedure;

                sqlCm.Parameters.Add("@FECHA", SqlDbType.Date).Value = fecha;
                sqlCm.CommandTimeout = 0;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCm);
                sqlAdp.Fill(g42);

            }
            catch
            {
                g42 = null;
            }
            return g42;
        }




    }
}
