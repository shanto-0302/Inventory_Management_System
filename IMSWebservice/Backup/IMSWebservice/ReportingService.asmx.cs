using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace IMSWebservice
{
    /// <summary>
    /// Summary description for ReportingService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ReportingService : System.Web.Services.WebService
    {

        [WebMethod]
        public Document GetCashMemo(String ProductName, String QuantityStr, String ProductScale, String ProductPriceStr, String CustomerName, String outputFile)
        {
           
            Document doc = new Document();
           
            PdfPTable tableLayout = new PdfPTable(5);
            String outFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), outputFile);
           
            
            PdfWriter.GetInstance(doc, new FileStream(outFile, FileMode.Create, FileAccess.Write));

            
            doc.Open();


            doc.Add(CreatePDF(tableLayout, ProductName, QuantityStr, ProductScale, ProductPriceStr, CustomerName));

            
            doc.Close();
           

            return doc;
        }

        private PdfPTable CreatePDF(PdfPTable tableLayout, String ProductName, String QuantityStr, String ProductScale, String ProductPriceStr, String CustomerName)
        {
            float[] headers = { 20, 20, 20, 30, 30 };  //Header Widths
            tableLayout.SetWidths(headers);        //Set the pdf headers
            tableLayout.WidthPercentage = 60;       //Set the PDF File witdh percentage

            float price = (float)Convert.ToDouble(ProductPriceStr);
            int quantity = Convert.ToInt32(QuantityStr);
            float totalPrice = price * quantity;

            String SerialNo = DateTime.Now.ToString("yyMMddHHmms");
            //Add Title to the PDF file at the top
            tableLayout.AddCell(new PdfPCell(new Phrase("UNIQUE", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 13, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 5, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER });

            tableLayout.AddCell(new PdfPCell(new Phrase("Address 1: SK HALL, DU", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 5, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER });
            tableLayout.AddCell(new PdfPCell(new Phrase("Address 2: FH HALL, DU", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 5, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER });
            tableLayout.AddCell(new PdfPCell(new Phrase("Phone No. 01784496371, Email: bit0312@iit.du.ac.bd", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 10, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 5, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER });
            tableLayout.AddCell(new PdfPCell(new Phrase("CASH MEMO", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 15, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 5, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER });
            tableLayout.AddCell(new PdfPCell(new Phrase("Serial No. " + SerialNo + "                                                             Date: " + DateTime.Now.ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 5, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_LEFT });
            tableLayout.AddCell(new PdfPCell(new Phrase("Customer Name: " + CustomerName, new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 5, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_LEFT });
            
            //Add header
            AddCellToHeader(tableLayout, "QUANTITY");
            AddCellToHeader(tableLayout, "Scale");
            AddCellToHeader(tableLayout, "RATE");
            AddCellToHeader(tableLayout, "DESCRIPTION");
            AddCellToHeader(tableLayout, "TOTAL");

            //Add body
            AddCellToBody(tableLayout, QuantityStr);
            AddCellToBody(tableLayout, ProductScale);
            AddCellToBody(tableLayout, ProductPriceStr);
            AddCellToBody(tableLayout, ProductName);
            AddCellToBody(tableLayout, totalPrice.ToString());

            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");

            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");

            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, "");


            tableLayout.AddCell(new PdfPCell(new Phrase("Amount in Word:______________________________ " + " G.Total:             " + totalPrice.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 5, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_LEFT });
            tableLayout.AddCell(new PdfPCell(new Phrase("SIGN: ________________________", new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 5, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
            
            return tableLayout;

        }

        // Method to add single cell to the header
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8, 1, iTextSharp.text.Color.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5, BackgroundColor = new iTextSharp.text.Color(0, 51, 102) });
        }

        // Method to add single cell to the body
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8, 1, iTextSharp.text.Color.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5, BackgroundColor = iTextSharp.text.Color.WHITE });
        }
    }
}
