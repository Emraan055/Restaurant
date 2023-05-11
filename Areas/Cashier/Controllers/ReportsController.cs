using DataLayer.Context;
using iText.Html2pdf;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Font;
using System.IO;

using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using System.Text;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Html2pdf.Resolver.Font;

namespace Restaurant.Areas.Cashier.Controllers
{
    [Authorize(Roles = "Cashier")]
    public class ReportsController : Controller
    {
        RestaurantContext db = new RestaurantContext();
        /*
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HtmlToPDF(string htmlString)
        {
            
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = new PdfWriter(ms);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            Paragraph paragraph = new Paragraph();
            paragraph.SetFont(font);
            ConverterProperties properties = new ConverterProperties();
            properties.SetFontProvider(new DefaultFontProvider());
            properties.SetCreateAcroForm();
            HtmlConverter.ConvertToDocument(htmlString, document, properties);
            document.Close();
            byte[] pdfBytes = ms.ToArray();
            return File(pdfBytes, "application/pdf", "converted_document.pdf");
            
        }*/


        public ActionResult Foods()
        {
            var foods = db.Foods.ToList();
            return View(foods);
        }

        public ActionResult Categories()
        {
            var Categories = db.FoodCategories.ToList();
            return View(Categories);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }
        public ActionResult All()
        {


            var receipts = db.Receipts.ToList();
            return View("ShowReceipts", receipts);
        }

        // GET: Cashier/Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}