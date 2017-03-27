using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.dto
{
    public class CompteFournisseurChambreDTO
    {
        private int idFournisseur;
        private string courriel;
        private string password;
        private int idHotel;

        public CompteFournisseurChambreDTO(int idFournisseur, string courriel, string password, int idHotel)
        {
            this.idFournisseur = idFournisseur;
            this.courriel = courriel;
            this.password = password;
            this.idHotel = idHotel;
        }


        public int IdFournisseur
        {
            get { return idFournisseur; }
            set { idFournisseur = value; }
        }
        public string Courriel
        {
            get { return courriel; }
            set { courriel = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int IdHotel
        {
            get { return idHotel; }
            set { idHotel = value; }
        }
    }
}