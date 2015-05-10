using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Tema2_MiniMagazin.Models;
using System.Data.Entity;
using System.Configuration;
using System.IO;

namespace Tema2_MiniMagazin.Export
{
    public class JSONExporter : Exporter
    {
        ShopEntities storedb = new ShopEntities();
         
        public void exportProducts()
        {
           
            List<Produse> prod= new List<Produse>();

            var produse = storedb.t.SqlQuery("SELECT * FROM Produses").ToList();

            foreach (var item in produse)
            {
                int id = item.ID;
                string name = item.NumeProdus;
                decimal price = item.Pret;
               
     Produse p = new Produse();
                
                p.ID = id;
                p.NumeProdus = name;
                p.Pret = price;
               
     prod.Add(p);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(prod);
        
            string jsonPath = "F:\\prodExportjson.json";

            if (!File.Exists(jsonPath))
            {
                File.Create(jsonPath).Close();
            }

            File.AppendAllText(jsonPath, json.ToString());


        }
    }

}