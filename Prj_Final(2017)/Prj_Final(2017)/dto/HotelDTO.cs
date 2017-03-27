using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.dto
{
    public class HotelDTO
    {
        private int idHotel;
        private string nom;
        private string telephone;
        private string adresse;
        private string ville;
        private string categorie;
        private string description;

        public HotelDTO(int idHotel, string nom, string telephone, string adresse, string ville, string categorie, string description)
        {
            this.idHotel = idHotel;
            this.nom = nom;
            this.telephone = telephone;
            this.adresse = adresse;
            this.ville = ville;
            this.categorie = categorie;
            this.description = description;
        }

        public int IdHotel
        {
            get { return idHotel; }
            set { idHotel = value; }
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
        public string Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}