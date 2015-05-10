using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema2_MiniMagazin.Models;

namespace Tema2_MiniMagazin.Controllers
{ 
    public class ProduseController : Controller
    {
        private ShopEntities db = new ShopEntities();

        //
        // GET: /Produse/

        public ViewResult Index()
        {
            return View(db.t.ToList());
        }

        //
        // GET: /Produse/Details/5

        public ViewResult Details(int id)
        {
            Produse produse = db.t.Find(id);
            return View(produse);
        }

        //
        // GET: /Produse/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Produse/Create

        [HttpPost]
        public ActionResult Create(Produse produse)
        {
            if (ModelState.IsValid)
            {
                db.t.Add(produse);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(produse);
        }
        
        //
        // GET: /Produse/Edit/5
 
        public ActionResult Edit(int id)
        {
            Produse produse = db.t.Find(id);
            return View(produse);
        }

        //
        // POST: /Produse/Edit/5

        [HttpPost]
        public ActionResult Edit(Produse produse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produse);
        }

        //
        // GET: /Produse/Delete/5
 
        public ActionResult Delete(int id)
        {
            Produse produse = db.t.Find(id);
            return View(produse);
        }

        //
        // POST: /Produse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Produse produse = db.t.Find(id);
            db.t.Remove(produse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}