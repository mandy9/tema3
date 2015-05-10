using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Tema2_MiniMagazin.Models
{
    public class Cart
    {
        public string CartId { get; set; }
        public int ProdusId { get; set; }
        public string NameId { get; set; }
        public decimal PretId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; } 
        public virtual Produse Produse { get; set; }
    }

  
}