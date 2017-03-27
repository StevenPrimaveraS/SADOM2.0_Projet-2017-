using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class VoitureDTO {
        private int idVoiture;
        private string type;
        private int idAgence;
        private int tarif;
        private int nbpassager;
        private string nom;
        private string plaque;



        public VoitureDTO(int idVoiture, string type, int idAgence, int tarif, int nbpassager, string nom, string plaque) {
            this.idVoiture = idVoiture;
            this.type = type;
            this.idAgence = idAgence;
            this.tarif = tarif;
            this.nbpassager = nbpassager;
            this.nom = nom;
            this.plaque = plaque;

        }

        public int IdVoiture {
            get { return idVoiture; }
            set { idVoiture = value; }
        }
        public string Type {
            get { return type; }
            set { type = value; }
        }
        public int IdAgence {
            get { return idAgence; }
            set { idAgence = value; }
        }
        public int Tarif {
            get { return tarif; }
            set { tarif = value; }
        }
        public int Nbpassager {
            get { return nbpassager; }
            set { nbpassager = value; }
        }
        public String Nom {
            get { return nom; }
            set { nom = value; }
        }
        public string Plaque {
            get { return plaque; }
            set { plaque = value; }
        }

    }
}
