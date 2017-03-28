using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO
{
    public class ChambreDTO
    {

        public int IdChambre { get; set; }

        public int NumeroChambre { get; set; }

        public string NomChambre { get; set; }

        public int Tarif { get; set; }

        public int MaxPersonne { get; set; }

        public int Taille { get; set; }

        public string Description { get; set; }

        public int IdHotel { get; set; }
    }
}
