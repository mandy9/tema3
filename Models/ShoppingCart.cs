using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tema2_MiniMagazin.Models
{
    public partial class ShoppingCart
    {

        ShopEntities storeDB = new ShopEntities();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        
        
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }


        public void AddToCart(Produse produs)
        {
           
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProdusId == produs.ID
                && c.NameId==produs.NumeProdus
                && c.PretId==produs.Pret
                );
           
            if (cartItem == null)
            {
              
                cartItem = new Cart
                {
                    ProdusId = produs.ID,
                    NameId=produs.NumeProdus,
                    PretId=produs.Pret,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.Carts.Add(cartItem);
            }
            else
            {
          
                cartItem.Count++;
            }
       
            storeDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
          
            var cartItem = storeDB.Carts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.ProdusId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }
              
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
       
            storeDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return storeDB.Carts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }


        public int GetCount()
        {
          
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
         
            return count ?? 0;
        }

         public decimal GetTotal()
        {
       
            decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.CartId== ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.Produse.Pret).Sum();

            return total ?? decimal.Zero;
        }


         public string GetCartId(HttpContextBase context)
         {
             if (context.Session[CartSessionKey] == null)
             {
                 if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                 {
                     context.Session[CartSessionKey] =
                         context.User.Identity.Name;
                 }
                 else
                 {
                  
                     Guid tempCartId = Guid.NewGuid();
                  
                     context.Session[CartSessionKey] = tempCartId.ToString();
                 }
             }
             return context.Session[CartSessionKey].ToString();
         }



    }
}