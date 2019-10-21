using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ConsultasSQL_FCPC
    {


        public DataTable Select(string comando)
        {
            return MetodosDatosSQL_FCPC.EjecutarConsula(comando);
        }

        public DataTable Select(string columnas, string tabla)
        {
            string comando = "SELECT " + columnas + " FROM " + tabla;
            return MetodosDatosSQL_FCPC.EjecutarConsula(comando);
        }


        public DataTable SelectCompleto(string consulta)
        {
            string comando = consulta;
            return MetodosDatosSQL_FCPC.EjecutarConsula(comando);
        }

        public DataTable Select(string columnas, string tabla, string where)
        {
            where = where.Replace("''", "null");
            string comando = "SELECT " + columnas + " FROM " + tabla + " WHERE " + where;
            return MetodosDatosSQL_FCPC.EjecutarConsula(comando);
        }

        public DataTable Select_inner_join(string cadena1, string tabla_uno, string tabla_dos, string parametro)
        {

            string comando = "SELECT " + cadena1 + " FROM " + tabla_uno + " INNER JOIN  " + tabla_dos + "  ON(" + parametro + ")";
            return MetodosDatosSQL_FCPC.EjecutarConsula(comando);

        }

        public DataTable Select_secuencia(string secuencia, string AS_nombre)
        {

            string comando = "SELECT currval('" + secuencia + "') AS " + AS_nombre;
            return MetodosDatosSQL_FCPC.EjecutarConsula(comando);

        }

        public SqlDataAdapter Select_reporte(string cadena1, string tabla, string parametro)
        {
            SqlConnection conexion = new SqlConnection(MetodosDatosSQL_FCPC.cadenaConexion);
            conexion.Open();

            SqlDataAdapter consulta = new SqlDataAdapter("SELECT " + cadena1 + " FROM " + tabla + " WHERE " + parametro + "  ", conexion);

            conexion.Close();

            return consulta;
        }

        public int Insert(string datos, string columnas, string tabla)
        {
            datos = datos.Replace("''", "null");
            SqlConnection conexion = new SqlConnection(MetodosDatosSQL_FCPC.cadenaConexion);
            SqlCommand comando = new SqlCommand("insert into " + tabla + " (" + columnas + ") values (" + datos + ")", conexion);
            return MetodosDatosSQL_FCPC.EjecutarComando(comando);
        }


        public int Insert(string datos, string columnas, string tipoDatos, string funcion)
        {
            datos = datos.Replace("''", "null");
            SqlCommand comando = MetodosDatosSQL_FCPC.CrearComandoProc(funcion);
            if (datos.Contains("?"))
            {
                string[] vector1 = Vector(datos);
                string[] vector2 = Vector(columnas);
                string[] vector3 = Vector(tipoDatos);

                for (int i = 0; i < vector1.Length; i++)
                {
                    comando.Parameters.Add(new SqlParameter(vector2[i], vector3[i]));
                    comando.Parameters[i].Value = vector1[i];
                }
            }
            else
            {
                comando.Parameters.Add(new SqlParameter(columnas, tipoDatos));
                comando.Parameters[0].Value = datos;
            }

            return MetodosDatosSQL_FCPC.EjecutarComando(comando);
        }

        public int Delete(string where, string tabla)
        {
            SqlConnection conexion = new SqlConnection(MetodosDatosSQL_FCPC.cadenaConexion);
            SqlCommand comando = new SqlCommand("DELETE from " + tabla + " where " + where, conexion);
            return MetodosDatosSQL_FCPC.EjecutarComando(comando);
        }

        public int Update(string tabla, string campo, string where)
        {
            SqlConnection conexion = new SqlConnection(MetodosDatosSQL_FCPC.cadenaConexion);
            SqlCommand _comando = new SqlCommand("UPDATE  " + tabla + " SET " + campo + " WHERE " + where, conexion);


            return MetodosDatosSQL_FCPC.EjecutarComando(_comando);
        }


        public static string[] Vector(string cadena)
        {
            string[] vector;

            if (cadena.Contains('?'))
            {
                vector = cadena.Split('?');
            }
            else
            {
                vector = new string[1];
                vector[0] = cadena;
            }
            return vector;
        }




    }
}
