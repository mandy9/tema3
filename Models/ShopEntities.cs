using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Tema2_MiniMagazin.Models
{
    public class ShopEntities : DbContext
    {
        public DbSet<Produse>     t  { get; set; }
        public DbSet<Cart>        Carts { get; set; }
     
    }
}