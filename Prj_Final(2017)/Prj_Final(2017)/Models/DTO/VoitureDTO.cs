using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class VoitureDTO {

        public int IdVoiture { get; set; }

        public string Type { get; set; }

        public int IdAgence { get; set; }

        public double Tarif { get; set; }

        public int NbPassager { get; set; }

        public string Nom { get; set; }

        public string Plaque { get; set; }

    }
}
