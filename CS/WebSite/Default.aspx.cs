using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page
{
  
    protected void Save_Click(object sender, EventArgs e)
    {
        WriteToPdfOnServer();
    }

    private void WriteToPdfOnServer()
    {
        string path = GetPath();
        using (StreamWriter sr = new StreamWriter(path))
        {
            Exporter.WritePdf(sr.BaseStream);
        }        
    }
    private string GetPath()
    {
        string dirpath = Server.MapPath("~/App_Data");
        string filename = String.Format("{0}.pdf", ASPxGv.ID);
        string path = Path.Combine(dirpath, filename);
        return path;
    }
    protected void Export_Click(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + ASPxGv.ID + ".pdf");
        Response.ContentType = "application/pdf";
        byte[] bytes = File.ReadAllBytes(GetPath());
        Response.BinaryWrite(bytes);
        Response.Flush();
    }
}