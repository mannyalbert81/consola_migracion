using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio;
using System.Data;
using System.IO;

using Npgsql;
using NpgsqlTypes;


namespace Duplicados
{
    class Program
    {
        public static void Main(string[] args)
        {
            tipo_documentos_nombre();
            //cliente_proveedor_nombre();


        }


        public static void cliente_proveedor_nombre()
        {
            DataTable dtOriginal = AccesoLogica.Select("id_cliente_proveedor, nombre_cliente_proveedor, ruc_cliente_proveedor", "cliente_proveedor", " ruc_cliente_proveedor LIKE '%%' ORDER BY rtrim(nombre_cliente_proveedor) ");

            int reg = dtOriginal.Rows.Count;
            int _id_original = 0;
            int _id_duplicados = 0;
            string _nombre_original = "";
            if (reg > 0)
            {
                foreach (DataRow renglonCli in dtOriginal.Rows)
                {
                    _id_original = Convert.ToInt32(renglonCli["id_cliente_proveedor"].ToString());
                    _nombre_original = renglonCli["nombre_cliente_proveedor"].ToString();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Nombre: "+_nombre_original);
                    DataTable dtDuplicados = AccesoLogica.Select("id_cliente_proveedor, nombre_cliente_proveedor", "cliente_proveedor", " rtrim(nombre_cliente_proveedor) = rtrim( '" + _nombre_original + "'   ) ");
                    int regDup = dtDuplicados.Rows.Count;
                    if (regDup > 0)
                    {
                        foreach (DataRow renglonDup in dtDuplicados.Rows)
                        {
                            _id_duplicados = Convert.ToInt32(renglonDup["id_cliente_proveedor"].ToString());
                            if (_id_duplicados == _id_original)
                            {

                            }
                            else
                            {
                                try
                                {
                                    AccesoLogica.Update("documentos_legal", "id_cliente_proveedor = '" + _id_original + "' ", "id_cliente_proveedor = '" + _id_duplicados + "' ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Actualizado: " + _nombre_original);
                                }
                                catch (Exception)
                                {

                                }

                                try
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    AccesoLogica.Delete("id_cliente_proveedor = '" + _id_duplicados + "' ", "cliente_proveedor");
                                    Console.WriteLine("Borrado: " + _nombre_original);
                                }
                                catch (Exception)
                                {

                                }


                            }


                        }

                    }

                }
            }
        }




        public static void tipo_documentos_nombre()
        {
            DataTable dtOriginal = AccesoLogica.Select("id_tipo_documentos, nombre_tipo_documentos", "tipo_documentos", " nombre_tipo_documentos LIKE '%%' ORDER BY rtrim(nombre_tipo_documentos) ");

            int reg = dtOriginal.Rows.Count;
            int _id_original = 0;
            int _id_duplicados = 0;
            string _nombre_original = "";
            if (reg > 0)
            {
                foreach (DataRow renglonTip in dtOriginal.Rows)
                {
                    _id_original = Convert.ToInt32(renglonTip["id_tipo_documentos"].ToString());
                    _nombre_original = renglonTip["nombre_tipo_documentos"].ToString();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Nombre: " + _nombre_original);
                    DataTable dtDuplicados = AccesoLogica.Select("id_tipo_documentos, nombre_tipo_documentos", "tipo_documentos", " rtrim(nombre_tipo_documentos) = rtrim( '" + _nombre_original + "'   ) ");
                    int regDup = dtDuplicados.Rows.Count;
                    if (regDup > 0)
                    {
                        foreach (DataRow renglonDup in dtDuplicados.Rows)
                        {
                            _id_duplicados = Convert.ToInt32(renglonDup["id_tipo_documentos"].ToString());
                            if (_id_duplicados == _id_original)
                            {

                            }
                            else
                            {
                                try
                                {
                                    AccesoLogica.Update("documentos_legal", "id_tipo_documentos = '" + _id_original + "' ", "id_tipo_documentos = '" + _id_duplicados + "' ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Actualizado: " + _nombre_original);
                                }
                                catch (Exception)
                                {

                                }

                                try
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    AccesoLogica.Delete("id_tipo_documentos = '" + _id_duplicados + "' ", "tipo_documentos");
                                    Console.WriteLine("Borrado: " + _nombre_original);
                                }
                                catch (Exception)
                                {

                                }


                            }


                        }

                    }

                }
            }
        }






    }
}
