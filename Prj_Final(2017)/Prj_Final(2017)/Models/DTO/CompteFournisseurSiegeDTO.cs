using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class CompteFournisseurSiegeDTO {
        private int idFournisseur;
        private string courriel;
        private string password;
        private int idCompagnieAerienne;

        public CompteFournisseurSiegeDTO(int idFournisseur, string courriel, string password, int idCompagnieAerienne) {
            this.idFournisseur = idFournisseur;
            this.courriel = courriel;
            this.password = password;
            this.idCompagnieAerienne = idCompagnieAerienne;
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
        public int IdCompagnieAerienne {
            get { return idCompagnieAerienne; }
            set { idCompagnieAerienne = value; }
        }

    }
}
