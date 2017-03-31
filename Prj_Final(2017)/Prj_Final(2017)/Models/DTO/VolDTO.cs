using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class VolDTO {

        public int IdVol { get; set; }

        public string AeroportDepart { get; set; }

        public string AeroportDestination { get; set; }

        public string VilleDepart { get; set; }

        public string VilleDestination { get; set; }

        public DateTime DateDepart { get; set; }

        public DateTime DateArrivee { get; set; }

        public int IdCompagnieAerienne { get; set; }

        public string Classe { get; set; }

        public bool IsRemboursable { get; set; }

        public int Tarif { get; set; }
    }
}
