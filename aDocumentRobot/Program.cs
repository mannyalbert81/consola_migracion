using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using Npgsql;
using NpgsqlTypes;
using iTextSharp.text;

namespace aDocumentRobot
{
    class Program
    {

        static void Main(string[] args)
        {


            ///borro los errores
            AccesoLogica.Delete("id_errores_importacion > 0", "errores_importacion");

            buscaCategoria();

            
            ///resumen
            Console.WriteLine("Documentos Nuevos: " + ResumenDiario._cantidad_doc + " Total de Páginas Nuevas: " + ResumenDiario._paginas_doc);

            
            Console.WriteLine("Enviado resumen ...");
            
            
            ResumenInsertSend RIS = new ResumenInsertSend();

            
            try
            {
              RIS.InsertaResumen(ResumenDiario._cantidad_doc, ResumenDiario._paginas_doc);
            }
            catch (Exception Ex)
            {

                SendError.EnviarErrorImportacion("Enviar Correo", Ex.Message);
            }
            
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("<----------------------------------------->");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Termino el Proceso. FELICITACIONES !!! ...");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("<----------------------------------------->");

            Console.Read();

            
        }


        public static void buscaCategoria()
        {
            
            int   _id_categorias = 0;
            int _id_subcategorias = 0;
            string _nombre_categorias = "";
            string _path_categorias = "";

            
            
            string _nombre_subcategorias = "";
            string _path_subcategorias = "";
            

            DataTable dtCategorias = AccesoLogica.Select("id_categorias, nombre_categorias, path_categorias", "categorias", "nombre_categorias LIKE '%' ");
            int regCat = dtCategorias.Rows.Count;


            if (regCat > 0)
            {

                


                foreach (DataRow renglon in dtCategorias.Rows)
                {
                    _id_categorias = Convert.ToInt32(renglon["id_categorias"].ToString());
                    _nombre_categorias = renglon["nombre_categorias"].ToString();
                    
                    string _path_categorias_dos = renglon["path_categorias"].ToString();
                    _path_categorias = _path_categorias_dos.Replace(@"D:\CAPREMCI ULTIMO", @"C:\CAPREMCI ULTIMO 2018");

                
                  
                        DataTable dtSubCategorias = AccesoLogica.Select("id_subcategorias, id_categorias, nombre_subcategorias, path_subcategorias, lecturas_subcategorias, creado, modificado", "subcategorias", "id_categorias = '" + _id_categorias + "'  ");
                        int regSubCat = dtCategorias.Rows.Count;

                        if (regSubCat > 0)
                        {



                            foreach (DataRow renglonSub in dtSubCategorias.Rows)
                            {



                                _id_subcategorias = Convert.ToInt32(renglonSub["id_subcategorias"].ToString());
                                Console.WriteLine(_id_subcategorias);



                                _nombre_subcategorias = renglonSub["nombre_subcategorias"].ToString();
                                _path_subcategorias = renglonSub["path_subcategorias"].ToString();

                                String _path_completo = _path_categorias + _path_subcategorias;

                                Console.WriteLine("Archivo ->" + _path_completo);

                                //Console.WriteLine("Cate y Sub ->" + _id_categorias + " "+ _id_subcategorias);


                                buscaXML(_path_completo, _id_subcategorias, _nombre_subcategorias);

                                Console.WriteLine("Categoría -> " + _nombre_categorias);

                                //Console.WriteLine("Total de archivos en Subcategorias ->" + files.Length);


                                Console.WriteLine("SubCategoría -> " + _nombre_subcategorias + " path -> " + _path_completo);



                            }


                        }





                  




                }

            }
        


        }




        private static void buscaXML(string _path_completo, int _id_subcategorias, string _nombre_subcategorias)

