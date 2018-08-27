using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> IndexAsynchronous()
        {
            var beginTime = DateTime.Now;
            var htmlDownload = new HTMLDownload();
            var page1 = htmlDownload.GetHTML(1);
            var page2 = htmlDownload.GetHTML(2);
            var page3 = htmlDownload.GetHTML(3);

            await Task.WhenAll(page1, page2, page3);

            var htmlReturn = page1.Result;
            htmlReturn += page2.Result;
            htmlReturn += page3.Result;

            var duringTime = (DateTime.Now - beginTime).TotalMilliseconds;
            ViewBag.HtmlReturn = htmlReturn + $" Execute Time in: {duringTime}";

            return View("Index");
        }

        public ActionResult Index()
        {
            var beginTime = DateTime.Now;
            var htmlDownload = new HTMLDownload();
            var page1 = htmlDownload.GetHTML(1);
            var page2 = htmlDownload.GetHTML(2);
            var page3 = htmlDownload.GetHTML(3);

            var htmlReturn = page1.Result;
            htmlReturn += page2.Result;
            htmlReturn += page3.Result;

            var duringTime = (DateTime.Now - beginTime).TotalMilliseconds;
            ViewBag.HtmlReturn = htmlReturn + $" Execute Time in: {duringTime}";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}