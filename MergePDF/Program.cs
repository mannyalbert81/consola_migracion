using iTextSharp.text;
using iTextSharp.text.pdf;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace MergePDF
{
    class Program
    {
        static void Main(string[] args)
        {
            buscaCategoria();
            Console.WriteLine("***********************************************");
            Console.Read();

        }





        public static void buscaCategoria()
        {

            int _id_categorias = 0;
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
                    _path_categorias = renglon["path_categorias"].ToString();

                    DataTable dtSubCategorias = AccesoLogica.Select("id_subcategorias, id_categorias, nombre_subcategorias, path_subcategorias, lecturas_subcategorias, creado, modificado", "subcategorias", "id_categorias = '" + _id_categorias + "'  ");
                    int regSubCat = dtCategorias.Rows.Count;

                    if (regSubCat > 0)
                    {



                        foreach (DataRow renglonSub in dtSubCategorias.Rows)
                        {



                            _id_subcategorias = Convert.ToInt32(renglonSub["id_subcategorias"].ToString());
                            //creditos
                            if (_id_subcategorias == 37)
                            {


                                _nombre_subcategorias = renglonSub["nombre_subcategorias"].ToString();
                                _path_subcategorias = renglonSub["path_subcategorias"].ToString();
                                String _path_completo = _path_categorias + _path_subcategorias;
                                /*Console.WriteLine("Archivo ->" + _path_completo);
                                Console.WriteLine("Categoría -> " + _nombre_categorias);
                                Console.WriteLine("SubCategoría -> " + _nombre_subcategorias + " path -> " + _path_completo);
                                */
                                try
                                {
                                    buscaCredito2(_id_subcategorias);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error ->" + ex.Message);
                                    Console.Read();
                                }

                                

                            }

                            ///prestaciones
                            if (_id_subcategorias == 44)
                            {


                                _nombre_subcategorias = renglonSub["nombre_subcategorias"].ToString();
                                _path_subcategorias = renglonSub["path_subcategorias"].ToString();
                                String _path_completo = _path_categorias + _path_subcategorias;
                                
                                

                                try
                                {
                                    buscaPrestaciones2(_id_subcategorias);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error ->" + ex.Message);
                                    Console.Read();
                                }



                            }
                            if (_id_subcategorias == 58)
                            {


                                _nombre_subcategorias = renglonSub["nombre_subcategorias"].ToString();
                                _path_subcategorias = renglonSub["path_subcategorias"].ToString();
                                String _path_completo = _path_categorias + _path_subcategorias;

                                



                                try
                                {
                                    buscaPagares2(_id_subcategorias);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error ->" + ex.Message);
                                    Console.Read();
                                }



                            }


                        }


                    }


                }

            }



        }

        private static void buscaRegularizacion(int _id_subcategorias)
        {

            string _path_regularizacion = @"C:\regularizacion";
            string _nombre_regularizacion_archivo = "";
            string _path_pdf_regularizacion = "";

            try
            {

                DirectoryInfo directory = new DirectoryInfo(@_path_regularizacion);

                Console.WriteLine("Camino" + _path_regularizacion);
                FileInfo[] files = directory.GetFiles("*.pdf");


                DirectoryInfo[] directories = directory.GetDirectories();

                for (int i = 0; i < files.Length; i++)
                {
                    _path_pdf_regularizacion = ((FileInfo)files[i]).FullName;
                    _nombre_regularizacion_archivo = ((FileInfo)files[i]).Name.Replace(".pdf", "");
                    Console.WriteLine(_nombre_regularizacion_archivo);

                    Merge(_nombre_regularizacion_archivo, _id_subcategorias);
                    ///aqui debo leer contenido del xml
                    ///
                    Console.WriteLine("LEDIOS XML " + i);

                }


            }

            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());

            }



        }





        private static void buscaCredito2(int _id_subcategorias)
        {

            //string _path_regularizacion = @"C:\regularizacion";
            string _path_pdf_subcategoria = "";
            string _nombre_lecturas = "";
            string _nombre_pagina_agregar = @"C:\regularizacion\5.pdf";
            string _nombre_archivo_original_pdf = "";
            string _nombre_archivo_destino = "";
            string _path_categorias = "";
            string _path_subcategorias = "";
            int _id_lecturas = 0;
            int paginasBorrar = 1;

            try
            {
                DataTable dtLecturas = AccesoLogica.Select("lecturas.id_lecturas, categorias.path_categorias, subcategorias.path_subcategorias, lecturas.nombre_lecturas", "public.lecturas, public.subcategorias, public.categorias", "subcategorias.id_subcategorias = lecturas.id_subcategorias AND categorias.id_categorias = subcategorias.id_categorias AND lecturas.id_subcategorias = '" + _id_subcategorias + "' ORDER BY lecturas.nombre_lecturas ");
                int regReg = dtLecturas.Rows.Count;
                Console.WriteLine("REGISTROS EN LA CATEGORIA :" + regReg);
                if (regReg > 0)
                {

                    foreach (DataRow renglon in dtLecturas.Rows)
                    {
                        _path_categorias = renglon["path_categorias"].ToString();
                        _path_subcategorias = renglon["path_subcategorias"].ToString();
                        _nombre_lecturas = renglon["nombre_lecturas"].ToString();
                        _id_lecturas = Convert.ToInt32(renglon["id_lecturas"].ToString());

                        _nombre_archivo_original_pdf = _path_categorias + _path_subcategorias + @"\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        _nombre_archivo_destino = _path_categorias + _path_subcategorias + @"\procesados\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(_nombre_archivo_original_pdf);
                        Console.WriteLine("------------------------------------");

                        try
                        {
                            int paginasTotales = CountPageNo(_nombre_archivo_original_pdf);
                            int startPage = 1;
                            int endPage = paginasTotales - paginasBorrar;


                            ExtractPages(_nombre_archivo_original_pdf, _nombre_archivo_destino,
                                        startPage, endPage);

                            //string[] sourceFiles = new string[] { _nombre_archivo_original_pdf, _nombre_pagina_agregar };
                            //MergeFiles(_nombre_archivo_destino, sourceFiles);


                            AccesoLogica.Update("documentos_legal", "procesado = 'TRUE' ", " id_lecturas = '" + _id_lecturas + "'    ");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error en Archivo: " + _nombre_archivo_original_pdf + " Tipo: " + ex.Message);
                           // throw;
                        }



        }
    }



            }

            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());

            }



        }







        private static void buscaPrestaciones(int _id_subcategorias)
        {

            //string _path_regularizacion = @"C:\regularizacion";
            string _path_pdf_subcategoria = "";
            string _nombre_lecturas = "";
            string _nombre_pagina_agregar = @"C:\regularizacion\5.pdf";
            string _nombre_archivo_original_pdf = "";
            string _nombre_archivo_destino = "";
            string _path_categorias = "";
            string _path_subcategorias = "";
            int _id_lecturas = 0;

            try
            {
                DataTable dtLecturas = AccesoLogica.Select("lecturas.id_lecturas, categorias.path_categorias, subcategorias.path_subcategorias, lecturas.nombre_lecturas", "public.lecturas, public.subcategorias, public.categorias", "subcategorias.id_subcategorias = lecturas.id_subcategorias AND categorias.id_categorias = subcategorias.id_categorias AND lecturas.id_subcategorias = '" + _id_subcategorias + "' ");
                int regReg = dtLecturas.Rows.Count;
                if (regReg > 0)
                {

                    foreach (DataRow renglon in dtLecturas.Rows)
                    { 
                        _path_categorias = renglon["path_categorias"].ToString();
                        _path_subcategorias = renglon["path_subcategorias"].ToString();
                        _nombre_lecturas = renglon["nombre_lecturas"].ToString();
                        _id_lecturas = Convert.ToInt32( renglon["id_lecturas"].ToString());

                        _nombre_archivo_original_pdf = _path_categorias + _path_subcategorias + @"\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        _nombre_archivo_destino = _path_categorias + _path_subcategorias + @"\procesados\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(_nombre_archivo_original_pdf);
                        Console.WriteLine("------------------------------------");


                        string[] sourceFiles = new string[] { _nombre_archivo_original_pdf, _nombre_pagina_agregar };
                        MergeFiles(_nombre_archivo_destino, sourceFiles);

                        AccesoLogica.Update("documentos_legal", "procesado = 'TRUE' ", " id_lecturas = '" + _id_lecturas + "'    ");



                    }
                }

                

            }

            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());

            }



        }





        private static void buscaPrestaciones2(int _id_subcategorias)
        {

            //string _path_regularizacion = @"C:\regularizacion";
            string _path_pdf_subcategoria = "";
            string _nombre_lecturas = "";
            string _nombre_pagina_agregar = @"C:\regularizacion\5.pdf";
            string _nombre_archivo_original_pdf = "";
            string _nombre_archivo_destino = "";
            string _path_categorias = "";
            string _path_subcategorias = "";
            int _id_lecturas = 0;
            int paginasBorrar = 5;

            try
            {
                DataTable dtLecturas = AccesoLogica.Select("lecturas.id_lecturas, categorias.path_categorias, subcategorias.path_subcategorias, lecturas.nombre_lecturas", "public.lecturas, public.subcategorias, public.categorias", "subcategorias.id_subcategorias = lecturas.id_subcategorias AND categorias.id_categorias = subcategorias.id_categorias AND lecturas.id_subcategorias = '" + _id_subcategorias + "' ");
                int regReg = dtLecturas.Rows.Count;
                if (regReg > 0)
                {

                    foreach (DataRow renglon in dtLecturas.Rows)
                    {
                        _path_categorias = renglon["path_categorias"].ToString();
                        _path_subcategorias = renglon["path_subcategorias"].ToString();
                        _nombre_lecturas = renglon["nombre_lecturas"].ToString();
                        _id_lecturas = Convert.ToInt32(renglon["id_lecturas"].ToString());

                        _nombre_archivo_original_pdf = _path_categorias + _path_subcategorias + @"\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        _nombre_archivo_destino = _path_categorias + _path_subcategorias + @"\procesados\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(_nombre_archivo_original_pdf);
                        Console.WriteLine("------------------------------------");
                        try
                        {
                            int paginasTotales = CountPageNo(_nombre_archivo_original_pdf);
                            int startPage = 1;
                            int endPage = paginasTotales - paginasBorrar;


                            ExtractPages(_nombre_archivo_original_pdf, _nombre_archivo_destino,
                                        startPage, endPage);

                            //string[] sourceFiles = new string[] { _nombre_archivo_original_pdf, _nombre_pagina_agregar };
                            //MergeFiles(_nombre_archivo_destino, sourceFiles);


                            AccesoLogica.Update("documentos_legal", "procesado = 'TRUE' ", " id_lecturas = '" + _id_lecturas + "'    ");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error en Archivo: " + _nombre_archivo_original_pdf + " Tipo: " + ex.Message);
                            //throw;
                        }

                        


                    }
                }



            }

            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());

            }



        }







        private static void buscaPagares(int _id_subcategorias)
        {

            //string _path_regularizacion = @"C:\regularizacion";
            string _path_pdf_subcategoria = "";
            
            string _nombre_pagina_agregar = @"C:\regularizacion\3.pdf";
            string _nombre_archivo_original_pdf = "";
            string _nombre_archivo_destino = "";
            string _path_categorias = "";
            string _path_subcategorias = "";
            string _nombre_lecturas = "";
            int _id_lecturas = 0;

            try
            {
                DataTable dtLecturas = AccesoLogica.Select("lecturas.id_lecturas, categorias.path_categorias, subcategorias.path_subcategorias, lecturas.nombre_lecturas", "public.lecturas, public.subcategorias, public.categorias", "subcategorias.id_subcategorias = lecturas.id_subcategorias AND categorias.id_categorias = subcategorias.id_categorias AND lecturas.id_subcategorias = '" + _id_subcategorias + "' ");
                int regReg = dtLecturas.Rows.Count;
                if (regReg > 0)
                {

                    foreach (DataRow renglon in dtLecturas.Rows)
                    {
                        _path_categorias = renglon["path_categorias"].ToString();
                        _path_subcategorias = renglon["path_subcategorias"].ToString();
                        _nombre_lecturas = renglon["nombre_lecturas"].ToString();
                        _id_lecturas = Convert.ToInt32(renglon["id_lecturas"].ToString());

                        _nombre_archivo_original_pdf = _path_categorias + _path_subcategorias + @"\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        _nombre_archivo_destino = _path_categorias + _path_subcategorias + @"\procesados\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(_nombre_archivo_original_pdf);
                        Console.WriteLine("------------------------------------");

                        //int paginasTotales = CountPageNo(_nombre_archivo_original_pdf);


                        string[] sourceFiles = new string[] { _nombre_archivo_original_pdf, _nombre_pagina_agregar };
                        MergeFiles(_nombre_archivo_destino, sourceFiles);

                        AccesoLogica.Update("documentos_legal", "procesado = 'TRUE' ", " id_lecturas = '" + _id_lecturas + "'    ");



                    }
                }



            }

            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());

            }




        }




        private static void buscaPagares2(int _id_subcategorias)
        {

            //string _path_regularizacion = @"C:\regularizacion";
            string _path_pdf_subcategoria = "";

            
            string _nombre_archivo_original_pdf = "";
            string _nombre_archivo_destino = "";
            string _path_categorias = "";
            string _path_subcategorias = "";
            string _nombre_lecturas = "";
            int _id_lecturas = 0;
            int paginasBorrar = 3;

            try
            {
                DataTable dtLecturas = AccesoLogica.Select("lecturas.id_lecturas, categorias.path_categorias, subcategorias.path_subcategorias, lecturas.nombre_lecturas", "public.lecturas, public.subcategorias, public.categorias", "subcategorias.id_subcategorias = lecturas.id_subcategorias AND categorias.id_categorias = subcategorias.id_categorias AND lecturas.id_subcategorias = '" + _id_subcategorias + "' ");
                int regReg = dtLecturas.Rows.Count;
                if (regReg > 0)
                {

                    foreach (DataRow renglon in dtLecturas.Rows)
                    {
                        _path_categorias = renglon["path_categorias"].ToString();
                        _path_subcategorias = renglon["path_subcategorias"].ToString();
                        _nombre_lecturas = renglon["nombre_lecturas"].ToString();
                        _id_lecturas = Convert.ToInt32(renglon["id_lecturas"].ToString());

                        _nombre_archivo_original_pdf = _path_categorias + _path_subcategorias + @"\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        _nombre_archivo_destino = _path_categorias + _path_subcategorias + @"\procesados\" + _nombre_lecturas.Replace(".XML", ".pdf");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(_nombre_archivo_original_pdf);
                        Console.WriteLine("------------------------------------");
                        try
                        {
                            int paginasTotales = CountPageNo(_nombre_archivo_original_pdf);
                            int startPage = 1;
                            int endPage = paginasTotales - paginasBorrar;


                            ExtractPages(_nombre_archivo_original_pdf, _nombre_archivo_destino,
                                        startPage, endPage);

                            //string[] sourceFiles = new string[] { _nombre_archivo_original_pdf, _nombre_pagina_agregar };
                            //MergeFiles(_nombre_archivo_destino, sourceFiles);

                            AccesoLogica.Update("documentos_legal", "procesado = 'TRUE' ", " id_lecturas = '" + _id_lecturas + "'    ");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error en Archivo: " + _nombre_archivo_original_pdf + " Tipo: " + ex.Message);
                            //throw;
                        }



        }
    }



            }

            catch (Exception Ex)
            {

                Console.WriteLine(Ex.ToString());

            }




        }



        private static void Merge(string _nombre_regularizacion, int _id_subcategorias)
        {
            string _nombre_lecturas = "";
            string _path_categorias = "";
            string _path_subcategorias = "";
            string _nombre_archivo_original = "";
            string _nombre_archivo_original_pdf = "";
            int _id_documentos_legal = Convert.ToInt32(_nombre_regularizacion);
            string _nombre_pagina_agregar = "";
            string _nombre_regularizado_final = "";
            string columnas = "documentos_legal.id_documentos_legal, lecturas.nombre_lecturas, categorias.path_categorias, subcategorias.path_subcategorias";
            string tablas = "public.documentos_legal, public.lecturas, public.categorias, public.subcategorias";
            string where = "lecturas.id_lecturas = documentos_legal.id_lecturas AND subcategorias.id_categorias = categorias.id_categorias AND subcategorias.id_subcategorias = documentos_legal.id_subcategorias AND documentos_legal.id_documentos_legal = '" + _id_documentos_legal + "'  AND  documentos_legal.procesado =  'FALSE'     ";

            DataTable dtRegularizar = AccesoLogica.Select(columnas, tablas, where);
            int regReg = dtRegularizar.Rows.Count;
            if (regReg > 0)
            {

                foreach (DataRow renglonSub in dtRegularizar.Rows)
                {

                    _path_categorias = renglonSub["path_categorias"].ToString();
                    _path_subcategorias = renglonSub["path_subcategorias"].ToString();
                    _nombre_lecturas = renglonSub["nombre_lecturas"].ToString();
                    _nombre_archivo_original = _path_categorias + _path_subcategorias +@"\"+ _nombre_lecturas;

                    _nombre_archivo_original_pdf = _nombre_archivo_original.Replace(".XML", ".pdf");
                    _nombre_pagina_agregar = @"C:\regularizacion\" + _id_documentos_legal + ".pdf";
                    _nombre_regularizado_final = _path_categorias + _path_subcategorias + @"\procesados\" + _nombre_lecturas.Replace(".XML", ".pdf"); ;


                    //"id_documentos_legal = '" + _id_documentos_legal + "'  "
                    AccesoLogica.Update("documentos_legal", "procesado = 'TRUE' ", " id_documentos_legal = '" + _id_documentos_legal + "'    ");
                    
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine(_nombre_archivo_original_pdf);
                    Console.WriteLine(_nombre_pagina_agregar);
                    Console.WriteLine(_nombre_regularizado_final);
                    Console.WriteLine("------------------------------------------");
                    string[] sourceFiles = new string[] { _nombre_archivo_original_pdf, _nombre_pagina_agregar };
                    
                    
                    MergeFiles(_nombre_regularizado_final, sourceFiles);

                }
            }

        }



        private static void AddPages(string _nombre_regularizacion, int _id_subcategorias)
        {
            string _nombre_lecturas = "";
            string _path_categorias = "";
            string _path_subcategorias = "";
            string _nombre_archivo_original = "";
            string _nombre_archivo_original_pdf = "";
            int _id_documentos_legal = Convert.ToInt32(_nombre_regularizacion);
            string _nombre_pagina_agregar = "";
            string _nombre_regularizado_final = "";
            string columnas = "documentos_legal.id_documentos_legal, lecturas.nombre_lecturas, categorias.path_categorias, subcategorias.path_subcategorias";
            string tablas = "public.documentos_legal, public.lecturas, public.categorias, public.subcategorias";
            string where = "lecturas.id_lecturas = documentos_legal.id_lecturas AND subcategorias.id_categorias = categorias.id_categorias AND subcategorias.id_subcategorias = documentos_legal.id_subcategorias AND documentos_legal.id_documentos_legal = '" + _id_documentos_legal + "'  AND  documentos_legal.procesado =  'FALSE'     ";

            DataTable dtRegularizar = AccesoLogica.Select(columnas, tablas, where);
            int regReg = dtRegularizar.Rows.Count;
            if (regReg > 0)
            {

                foreach (DataRow renglonSub in dtRegularizar.Rows)
                {

                    _path_categorias = renglonSub["path_categorias"].ToString();
                    _path_subcategorias = renglonSub["path_subcategorias"].ToString();
                    _nombre_lecturas = renglonSub["nombre_lecturas"].ToString();

                    _nombre_archivo_original = _path_categorias + _path_subcategorias + @"\" + _nombre_lecturas;

                    _nombre_archivo_original_pdf = _nombre_archivo_original.Replace(".XML", ".pdf");
                    _nombre_pagina_agregar = @"C:\regularizacion\" + _id_documentos_legal + ".pdf";
                    _nombre_regularizado_final = _path_categorias + _path_subcategorias + @"\procesados\" + _nombre_lecturas.Replace(".XML", ".pdf"); ;


                    //"id_documentos_legal = '" + _id_documentos_legal + "'  "
                    AccesoLogica.Update("documentos_legal", "procesado = 'TRUE' ", " id_documentos_legal = '" + _id_documentos_legal + "'    ");

                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine(_nombre_archivo_original_pdf);
                    Console.WriteLine(_nombre_pagina_agregar);
                    Console.WriteLine(_nombre_regularizado_final);
                    Console.WriteLine("------------------------------------------");
                    string[] sourceFiles = new string[] { _nombre_archivo_original_pdf, _nombre_pagina_agregar };


                    MergeFiles(_nombre_regularizado_final, sourceFiles);

                }
            }

        }





        public static void MergeFiles(string destinationFile, string[] sourceFiles)
        {

            try
            {

                int f = 0;
                // we create a reader for a certain document
                PdfReader reader = new PdfReader(sourceFiles[f]);
                // we retrieve the total number of pages
                int n = reader.NumberOfPages;
                Console.WriteLine("There are " + n + " pages in the original file.");
                // step 1: creation of a document-object
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                // step 2: we create a writer that listens to the document
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));
                // step 3: we open the document
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;
                int rotation;
                // step 4: we add content
                while (f < sourceFiles.Length)
                {
                    int i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        page = writer.GetImportedPage(reader, i);
                        rotation = reader.GetPageRotation(i);
                        if (rotation == 90 || rotation == 270)
                        {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        }
                        else
                        {
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        }
                        //Console.WriteLine("Processed page " + i);
                    }
                    f++;
                    if (f < sourceFiles.Length)
                    {
                        reader = new PdfReader(sourceFiles[f]);
                        // we retrieve the total number of pages
                        n = reader.NumberOfPages;
                        Console.WriteLine("*********************************************");
                        Console.WriteLine("There are " + n + " pages in the original file.");
                    }
                }
                // step 5: we close the document
                document.Close();
            }
            catch (Exception e)
            {
                string strOb = e.Message;
                Console.WriteLine("************ERRORR***********************");
                Console.WriteLine(strOb);
                Console.WriteLine("************ERRORR***********************");


            }
        }

        public static int CountPageNo(string strFileName)
        {
            // we create a reader for a certain document
            PdfReader reader = new PdfReader(strFileName);
            // we retrieve the total number of pages
            return reader.NumberOfPages;
        }




        public static void ExtractPages(string sourcePdfPath, string outputPdfPath,
                                    int startPage, int endPage)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            try
            {
                // Intialize a new PdfReader instance with the contents of the source Pdf file:
                reader = new PdfReader(sourcePdfPath);

                // For simplicity, I am assuming all the pages share the same size
                // and rotation as the first page:
                sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));

                // Initialize an instance of the PdfCopyClass with the source 
                // document and an output file stream:
                pdfCopyProvider = new PdfCopy(sourceDocument,
                    new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                sourceDocument.Open();

                // Walk the specified range and add the page copies to the output file:
                for (int i = startPage; i <= endPage; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }






}
