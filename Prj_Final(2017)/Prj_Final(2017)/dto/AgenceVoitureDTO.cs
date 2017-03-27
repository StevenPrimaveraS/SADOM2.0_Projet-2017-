using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.dto
{
    public class AgenceVoitureDTO
    {
        private int idAgenceVoiture;
        private string nom;
        private string telephone;
        private string adresse;
        private string ville;
        private string aeroport;
        

        public AgenceVoitureDTO(int idAgenceVoiture, string nom, string telephone, string adresse, string ville, string aeroport)
        {
            this.idAgenceVoiture = idAgenceVoiture;
            this.nom = nom;
            this.telephone = telephone;
            this.adresse = adresse;
            this.ville = ville;
            this.aeroport = aeroport;
        }

        public int IdAgenceVoiture
        {
            get { return idAgenceVoiture; }
            set { idAgenceVoiture = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }
        public string Aeroport
        {
            get { return aeroport; }
            set { aeroport = value; }
        }
    }
}