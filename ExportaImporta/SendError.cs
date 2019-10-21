using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio;


namespace ExportaImporta
{
    public static class SendError
    {

        public static void EnviarErrorImportacion(string _funcion_errores_importacion, string _error_errores_importacion)
        {

            //ins_errores_importacion(_funcion_errores_importacion character varying(80),_error_errores_importacion character varying(400))
            string cadena1 = _funcion_errores_importacion + "?" + _error_errores_importacion;

            string cadena2 = "_funcion_errores_importacion?_error_errores_importacion";
            string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_errores_importacion");


            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error al insertar Error" + Ex.Message);
            }

        }
    }
}
