using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema2_MiniMagazin.Models;
using Tema2_MiniMagazin.ViewModels;
namespace Tema2_MiniMagazin.Controllers
{
    public class ShoppingCartController : Controller
    {

        ShopEntities storeDB = new ShopEntities();
        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {

            var addedProduct = storeDB.t
                .Single(produs => produs.ID == id);
                                
                
       
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedProduct);

       
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
       
            var cart = ShoppingCart.GetCart(this.HttpContext);

         
            string productName = storeDB.Carts
                .Single(item => item.ProdusId == id).Produse.NumeProdus;

     
            int itemCount = cart.RemoveFromCart(id);

       
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
      

    }
}
