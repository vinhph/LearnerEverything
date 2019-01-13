using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsingAutofac.MVC.Example.Models;

namespace UsingAutofac.MVC.Example.Controllers
{
    public class HomeController : Controller
    {
        //setup autofac
        private ILog _log;
        //setup autofac phai co contractor
        public HomeController(ILog log)
        {
            _log = log;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.LogString = _log.PrintLog("ahihi");
            return View();
        }
    }
}