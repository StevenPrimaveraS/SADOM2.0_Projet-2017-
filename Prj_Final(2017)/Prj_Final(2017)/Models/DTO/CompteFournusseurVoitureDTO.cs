using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class CompteFournisseurVoitureDTO {
        private int idFournisseur;
        private string courriel;
        private string password;
        private int idAgenceVoiture;

        public CompteFournisseurVoitureDTO(int idFournisseur, string courriel, string password, int idAgenceVoiture) {
            this.idFournisseur = idFournisseur;
            this.courriel = courriel;
            this.password = password;
            this.idAgenceVoiture = idAgenceVoiture;
        }


        public int IdFournisseur {
            get { return idFournisseur; }
            set { idFournisseur = value; }
        }
        public string Courriel {
            get { return courriel; }
            set { courriel = value; }
        }
        public string Password {
            get { return password; }
            set { password = value; }
        }
        public int IdAgenceVoiture {
            get { return idAgenceVoiture; }
            set { idAgenceVoiture = value; }
        }
    }
}
