using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.Models.DTO
{
    public class PanierDTO
    {
        public int IdPanier { get; set; }

        public string Information { get; set; }

        public Double Prix { get; set; }

        public int Quantite { get; set; }
    }
}