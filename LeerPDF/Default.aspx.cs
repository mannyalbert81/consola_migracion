using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

using System.Data;

namespace LeerPDF
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String id_documentos_legal = Request.QueryString["id"];
            if (id_documentos_legal != "")
            {

                byte[] _pdf = null;

                DataTable dt = AccesoLogica.Select("archivo_archivos_pdf", "archivos_pdf", "id_documentos_legal = '"+id_documentos_legal +"'   ");
                int _registros = dt.Rows.Count;
                if (_registros > 0)
                {
                    foreach (DataRow renglon in dt.Rows)
                    {

                        _pdf = (byte[])renglon["archivo_archivos_pdf"];

                    }

                }


                StreamByteToPDF(_pdf);
            }
        }


        private void StreamByteToPDF(byte[] byteData)
        {
            string filen = Convert.ToString(DateTime.Now);
            string filename = @"C:\temp\archivo.pdf";
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);

            //Read block of bytes from stream into the byte array
            fs.Write(byteData, 0, byteData.Length);
            

            Response.ContentType = "application/pdf";

            Response.AddHeader("content-length", byteData.Length.ToString());

            Response.BinaryWrite(byteData);



            //Close the File Stream
            fs.Close();

        }





    }
}