using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.Models.DTO {
    public class CompagnieAerienneDTO {
        private int idCompagnieAerienne;
        private string nom;
        private string telephone;
        private string adresse;
        private string ville;

        public CompagnieAerienneDTO(int idCompagnieAerienne, string nom, string telephone, string adresse, string ville) {
            this.idCompagnieAerienne = idCompagnieAerienne;
            this.nom = nom;
            this.telephone = telephone;
            this.adresse = adresse;
            this.ville = ville;
        }

        public int IdCompagnieAerienne {
            get { return idCompagnieAerienne; }
            set { idCompagnieAerienne = value; }
        }
        public string Nom {
            get { return nom; }
            set { nom = value; }
        }

        public string Telephone {
            get { return telephone; }
            set { telephone = value; }
        }
        public string Adresse {
            get { return adresse; }
            set { adresse = value; }
        }
        public string Ville {
            get { return ville; }
            set { ville = value; }
        }

    }
}