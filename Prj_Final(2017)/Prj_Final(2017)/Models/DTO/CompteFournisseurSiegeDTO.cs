using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class CompteFournisseurSiegeDTO {
       
        public int IdFournisseur { get; set; }

        public string Courriel { get; set; }

        public string Password { get; set; }

        public int IdCompagnieAerienne { get; set; }

    }
}
