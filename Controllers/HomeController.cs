using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema2_MiniMagazin.Export;
namespace Tema2_MiniMagazin.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to The Little Cake Shop!";

            return View();
        }


        public ActionResult About()
        {
            return View();
        }


       
        public ActionResult Export()
       
        {
            return View();
        }

        
     
        public ActionResult ButonExport()
       
        {
            string tt = Request.Form["txtTYPE"];
            
            Factory f = new Factory();
            Exporter e = f.creare(tt);

            e.exportProducts();

            return RedirectToAction("Export", "Home");
        }

    }
}
