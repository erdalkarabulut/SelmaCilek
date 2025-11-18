using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml;
using System.Xml.Xsl;
using Bps.Core.Response;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using GridView = System.Web.UI.WebControls.GridView;

namespace Bps.Core.Web.Controller
{
    public class UnsecureController : System.Web.Mvc.Controller
    {
        //protected void Export(string data, string format, string title)
        //{
        //    //SubmitHandler submitData = new SubmitHandler(data);
        //    //XmlNode xml = submitData.Xml;
        //    StoreSubmitDataEventArgs eSubmit = new StoreSubmitDataEventArgs(data, null);
        //    XmlNode xml = eSubmit.Xml;
        //    Response.Clear();

        //    switch (format)
        //    {
        //        case "xml":
        //            string strXml = xml.OuterXml;
        //            Response.AddHeader("Content-Disposition", "attachment; filename=" + title + ".xml");
        //            Response.AddHeader("Content-Length", strXml.Length.ToString());
        //            Response.ContentType = "application/xml";
        //            Response.Write(strXml);
        //            break;

        //        case "xls":
        //            StringWriter stringWrite = new System.IO.StringWriter();
        //            XslCompiledTransform xtExcel = new XslCompiledTransform();
        //            xtExcel.Load(Server.MapPath("~/Assets/Exports/Excel.xsl"));
        //            xtExcel.Transform(xml, null, stringWrite);

        //            Response.ContentType = "application/vnd.ms-excel";
        //            Response.Buffer = true;
        //            Response.Charset = "UTF-8";
        //            Response.AddHeader("Content-Disposition", "attachment; filename=Deneme.xls");
        //            Response.ContentEncoding = System.Text.Encoding.UTF8;
        //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //            Response.Write(stringWrite.ToString());

        //            Response.Flush();
        //            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
        //            break;

        //        case "csv":
        //            Response.ContentType = "application/octet-stream";
        //            Response.AddHeader("Content-Disposition", "attachment; filename=" + title + ".csv");
        //            XslCompiledTransform xtCsv = new XslCompiledTransform();
        //            xtCsv.Load(Server.MapPath("~/Assets/Exports/Csv.xsl"));
        //            xtCsv.Transform(xml, null, Response.OutputStream);
        //            break;

        //        case "pdf":
        //            using (XmlNodeReader XNR = new XmlNodeReader(xml))
        //            {
        //                using (DataSet DS = new DataSet())
        //                {
        //                    DS.ReadXml(XNR);

        //                    using (GridView GridView1 = new GridView())
        //                    {
        //                        GridView1.AllowPaging = false;
        //                        GridView1.DataSource = DS.Tables[0];
        //                        GridView1.DataBind();

        //                        Response.ContentType = "application/pdf";
        //                        Response.AddHeader("content-disposition", "attachment;filename=" + title + ".pdf");
        //                        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //                        using (StringWriter SW = new StringWriter())
        //                        {
        //                            using (HtmlTextWriter hw = new HtmlTextWriter(SW))
        //                            {
        //                                GridView1.RenderControl(hw);

        //                                using (StringReader sr = new StringReader(SW.ToString()))
        //                                {
        //                                    using (Document D = new Document(PageSize.A4, 10f, 10f, 10f, 0f))
        //                                    {
        //                                        using (var HW = new HTMLWorker(D))
        //                                        {
        //                                            using (PdfWriter.GetInstance(D, Response.OutputStream))
        //                                            {
        //                                                D.Open();
        //                                                HW.Parse(sr);
        //                                                D.Close();
        //                                                Response.Write(D);
        //                                            }
        //                                        };
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            break;

        //        case "doc":
        //            using (XmlNodeReader XNR = new XmlNodeReader(xml))
        //            {
        //                using (DataSet DS = new DataSet())
        //                {
        //                    DS.ReadXml(XNR);

        //                    using (GridView GridView1 = new GridView())
        //                    {
        //                        GridView1.AllowPaging = false;
        //                        GridView1.DataSource = DS.Tables[0];
        //                        GridView1.DataBind();

        //                        Response.ContentType = "application/vnd.ms-word";
        //                        Response.AddHeader("content-disposition", "attachment;filename=" + title + ".doc");
        //                        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //                        using (StringWriter SW = new StringWriter())
        //                        {
        //                            using (HtmlTextWriter HW = new HtmlTextWriter(SW))
        //                            {
        //                                GridView1.RenderControl(HW);
        //                                Response.Write(SW.ToString());
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            break;
        //    }
        //    Response.End();
        //}
    }
}