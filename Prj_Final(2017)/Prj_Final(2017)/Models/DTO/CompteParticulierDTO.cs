using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class CompteParticulierDTO {
        private int idparticulier;
        private int idpassword;
        private int idprenom;
        private string nom;
        private string courriel;

        public CompteParticulierDTO(int idparticulier, int idpassword, int idprenom, string nom, string courriel) {
            this.idparticulier = idparticulier;
            this.idpassword = idpassword;
            this.idprenom = idprenom;
            this.nom = nom;
            this.courriel = courriel;

        }

        public int Idparticulier {
            get { return idparticulier; }
            set { idparticulier = value; }
        }

        public int Idpassword {
            get { return idpassword; }
            set { idpassword = value; }
        }
        public int Idprenom {
            get { return idprenom; }
            set { idprenom = value; }
        }
        public string Nom {
            get { return nom; }
            set { nom = value; }
        }
        public string Courriel {
            get { return courriel; }
            set { courriel = value; }
        }
    }
}
