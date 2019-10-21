using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio;
using System.Data;

namespace aDocumentRobot
{
    public class ResumenInsertSend
    {


        public void InsertaResumen(int _documentos_resumen_diario , int _paginas_resumen_diario)
        {

            string cadena1 = _documentos_resumen_diario + "?" + _paginas_resumen_diario;

            string cadena2 = "_documentos_resumen_diario?_paginas_resumen_diario";
            string cadena3 = "NpgsqlDbType.Integer?NpgsqlDbType.Integer";

            try
            {

                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_resumen_diario");


                DataTable dtResumen = AccesoLogica.Select("SUM(paginas_documentos_legal) AS paginas, COUNT(paginas_documentos_legal) AS documentos ", "documentos_legal");

                int reg = dtResumen.Rows.Count;

                int _documentos_total = 0;
                int _paginas_total = 0;

                if (reg > 0)
                {
                    //ya existe

                    foreach (DataRow renglonID in dtResumen.Rows)
                    {
                        _documentos_total = Convert.ToInt32(renglonID["documentos"].ToString());
                        _paginas_total = Convert.ToInt32(renglonID["paginas"].ToString());
                    }
                }

                SendResumen(_documentos_resumen_diario, _paginas_resumen_diario, _documentos_total, _paginas_total);




            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error al insertar Resumen" + Ex.Message);
            }

        }


        public void SendResumen(int _documentos_hoy, int _paginas_hoy, int _documentos_totales, int _paginas_totales)
        {

            string _cliente = "CAPREMCI";
            
            string _destinatarioCC = "manuel@masoft.net";
            string _enviado_desde = "adoc@masoft.net";
            string _enviado_desde_pass = "Adoc2015";
            string _cliente_host = "smtp.ipage.com";
            string _asunto = "- Nuevo Reporte aDocument  - "+_cliente+"";
            //"vilcabamba.yamburara.net";

            //if (_email_destinatario.Length > 0)
            


                
                string _texto = "";

                StringBuilder myBuilder = new StringBuilder();

                myBuilder.Append("<h2>Resumen Enviado Desde aDocument "+_cliente+" </h2>");

                myBuilder.Append("<p> Recuerda que toda esta documentacion importada puedes verla desde http://186.4.241.148:4001/capremci/ </p>");
                myBuilder.Append("<p> Resumen del Día <strong> "+ DateTime.Now +" </strong>  </p>");
                myBuilder.Append("<ul> <li>Archivos Digitalizados Hoy: <strong>" + _documentos_hoy + "</strong> </li>");
                myBuilder.Append("     <li>Páginas  Digitalizadas Hoy: <strong>" + _paginas_hoy + " </strong> </li> </ul>");
                myBuilder.Append("<HR > ");
                myBuilder.Append("<p> Resumen  <strong> GENERAL </strong>  </p>");
                myBuilder.Append("<ul> <li>Total Archivos Digitalizados: <strong>" + _documentos_totales + "</strong> </li>");
                myBuilder.Append("     <li>Total Páginas  Digitalizadas: <strong>" + _paginas_totales + " </strong> </li> </ul>");
                

                myBuilder.Append(" ");
                myBuilder.Append(" ");
                myBuilder.Append("<HR > ");
                myBuilder.Append("<p>  ----> Este Mensaje ha sigo generado por el Sistema de Gestion Documental aDocument <--- </p>");
              
                         _texto = myBuilder.ToString();




                /*-------------------------MENSAJE DE CORREO----------------------*/

                //Creamos un nuevo Objeto de mensaje
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                //Direccion de correo electronico a la que queremos enviar el mensaje
                mmsg.To.Add("desarrollo@masoft.net");
            
                /*mmsg.To.Add("ysalas@papertec.com.ec");
                mmsg.To.Add("ajacome@papertec.com.ec");
                 * 
                 * */
                
                mmsg.To.Add("gerencia@digitalworld.ec");
                
                //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

                //Asunto
                mmsg.Subject = _asunto;
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                //Direccion de correo electronico que queremos que reciba una copia del mensaje
                mmsg.Bcc.Add(_destinatarioCC); //Opcional

                //Cuerpo del Mensaje
                mmsg.Body = _texto;

                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

                //Correo electronico desde la que enviamos el mensaje
                mmsg.From = new System.Net.Mail.MailAddress(_enviado_desde);


                /*-------------------------CLIENTE DE CORREO----------------------*/

                //Creamos un objeto de cliente de correo
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                //Hay que crear las credenciales del correo emisor
                cliente.Credentials =
                    new System.Net.NetworkCredential(_enviado_desde, _enviado_desde_pass);

                cliente.Port = 587;

                //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
                /*
                
                cliente.EnableSsl = true;
                */

                cliente.Host = _cliente_host; //Para Gmail "smtp.gmail.com";


                /*-------------------------ENVIO DE CORREO----------------------*/

                try
                {
                    //Enviamos el mensaje      
                    cliente.Send(mmsg);
                }
                catch (System.Net.Mail.SmtpException)
                {
                    Console.WriteLine("No se Pudo enviar el Correo ");
                }

                //return _error;
            

        
        
        }
    }
}
