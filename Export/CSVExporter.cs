using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Tema2_MiniMagazin.Models;


namespace Tema2_MiniMagazin.Export
{
     public class CSVExporter :  Exporter
    {
        ShopEntities storedb = new ShopEntities();

        public void exportProducts()
        {
     
           var produse = storedb.t.SqlQuery("SELECT * FROM Produses").ToList();

         
               foreach (var item in produse)
            {
                string ID_Product = item.ID.ToString();
                string Name_Product = item.NumeProdus;
                string Price_Product = item.Pret.ToString();


                string csvPath = "F:\\prodExportcsv.csv";

                if (!File.Exists(csvPath))
                {
                    File.Create(csvPath).Close();
                }

                   string ProductHeader = "Id" + "," + "Prod Name" + "," + "Prod Price";
                   
                   string[][] tabel = new string[][] { new string[] { ID_Product , Name_Product , Price_Product } };
              
              int l = tabel.GetLength(0);
               
                   StringBuilder csvContent = new StringBuilder();

                  
                   for (int i = 0; i < l; i++)
                   
                       csvContent.AppendLine(string.Join(" , ", tabel[i]));

                   File.AppendAllText(csvPath, csvContent.ToString());
               
            }
            

        }
    }
}
