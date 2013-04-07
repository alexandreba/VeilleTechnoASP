using SampleLog.Provider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            Trace.Write("Hey, this is nice");
            Trace.TraceWarning("Oh, this could be bad.");
            return View();
        }

        [CryptoValueProvider]
        public ActionResult About(int id)
        {
            ViewBag.Message = "Your app description page.";
            Trace.TraceError("Oh, no! That's bad");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Exception ex = new Exception("error on the contact action");
            throw ex;
            //return View();
        }
    }
}
