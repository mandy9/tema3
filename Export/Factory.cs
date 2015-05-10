using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema2_MiniMagazin.Models;

namespace Tema2_MiniMagazin.Export
{
    public class Factory
    {
        public Exporter creare(String tip)
        {
            if (tip == "JSON")
            {
                return new JSONExporter();
            }

            if (tip == "CSV")
            {
                return new CSVExporter();
            }

            return null;
        }
    }
}