        {
            
        
            string _path_xml_archivo = "";
            string _nombre_xml_archivo = "";

            try
            {

                DirectoryInfo directory = new DirectoryInfo(@_path_completo);

                Console.WriteLine("Camino" + _path_completo);
                FileInfo[] files = directory.GetFiles("*.XML");

                
                DirectoryInfo[] directories = directory.GetDirectories();

                for (int i = 0; i < files.Length; i++)
                {
                    _path_xml_archivo = ((FileInfo)files[i]).FullName;
                    _nombre_xml_archivo = ((FileInfo)files[i]).Name;
                    Console.WriteLine(((FileInfo)files[i]).Name);


                    ///aqui debo leer contenido del xml
                    ///
                    Console.WriteLine("LEDIOS XML " + i);

                    leerXML(_path_xml_archivo, _nombre_xml_archivo, _id_subcategorias, _nombre_subcategorias);

                }

                
            }

            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());
                
            }

        }


        public static void leerXML(string _path, string _nombre_xml_archivo, int _id_subcategorias, string _nombre_subcategorias)
        {

            bool _soap = false;
            string _ruc_cliente_proveedor = "S/N";
            string _fecha = "";
            string _nombre_cliente_proveedor = "S/N";
            string _nombre_tipo_documento = "S/T";


            if (_id_subcategorias > 48)
            {
                _nombre_tipo_documento = _nombre_subcategorias;

            }

            
            string _numero_carton_documentos = "S/C";
            string _cierre_ventas_soat = " ";
            int _id_lecturas = 0;
            
            int _id_cliente_proveedor = 0;
            int _id_garante = 1;
            int _id_tipo_documentos = 0;
            int _id_carton_documentos = 0;
            int _id_soat = 0;



            DateTime _fecha_documentos_legal = DateTime.Now;
            
            DateTime _fecha_desde_documentos_legal = DateTime.Now;
            DateTime _fecha_hasta_documentos_legal = DateTime.Now;
            string   _ramo_documentos_legal ="";
            string   _numero_poliza_documentos_legal = "";
            string _ciudad_emision_documentos_legal = "";

            string _cheque_documentos_legal = "";
            string _valor_documentos_legal = "";




            int _etapa = 2;



            string _ruc_garante = "";
            string _nombre_garante = "";
            string _numero_credito_documentos_legal = "";
            double _monto_solicitado = 0;
            string _estado_documentos_legal = "";



            string _fechaString = "";


            try
            {
                var xdoc = XDocument.Load(@_path);

                var items = from i in xdoc.Descendants("field")
                            select new
                            {
                                _name = (string)i.Attribute("name"),
                                _value = (string)i.Attribute("value")
                            };

                int _contador = 1;
                foreach (var item in items)
                {




                    // use item.Action or item.FileName



                    if (item._name.ToString() == "RUC_CC")
                    {
                        _ruc_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                    }


                    if (item._name.ToString() == "RUC O CI")
                    {
                        _ruc_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                    }



                    if (item._name.ToString() == "RUC O CC")
                    {
                        _ruc_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                    }


                    if (item._name.ToString() == "RUC-CI")
                    {
                        _ruc_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                    }
                    if (item._name.ToString() == "RUC_O_CI")
                    {
                        _ruc_cliente_proveedor = item._value.ToString().Replace("'", ""); ;
                    }
                    if (item._name.ToString() == "RUC")
                    {
                        _ruc_cliente_proveedor = item._value.ToString().Replace("'", ""); ;
                    }


                    ////AQUI VEO SI EL RUC ES CREO 0  ES PORQUE EL TIPO ES SIN RUC
                    /*
                    if (_ruc_cliente_proveedor.Trim() == "0")   ///asignamos un generico
                    {
                        DataTable dtRUC = AccesoLogica.Select("real_consecutivos","consecutivos","documento_consecutivos = 'RUC' ");

                        int regRUC = dtRUC.Rows.Count;
                        string _ruc = "";
                        if (regRUC > 0)
                        {

                            foreach (DataRow renglonRUC in dtRUC.Rows)
                            {
                                _ruc = renglonRUC["real_consecutivos"].ToString();
                            }

                            _ruc_cliente_proveedor = _ruc;


                            //actualizo el ruc
                            AccesoLogica.Update("consecutivos", "real_consecutivos = real_consecutivos + 1", "documento_consecutivos = 'RUC' ");
                        }



                    }
                    */
                    if (item._name.ToString() == "FECHA" || item._name.ToString() == "FECHA_DE_CIERRE")
                    {

                        string year;
                        string mes;
                        string dia;

                        _fecha = item._value.ToString();

                        if (_fecha.ToString().Length == 10)
                        {
                            
                                year = _fecha.Substring(0, 4);
                                mes = _fecha.Substring(5, 2);
                                dia = _fecha.Substring(8, 2);
                            
                                if (year.Contains("."))
                                {
                                    dia = _fecha.Substring(0, 2);
                                    mes = _fecha.Substring(3, 2);
                                    year = _fecha.Substring(5, 4);
                                    
                                }
                              
                        }
                        else
                        {
                            year = "";
                            mes = "";
                            dia = "";

                        }
                        try
                        {
                            _fechaString = dia + "/" + mes + "/" + year + " 00:01:01";
                            _fecha_documentos_legal = Convert.ToDateTime(_fechaString);
                        }
                        catch (Exception Ex)
                        {
                            
                            SendError.EnviarErrorImportacion("Errer XML Fecha: " + _path + "  " + _nombre_xml_archivo, Ex.Message);


                        }

                    }


                    if (item._name.ToString() == "FECHA DESDE")
                    {

                        string year;
                        string mes;
                        string dia;

                        _fecha = item._value.ToString();

                        if (_fecha.ToString().Length == 10)
                        {
                            year = _fecha.Substring(0, 4);
                            mes = _fecha.Substring(5, 2);
                            dia = _fecha.Substring(8, 2);
                        }
                        else
                        {
                            year = "1900";
                            mes = "01";
                            dia = "01";

                        }

                        try
                        {
                            _fechaString = dia + "/" + mes + "/" + year + " 00:01:01";
                            _fecha_desde_documentos_legal = Convert.ToDateTime(_fechaString);
                        }
                        catch (Exception Ex)
                        {
                            
                            SendError.EnviarErrorImportacion("Errer XML Fecha Desde: " + _path + "  " + _nombre_xml_archivo, Ex.Message);


                        }
                    }
                    
                    if (item._name.ToString() == "FECHA HASTA")
                    {

                        string year;
                        string mes;
                        string dia;

                        _fecha = item._value.ToString();

                        if (_fecha.ToString().Length == 10)
                        {
                            year = _fecha.Substring(0, 4);
                            mes = _fecha.Substring(5, 2);
                            dia = _fecha.Substring(8, 2);
                        }
                        else
                        {
                            year = "";
                            mes = "";
                            dia = "";

                        }

                        try
                        {
                            _fechaString = dia + "/" + mes + "/" + year + " 00:01:01";
                            _fecha_hasta_documentos_legal = Convert.ToDateTime(_fechaString);
                        }
                        catch (Exception Ex)
                        {
                            
                            SendError.EnviarErrorImportacion("Errer XML Fecha Hasta: " + _path + "  " + _nombre_xml_archivo, Ex.Message);


                        }
                    }



                    if (item._name.ToString() == "NOMBRE CLIENTE")
                    {
                        _nombre_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "NOMBRE DEL CLIENTE")
                    {
                        _nombre_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "NOMBRE_CLIENTE")
                    {
                        _nombre_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                    }


                    if (item._name.ToString() == "NOMBRE_CLIENTE_O_EMPRESA")
                    {
                        _nombre_cliente_proveedor = item._value.ToString().Trim().Replace("'", ""); 
                    }
                    if (item._name.ToString() == "NOMBRE EMPRESA")
                    {
                        _nombre_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                    }
                    if (_nombre_cliente_proveedor == "")
                    {
                        if (item._name.ToString() == "NOMBRE CLIENTE O EMPRESA")
                        {
                            _nombre_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                        }
                    }
                    if (_nombre_cliente_proveedor == "")
                    {
                        if (item._name.ToString() == "NOMBRE DEL CLIENTE")
                        {
                            _nombre_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                        }
                    }

                    if (item._name.ToString() == "NOMBRE")
                    {
                        _nombre_cliente_proveedor = item._value.ToString().Trim().Replace("'", "");
                    }



                    if (item._name.ToString() == "TIPO DE DOCUMENTO")
                    {
                        _nombre_tipo_documento = item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "NUMERO DE OFICIO")
                    {
                        _nombre_tipo_documento = item._value.ToString().Trim().Replace("'", "");
                    }

                    


                    if (item._name.ToString() == "TIPO DE CREDITO ")
                    {
                        _nombre_tipo_documento = item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "TIPO DE CREDITO")
                    {
                        _nombre_tipo_documento = item._value.ToString().Trim().Replace("'", ""); 
                    }


                    if (item._name.ToString() == "TIPO DE PRESTACION")

                    {
                        _nombre_tipo_documento = item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "TIPO PRESTACION")
                    {
                        _nombre_tipo_documento = item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "TIPO_DE_CREDITO")
                    {
                        _nombre_tipo_documento = item._value.ToString().Trim().Replace("'", "");
                    }


                    if (item._name.ToString() == "NUMERO DE CARTON")
                    {
                        //_numero_carton_documentos = "S/C";
                        _numero_carton_documentos = item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "NUMERO_CARTON")
                    {
                        //_numero_carton_documentos = "S/C";
                        _numero_carton_documentos = item._value.ToString().Trim().Replace("'", ""); 
                    }
                    if (item._name.ToString() == "NUMERO_DE_CARTON")
                    {
                        //_numero_carton_documentos = "S/C";
                        _numero_carton_documentos = item._value.ToString().Trim().Replace("'", ""); 
                    }

                    
                    if (item._name.ToString() == "NUMERO CARTON")
                    {
                        //_numero_carton_documentos = "S/C";
                        _numero_carton_documentos = item._value.ToString().Trim().Replace("'", "");
                    }
                    if (item._name.ToString() == "NUMER0_CARTON")
                    {
                        //_numero_carton_documentos = "S/C";
                        item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "NUMERO DE CHEQUE")
                    {
                        //_numero_carton_documentos = "S/C";
                        _cheque_documentos_legal = item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "VALOR PAGADO")
                    {
                        //_numero_carton_documentos = "S/C";
                        _valor_documentos_legal = item._value.ToString().Trim().Replace("'", "");
                    }


                    




                    if (_numero_carton_documentos == "")
                    {
                      
                    }

                    if (_numero_carton_documentos.Length == 0)
                    {
                        _numero_carton_documentos = "S/C";
                    }


                    if (item._name.ToString() == "RAMO")
                    {
                        _ramo_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }

                    
                    if (item._name.ToString() == "MONTO A RECIBIR")
                    {
                        _monto_solicitado = Convert.ToDouble(item._value.ToString().Trim());
                    }


                    if (item._name.ToString() == "MONTO RECIBIDO")
                    {
                        _monto_solicitado = Convert.ToDouble(item._value.ToString().Trim());
                    }



                    if (item._name.ToString() == "NUMERO_POLIZA")
                    {
                        _numero_poliza_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }
                    if (item._name.ToString() == "NUMERO DE POLIZA")
                    {
                        _numero_poliza_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }
                    
                    if (item._name.ToString() == "CIUDAD_DE_EMISION")
                    {
                        _ciudad_emision_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }

                    if (item._name.ToString() == "CIUDAD DE EMISION")
                    {
                        _ciudad_emision_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }

                    if (item._name.ToString() == "SUCURSAL")
                    {
                        _ciudad_emision_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }

                    if (item._name.ToString() == "BANCO")
                    {
                        _ciudad_emision_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }



                    ////pagares
                    ////garante
                    if (item._name.ToString() == "CC DEL GARANTE")
                    {
                        _ruc_garante = item._value.ToString().Trim().Replace("'", "");
                    }

                    if (item._name.ToString() == "NOMBRE GARANTE")
                    {
                        _nombre_garante = item._value.ToString().Trim().Replace("'", "");
                    }


                    if (item._name.ToString() == "NUMERO DE CREDITO")
                    {
                        _numero_credito_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }
                    if (item._name.ToString() == "NUMERO DE CREDITO ")
                    {
                        _numero_credito_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }

                    if (item._name.ToString() == "NUMERO DE PRESTACION")
                    {
                        _numero_credito_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;

                    }


                    if (item._name.ToString() == "NUMERO DE ACTA")
                    {
                        _numero_credito_documentos_legal = item._value.ToString().Trim().Replace("'", ""); ;
                    }



                    if (item._name.ToString() == "MONTO SOLICITADO")
                    {
                        _monto_solicitado = Convert.ToDouble(item._value.ToString().Trim());
                    }


                    if (item._name.ToString() == "MONTO DE PRESTACION")
                    {
                        _monto_solicitado = Convert.ToDouble(item._value.ToString().Trim());
                    }

                    if (item._name.ToString() == "ESTADO")
                    {
                        _estado_documentos_legal = Convert.ToString(item._value.ToString());
                    }




                    if (item._name.ToString() == "CIERRE_DE_VENTAS_SOAT" || item._name.ToString() == "CIERRE_DE_VENTA_SOAT")
                    {
                        _soap = true;
                        _cierre_ventas_soat = item._value.ToString();
                        _nombre_tipo_documento = "SOAP";
                        _ruc_cliente_proveedor = "S/CP";
                        _nombre_cliente_proveedor = "S/CP";
                    }
                    
                    _contador++;

                }

                if (_numero_carton_documentos != "" )
                {
                        
                    ///inserto la lectura
                    _id_lecturas = insertaLectura(_id_subcategorias, _nombre_xml_archivo);


                    ///antes de seguir vemos si este documentos ya esta insertado correctamente
                    ///pues lo hago con estado de lecturas
                    ///
                    bool _estado = false;
                    ///primero buscamos si ya subimos la imagen

                    DataTable dtLectura = AccesoLogica.Select("estado_lecturas", "lecturas", "id_lecturas = '" + _id_lecturas + "' ");
                    int regID = dtLectura.Rows.Count;
                    if (regID > 0)
                    {
                        //ya existe

                        foreach (DataRow renglon in dtLectura.Rows)
                        {
                            _estado = Convert.ToBoolean(renglon["estado_lecturas"].ToString());
                        }

                        Console.WriteLine(_estado);
                    }

                    if (_estado)
                    {

                    }
                    else
                    {

                        //inserto el cliente o proveedor
                        _id_cliente_proveedor = insertaClienteProveedor(_ruc_cliente_proveedor, _nombre_cliente_proveedor);

                        //inserto el garante
                        _id_garante = insertaGarante(_ruc_garante, _nombre_garante);


                        //inserto el carton documentos
                        _id_carton_documentos = insertaCartonDocumentos(_numero_carton_documentos);

                        //inserto el tipo documentos
                        _id_tipo_documentos = insertaTipoDocumento(_nombre_tipo_documento);

                        //inserto el cierre soat
                        _id_soat = insertaSoat(_cierre_ventas_soat);

                        


                        ///inserto documento Legal
                        if (_id_carton_documentos > 0)
                        {
                            //insertaDocumentoLegal(_path, _id_lecturas, _id_subcategorias, _id_cliente_proveedor, _id_tipo_documentos, _id_carton_documentos, _fecha_documentos_legal, _fecha_desde_documentos_legal, _fecha_hasta_documentos_legal, _ramo_documentos_legal, _numero_poliza_documentos_legal, _ciudad_emision_documentos_legal, _id_soat, _monto_solicitado, _numero_credito_documentos_legal,  _id_garante , _estado_documentos_legal, _cheque_documentos_legal, _valor_documentos_legal);
                            insertaDocumentoLegal(_path, _id_lecturas, _id_subcategorias, _id_cliente_proveedor, _id_tipo_documentos, _id_carton_documentos, _fecha_documentos_legal, _fecha_desde_documentos_legal, _fecha_hasta_documentos_legal, _ramo_documentos_legal, _numero_poliza_documentos_legal, _ciudad_emision_documentos_legal, _id_soat, _monto_solicitado, _numero_credito_documentos_legal, _id_garante, _estado_documentos_legal, _cheque_documentos_legal, _valor_documentos_legal, _etapa);


                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine("RUC ->" + _ruc_cliente_proveedor + " NOMBRE ->" + _nombre_cliente_proveedor + "TIPO ->" + _nombre_tipo_documento + " CARTON ->" + _numero_carton_documentos + "FECHA_DESDE" + _fecha_desde_documentos_legal + "FECHA_HASTA" + _fecha_hasta_documentos_legal + "RAMO" + _ramo_documentos_legal + "NUMERO_POLIZA" + _numero_poliza_documentos_legal + "CIUDAD_DE_EMISION" + _ciudad_emision_documentos_legal);
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        else
                        {
                            SendError.EnviarErrorImportacion("Este Carton no esta en el sistema: " + _path,  _numero_carton_documentos);
                        }
                        

                    }
                }
                else
                {
                    SendError.EnviarErrorImportacion("Error en Indice de Archivo: " + _path, _nombre_cliente_proveedor + _nombre_tipo_documento + _numero_carton_documentos);
                
                }

            }
            catch (Exception Ex)
            {

                SendError.EnviarErrorImportacion("Error Archivo Ilegible: " + _path +"  ", Ex.Message);

            }
        }



        public static int  insertaLectura(int _id_subcategorias, string _nombre_lecturas)
        {
            int _id_lecturas = 0;

            ///buscamos si existe
            try
            {

                DataTable dtLecturas = AccesoLogica.Select("nombre_lecturas", "lecturas", "id_subcategorias= '" + _id_subcategorias + "' AND nombre_lecturas = '" + _nombre_lecturas + "'  ");
                int regSubCat = dtLecturas.Rows.Count;



                if (regSubCat > 0)
                {
                    //ya existe
                }
                else
                {
                    string cadena1 = _id_subcategorias + "?" + _nombre_lecturas;

                    string cadena2 = "_id_subcategorias?_nombre_lecturas";
                    string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Varchar";

                    try
                    {

                        int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_lecturas");


                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("Error al insertar Lecturas" + Ex.Message);
                        SendError.EnviarErrorImportacion("Error al insertar Lecturas: " + _nombre_lecturas, Ex.Message);
                    }


                }


                try
                {
                    DataTable dtLecturasID = AccesoLogica.Select("id_lecturas", "lecturas", "id_subcategorias= '" + _id_subcategorias + "' AND nombre_lecturas = '" + _nombre_lecturas + "'  ");
                    int regSubCatID = dtLecturasID.Rows.Count;



                    if (regSubCatID > 0)
                    {
                        //ya existe

                        foreach (DataRow renglonID in dtLecturasID.Rows)
                        {
                            _id_lecturas = Convert.ToInt32(renglonID["id_lecturas"].ToString());
                        }
                    }

                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error al insertar Lecturas" + Ex.Message);
                    SendError.EnviarErrorImportacion("Error Devolver ID de Lecturas: " + _nombre_lecturas, Ex.Message);
                }

            }
            catch (Exception Ex)
            {
                SendError.EnviarErrorImportacion("Error al Obtener Id de Lecturas: " + _id_subcategorias +" " +_nombre_lecturas, Ex.Message);
            }
            
            
            return _id_lecturas;
        
        }




        public static int insertaClienteProveedor(string _ruc_cliente_proveedor, string _nombre_cliente_proveedor)
        {
            int _id_cliente_proveedor = 0;

            ///buscamos si existe
            //if (_ruc_cliente_proveedor.Length == 10 || _ruc_cliente_proveedor.Length == 1 || _ruc_cliente_proveedor.Length == 13 || _ruc_cliente_proveedor.Length == 9)
            //{


                string cadena1 = _ruc_cliente_proveedor + "?" + _nombre_cliente_proveedor;

                string cadena2 = "_ruc_cliente_proveedor?_nombre_cliente_proveedor";
                string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";

                try
                {

                    int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_cliente_proveedor");


                    DataTable dtClienteProveedor = AccesoLogica.Select("id_cliente_proveedor", "cliente_proveedor", "rtrim(nombre_cliente_proveedor) = rtrim('" + _nombre_cliente_proveedor + "')   ");
                    int regID = dtClienteProveedor.Rows.Count;



                    if (regID > 0)
                    {
                        //ya existe

                        foreach (DataRow renglon in dtClienteProveedor.Rows)
                        {
                            _id_cliente_proveedor = Convert.ToInt32(renglon["id_cliente_proveedor"].ToString());
                        }
                    }


                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error en Cliente Proveedor");
                    SendError.EnviarErrorImportacion("Error al Cliente Proveedor: " + _ruc_cliente_proveedor + "  " + _nombre_cliente_proveedor, Ex.Message);
                }

            /*
            }
            else
            {
                Console.WriteLine("Error en Cliente Proveedor");
                SendError.EnviarErrorImportacion("Error al Cliente Proveedor CEDULA MAL ESCRITA : " + _ruc_cliente_proveedor + "  " + _nombre_cliente_proveedor, "");

            }
            */
            return _id_cliente_proveedor;

        }

        
        public static int insertaGarante(string _ruc_garante, string _nombre_garante)
        {
            int _id_garante = 1;

            ///buscamos si existe
            //if (_ruc_garante.Length == 1 ||  _ruc_garante.Length == 0 ||  _ruc_garante.Length == 10 || _ruc_garante.Length == 1 || _ruc_garante.Length == 13)
            //{


                string cadena1 = _ruc_garante + "?" + _nombre_garante;

                string cadena2 = "_ruc_garante?_nombre_garante";
                string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";

                try
                {

                    int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_garante");


                    DataTable dtgarante = AccesoLogica.Select("id_garante", "garante", "rtrim(nombre_garante) = rtrim('" + _nombre_garante + "')   ");
                    int regID = dtgarante.Rows.Count;



                    if (regID > 0)
                    {
                        //ya existe

                        foreach (DataRow renglon in dtgarante.Rows)
                        {
                            _id_garante = Convert.ToInt32(renglon["id_garante"].ToString());
                        }
                    }


                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error en garante");
                    SendError.EnviarErrorImportacion("Error al garante: " + _ruc_garante + "  " + _nombre_garante, Ex.Message);
                }

            /*
            }
            else
            {
                Console.WriteLine("Error en garante");
                SendError.EnviarErrorImportacion("Error al garante CEDULA MAL ESCRITA : " + _ruc_garante + "  " + _nombre_garante, "");

            }
            */
            return _id_garante;

        }





        public static int insertaCartonDocumentos(string _numero_carton_documentos)
        {
            int _id_carton_documentos = 0;

            ///buscamos si existe


        
            try
            {

                //int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_carton_documentos");
                
                DataTable dtCartonDocumentos = AccesoLogica.Select("id_carton_documentos", "carton_documentos", "rtrim(numero_carton_documentos) = rtrim('" + _numero_carton_documentos + "')   ");
                int regID = dtCartonDocumentos.Rows.Count;
               


                if (regID > 0)
                {
                    //ya existe

                    foreach (DataRow renglon in dtCartonDocumentos.Rows)
                    {
                        _id_carton_documentos = Convert.ToInt32(renglon["id_carton_documentos"].ToString());
                    }
                }


            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en Carton Documentos");
                SendError.EnviarErrorImportacion("Error al Buscar Carton Documentos : " + _numero_carton_documentos , Ex.Message);
            }
            return _id_carton_documentos;

        }





        public static int insertaTipoDocumento(string _nombre_tipo_documentos)
        {
            int _id_tipo_documentos = 0;
            
            ///buscamos si existe


            string cadena1 = _nombre_tipo_documentos;

            string cadena2 = "_nombre_tipo_documentos";
            string cadena3 = "NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_tipo_documentos");


                DataTable dtTipoDocumentos = AccesoLogica.Select("id_tipo_documentos", "tipo_documentos", " rtrim(nombre_tipo_documentos)  = rtrim('" + _nombre_tipo_documentos + "')   ");
                int regID = dtTipoDocumentos.Rows.Count;



                if (regID > 0)
                {
                    //ya existe

                    foreach (DataRow renglon in dtTipoDocumentos.Rows)
                    {
                        _id_tipo_documentos = Convert.ToInt32(renglon["id_tipo_documentos"].ToString());
                    }
                }


            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en Tipo Documentos" + _nombre_tipo_documentos);
                SendError.EnviarErrorImportacion("Error al Inserat tipo de documentos: " + _nombre_tipo_documentos, Ex.Message);

            }
            return _id_tipo_documentos;

        }

        public static int insertaSoat(string _cierre_ventas_soat)
        {
            int _id_soat = 0;

            ///buscamos si existe


            string cadena1 = _cierre_ventas_soat;

            string cadena2 = "_cierre_ventas_soat";
            string cadena3 = "NpgsqlDbType.Varchar";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_soat");


                DataTable dtSoat = AccesoLogica.Select("id_soat", "soat", "cierre_ventas_soat  = '" + _cierre_ventas_soat + "'   ");
                int regID = dtSoat.Rows.Count;



                if (regID > 0)
                {
                    //ya existe

                    foreach (DataRow renglon in dtSoat.Rows)
                    {
                        _id_soat = Convert.ToInt32(renglon["id_soat"].ToString());
                    }
                }


            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error en Tipo Documentos" + _cierre_ventas_soat);
                SendError.EnviarErrorImportacion("Error al Inserat tipo de documentos: " + _cierre_ventas_soat, Ex.Message);

            }
            return _id_soat;

        }



        public static int insertaDocumentoLegal(string _path_completo, int _id_lecturas, int _id_subcategorias, int _id_cliente_proveedor, int _id_tipo_documentos, int _id_carton_documentos, DateTime _fecha_documentos_legal, DateTime _fecha_desde_documentos_legal, DateTime _fecha_hasta_documentos_legal, string _ramo_documentos_legal, string _numero_poliza_documentos_legal, string _ciudad_emision_documentos_legal, int _id_soat, double _monto_solicitado, string _numero_credito_documentos_legal, int _id_garante, string _estado_documentos_legal, string _cheque_documentos_legal, string _valor_documentos_legal, int _etapa)
        {

            string _path_pdf_convertir = _path_completo.Replace(".XML", ".pdf");

            try
            {
                byte[] _archivo_documentos_legal = System.IO.File.ReadAllBytes(_path_pdf_convertir);



                int _paginas_documentos_legal = paginasPDF(_path_pdf_convertir);
                string _texto_documentos_legal = ""; //ocrPDF(_path_pdf_convertir).Substring(0, 30000).Trim();


                string cadena1 = _id_lecturas + "?" + _id_subcategorias + "?" + _id_cliente_proveedor + "?" + _id_tipo_documentos + "?" + _id_carton_documentos + "?" + _fecha_documentos_legal + "?" + _paginas_documentos_legal + "?" + _texto_documentos_legal + "?" + _fecha_desde_documentos_legal + "?" + _fecha_hasta_documentos_legal + "?" + _ramo_documentos_legal + "?" + _numero_poliza_documentos_legal + "?" + _ciudad_emision_documentos_legal + "?" + _id_soat + "?" + _monto_solicitado + "?" + _numero_credito_documentos_legal + "?" + _id_garante + "?" + _estado_documentos_legal + "?" + _cheque_documentos_legal + "?" + _valor_documentos_legal + "?" + _etapa;

                string cadena2 = "_id_lecturas?_id_subcategorias?_id_cliente_proveedor?_id_tipo_documentos?_id_carton_documentos?_fecha_documentos_legal?_paginas_documentos_legal?_texto_documentos_legal?_fecha_desde_documentos_legal?_fecha_hasta_documentos_legal?_ramo_documentos_legal?_numero_poliza_documentos_legal?_ciudad_emision_documentos_legal?_id_soat?_monto_documentos_legal?_numero_credito_documentos_legal?_id_garante?_estado_documentos_legal?_cheque_documentos_legal?_valor_documentos_legal?_etapa";

                string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Integer?NpgsqlDbType.Text?NpgsqlDbType.TimestampTZ?NpgsqlDbType.TimestampTZ?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Numeric?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer";

                try
                {

                    int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_documentos_legal");


                    DataTable dtDoc = AccesoLogica.Select("id_documentos_legal", "documentos_legal", " id_lecturas = '" + _id_lecturas + "'  ");
                    int _id_documentos_legal = 0;
                    int regDoc = dtDoc.Rows.Count;

                    if (regDoc > 0)
                    {
                        //ya existe

                        foreach (DataRow renglon in dtDoc.Rows)
                        {
                            _id_documentos_legal = Convert.ToInt32(renglon["id_documentos_legal"].ToString());
                        }

                        UpdateImagenLegal(_id_documentos_legal, _archivo_documentos_legal, _path_pdf_convertir, _id_lecturas);

                        AccesoLogica.Update("subcategorias", "lecturas_subcategorias = lecturas_subcategorias + 1 ", "id_subcategorias = '" + _id_subcategorias + "' ");



                        ResumenDiario._cantidad_doc += 1;
                        ResumenDiario._paginas_doc += _paginas_documentos_legal;


                    }



                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error en  Documentos Legal" + Ex.Message);

                    SendError.EnviarErrorImportacion("Problemas al insertar documentos_legal: " + _path_pdf_convertir, Ex.Message);

                }


                ///luego  guardamos las variables de resumen


            }
            catch (Exception Ex)
            {
                SendError.EnviarErrorImportacion("No Existe Este Archivo PDF: " + _path_pdf_convertir, Ex.Message);
            }

            return _id_tipo_documentos;






        }




        public static string ocrPDF(string _path_pdf)
        {
            string _ocrPdf = "";


            if (File.Exists(_path_pdf))
            {
                try
                {
                    StringBuilder text = new StringBuilder();
                    PdfReader pdfReader = new PdfReader(_path_pdf);
                    
                      
                    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                    {
                   
                        
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                        
                        var currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                       
                        currentText = Encoding.UTF8.GetString(Encoding.Convert(
                                            Encoding.Default,
                                            Encoding.UTF8,
                                            Encoding.Default.GetBytes(currentText)));

                        text.Append(currentText);
                       
                        
                        
                     
                    }

                    _ocrPdf = text.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en OCR: " + " ---> " +  _path_pdf   + ex.Message, "Error");
                    SendError.EnviarErrorImportacion("Error al hacer OCR de documento: " + _path_pdf, ex.Message);
                }
            }


            return _ocrPdf;
        
        
        }



        public static int paginasPDF(string _path_pdf)

        {
            int _paginasPDF = 0;


            if (File.Exists(_path_pdf))
            {
                try
                {
                    StringBuilder text = new StringBuilder();
                    PdfReader pdfReader = new PdfReader(_path_pdf);
                  
                    _paginasPDF = pdfReader.NumberOfPages;
                  Console.WriteLine("NUMERO DE PAGINA PDF: " + _paginasPDF + "  "+ _path_pdf );
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en numero de paginas PDF: " + ex.Message, "Error");
                }
            }


            return _paginasPDF;


        }




        private static byte[] PathToPDF(string _path)
        {
            string filename = _path;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] byteData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(byteData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return byteData; //return the byte data
        }
        



        public static void UpdateImagenLegal(int _id_documento_legal, byte[] _archivo_archivos_pdf, string _path_pdf_convertir, int _id_lecturas )
        {

            PonNumeros frm = new PonNumeros();

            

            NpgsqlCommand fun_archivo = new NpgsqlCommand("ins_archivo_pdf(:_id_documentos_legal, :_archivo_archivos_pdf)", Conexion.conn);
                fun_archivo.CommandType = CommandType.StoredProcedure;


                fun_archivo.Parameters.Add(new NpgsqlParameter(":_id_documentos_legal", NpgsqlDbType.Integer));
                fun_archivo.Parameters.Add(new NpgsqlParameter(":_archivo_archivos_pdf", NpgsqlDbType.Bytea));

                fun_archivo.Parameters[0].Value = _id_documento_legal;
                fun_archivo.Parameters[1].Value = _archivo_archivos_pdf; 

                try
                {
                    Conexion.conn.Open();
                    
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    
                    fun_archivo.ExecuteNonQuery();

                    Console.WriteLine("Subiendo Archivo: " + _path_pdf_convertir + " Tamaño: " + _archivo_archivos_pdf.Length / 1048576 + " MB");
                    
                    Conexion.conn.Close();


                    //actualizo estado en lecturas
                    AccesoLogica.Update("lecturas", "estado_lecturas = 'TRUE' ", "id_lecturas = '" + _id_lecturas + "' ");

                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error al subir la imagen " + Ex.Message);
                    SendError.EnviarErrorImportacion("Error al subir Imagen : " + _path_pdf_convertir, Ex.Message);
                    Conexion.conn.Close();

                }

            
        
        
        }

        







    }


}
