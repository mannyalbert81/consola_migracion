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
    public class AccesoLogicaSQL
    {
        public static bool Autenticar(string usuario, string password)
        {
            ConsultasSQL fun = new ConsultasSQL();
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

        public static DataTable AccesoG49()
        {
            ConsultasSQL g49 = new ConsultasSQL();
            return g49.G49();
        }


        public static DataTable Select(string comando)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Select(comando);
        }

        public static DataTable SelectCompleto(string comando)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.SelectCompleto(comando);
        }


        

        public static DataTable Select(string columnas, string tabla)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Select(columnas, tabla);
        }

        public static DataTable Select(string columnas, string tabla, string where)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Select(columnas, tabla, where);
        }

        public static DataTable Select_inner_join(string cadena1, string tabla_uno, string tabla_dos, string parametro)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Select_inner_join(cadena1, tabla_uno, tabla_dos, parametro);

        }
        public static DataTable Select_secuencia(string secuencia, string AS_nombre)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Select_secuencia(secuencia, AS_nombre);

        }
        public static SqlDataAdapter Select_reporte(string cadena1, string tabla, string parametro)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Select_reporte(cadena1, tabla, parametro);

        }



        public static int Insert(string datos, string columnas, string tabla)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Insert(datos, columnas, tabla);
        }

        public static int Insert(string datos, string columnas, string tipoDatos, string funcion)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Insert(datos, columnas, tipoDatos, funcion);
        }

        public static int Delete(string where, string tabla)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Delete(where, tabla);
        }

        public static int Update(string tabla, string campo, string where)
        {
            ConsultasSQL fun = new ConsultasSQL();
            return fun.Update(tabla, campo, where);
        }


        public static DataTable AccesoG41_BIESS(DateTime fecha)
        {
            Procedimiento_G41_BIESS g41 = new Procedimiento_G41_BIESS();
            return g41.G41_BIESS(fecha);
        }


        public static DataTable AccesoG42_BIESS(DateTime fecha)
        {
            Procedimiento_G41_BIESS g42 = new Procedimiento_G41_BIESS();
            return g42.G42_BIESS(fecha);
        }

    }
}
