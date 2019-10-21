using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aDocumentRobot
{
    public class MyEvent : PdfPageEventHelper
    {

        Image image;

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            image = null;//Image.GetInstance(Server.MapPath("~/images/draft.png"));
            image.SetAbsolutePosition(12, 300);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            writer.DirectContent.AddImage(image);
        }
    }
}
