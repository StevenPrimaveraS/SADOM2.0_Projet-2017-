using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class VolDTO {
        private int idVol;
        private string aeroportDepart;
        private string aeroportDestination;
        private string villeDepart;
        private string villeDestination;
        private string dateDepart;
        private string dateArrivee;
        private int idCompagnieAerienne;
        private string classe;
        private Boolean isRemboursable;
        private int tarif;


        public VolDTO(int idVol, string aeroportDepart, string aeroportDestination, string villeDepart, string villeDestination, string dateDepart, string dateArrivee, int idCompagnieAerienne, string classe, Boolean isRemboursable, int tarif) {
            this.idVol = idVol;
            this.aeroportDepart = aeroportDepart;
            this.aeroportDestination = aeroportDestination;
            this.villeDepart = villeDepart;
            this.villeDestination = villeDestination;
            this.dateDepart = dateDepart;
            this.dateArrivee = dateArrivee;
            this.idCompagnieAerienne = idCompagnieAerienne;
            this.classe = classe;
            this.isRemboursable = isRemboursable;
            this.tarif = tarif;
        }

        public int IdVol {
            get { return idVol; }
            set { idVol = value; }
        }

        public string AeroportDepart {
            get { return aeroportDepart; }
            set { aeroportDepart = value; }
        }

        public string AeroportDestination {
            get { return aeroportDestination; }
            set { aeroportDestination = value; }
        }
        public string VilleDepart {
            get { return villeDepart; }
            set { villeDepart = value; }
        }
        public string VilleDestination {
            get { return villeDestination; }
            set { villeDestination = value; }
        }
        public string DateDepart {
            get { return dateDepart; }
            set { dateDepart = value; }
        }
        public string DateArrivee {
            get { return dateArrivee; }
            set { dateArrivee = value; }
        }
        public int IdCompagnieAerienne {
            get { return idCompagnieAerienne; }
            set { idCompagnieAerienne = value; }
        }
        public string Classe {
            get { return classe; }
            set { classe = value; }
        }
        public Boolean IsRemboursable {
            get { return isRemboursable; }
            set { isRemboursable = value; }
        }
        public int Tarif {
            get { return tarif; }
            set { tarif = value; }
        }
    }
}
