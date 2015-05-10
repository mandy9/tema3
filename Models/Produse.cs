using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace Tema2_MiniMagazin.Models
{
    public class Produse
    {

        public int ID { get; set; }
       
        
      
        public string NumeProdus { get; set; }

       
        public decimal Pret { get; set; }
    }
     
  
}