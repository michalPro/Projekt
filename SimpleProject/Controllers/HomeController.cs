using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleProject.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
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

        [HttpGet]
        public ActionResult Test1(int id)
        {
            return Json(new { body = RenderRazorViewToString("Test1", id) }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Test2(int id)
        {
            return Json(new { body = RenderRazorViewToString("Test2", id)}, JsonRequestBehavior.AllowGet);
        }

    }
}