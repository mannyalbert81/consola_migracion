using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using System.Data.SqlClient;


namespace Negocio
{
    public class AccesoLogicaSQL_FCPC
    {


        public static bool Autenticar(string usuario, string password)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            DataTable tabla = fun.Select("*", "usuario", "usuario_usuario = '" + usuario + "'  AND clave_usuario = '" + password + "'");

            int registros = tabla.Rows.Count;
            if (registros > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable Select(string comando)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Select(comando);
        }

        public static DataTable SelectCompleto(string comando)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.SelectCompleto(comando);
        }




        public static DataTable Select(string columnas, string tabla)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Select(columnas, tabla);
        }

        public static DataTable Select(string columnas, string tabla, string where)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Select(columnas, tabla, where);
        }

        public static DataTable Select_inner_join(string cadena1, string tabla_uno, string tabla_dos, string parametro)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Select_inner_join(cadena1, tabla_uno, tabla_dos, parametro);

        }
        public static DataTable Select_secuencia(string secuencia, string AS_nombre)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Select_secuencia(secuencia, AS_nombre);

        }
        public static SqlDataAdapter Select_reporte(string cadena1, string tabla, string parametro)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Select_reporte(cadena1, tabla, parametro);

        }



        public static int Insert(string datos, string columnas, string tabla)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Insert(datos, columnas, tabla);
        }

        public static int Insert(string datos, string columnas, string tipoDatos, string funcion)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Insert(datos, columnas, tipoDatos, funcion);
        }

        public static int Delete(string where, string tabla)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Delete(where, tabla);
        }

        public static int Update(string tabla, string campo, string where)
        {
            ConsultasSQL_FCPC fun = new ConsultasSQL_FCPC();
            return fun.Update(tabla, campo, where);
        }


    }
}
