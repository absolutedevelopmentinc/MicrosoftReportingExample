using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using ReportingExample.Web.Services;

namespace ReportingExample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerService _customerService;

        public HomeController()
        {
            // NOTE: this would dependancy injected in the real world
            _customerService = new CustomerService();
        }

        public ActionResult Index()
        {
            var customers = _customerService.GetActiveCustomers();

            return View(customers);
        }

        public ActionResult Export(string reportType)
        {
            var customers = _customerService.GetActiveCustomers();

            Warning[] warnings;
            string mimeType;
            string[] streams;
            string encoding;
            string fileNameExtension;

            var viewer = new ReportViewer();

            viewer.LocalReport.ReportPath = Server.MapPath(@"/Reports/CustomerReport.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("CustomerDataset", customers));
            viewer.LocalReport.Refresh();

            var bytes = viewer.LocalReport.Render(reportType ?? "PDF", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            return File(bytes, mimeType, $"CustomerReport.{fileNameExtension}");
        }

        public string DeviceInfo(bool isPortrait)
        {
            // NOTE: something like this would be used on the .Render call in the real world
            var outputType = "PDF"; // assume PDF right now; other options "Excel", "Word", "Html"
            var pageWidth = isPortrait ? "8.5" : "11";
            var pageHeight = isPortrait ? "11" : "8.5";
            var deviceInfo = string.Format("<DeviceInfo>" +
                "  <OutputFormat>" + outputType + "</OutputFormat>" +
                "  <PageWidth>{0}in</PageWidth>" +
                "  <PageHeight>{1}in</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>0.25in</MarginLeft>" +
                "  <MarginRight>0.25in</MarginRight>" +
                "  <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>", pageWidth, pageHeight);

            return deviceInfo;
        }
    }
}