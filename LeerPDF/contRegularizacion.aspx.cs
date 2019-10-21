using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using Negocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

namespace LeerPDF
{
    public partial class contRegularizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_documentos_legal = 0;


            DataTable dtDoc = AccesoLogica.Select("id_documentos_legal", "documentos_legal", "id_subcategorias = '37' AND impreso = 'FALSE'  ");
            int regdtDoc = dtDoc.Rows.Count;

            if (regdtDoc > 0)
            {
                foreach (DataRow renglonSub in dtDoc.Rows)
                {

                    id_documentos_legal = Convert.ToInt32(renglonSub["id_documentos_legal"].ToString());

                    if (id_documentos_legal > 0)
                    {
                        Datas.dtRegularizacion dtInforme = new Datas.dtRegularizacion();
                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(" * ", "regularizacion", " id_documentos_legal = '" + id_documentos_legal + "'  ");

                        daInforme.Fill(dtInforme, "regularizacion");
                        int reg = dtInforme.Tables[1].Rows.Count;

                        Regularizacion ObjRep = new Regularizacion();

                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CrystalReportViewer1.ReportSource = ObjRep;
                        
                        ExportOptions objExOpt;

                        CrystalReportViewer1.ReportSource = ObjRep;
                        CrystalReportViewer1.DataBind();
                        // Get the report document

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        objDiskOpt.DiskFileName = @"c:\regularizacion\" + id_documentos_legal + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();


                        AccesoLogica.Update("documentos_legal", "impreso = 'TRUE' ", " id_documentos_legal = '" + id_documentos_legal + "'    "); 
                        CrystalReportViewer1.Dispose();
                        
                        ObjRep.Close();

                        ObjRep.Dispose();

                    }
                }
            }
            else
            {

        
            }
        }
        

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }
    }
}