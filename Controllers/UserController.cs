using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema2_MiniMagazin.Models;
using Tema2_MiniMagazin.ViewModels;

namespace Tema2_MiniMagazin.Controllers
{ 
    public class UserController : Controller
    {
        private ShopEntities db = new ShopEntities();

        //
        // GET: /User/

        public ViewResult Index()
        {
            return View(db.t.ToList());
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
        {
           
            Produse produse = db.t.Find(id);
            return View(produse);
        }



        public ViewResult Succes()
        {
           return View();
        }
     

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}