using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO
{
    public class ChambreDTO
    {
        private int idChambre;
        private int numeroChambre;
        private string nomChambre;
        private int tarif;
        private int maxPersonne;
        private int taille;
        private string description;
        private int idHotel;


        public ChambreDTO(int idChambre, int numeroChambre, string nomChambre, int tarif, int maxPersonne, int taille, string description, int idHotel)
        {
            this.idChambre = idChambre;
            this.numeroChambre = numeroChambre;
            this.nomChambre = nomChambre;
            this.tarif = tarif;
            this.maxPersonne = maxPersonne;
            this.taille = taille;
            this.description = description;
            this.idHotel = idHotel;
        }

        public int IdChambre
        {
            get { return idChambre; }
            set { idChambre = value; }
        }
        public int NumeroChambre
        {
            get { return numeroChambre; }
            set { numeroChambre = value; }
        }
        public string NomChambre
        {
            get { return nomChambre; }
            set { nomChambre = value; }
        }
        public int Tarif
        {
            get { return tarif; }
            set { tarif = value; }
        }
        public int MaxPersonne
        {
            get { return maxPersonne; }
            set { maxPersonne = value; }
        }
        public int Taille
        {
            get { return taille; }
            set { taille = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int IdHotel
        {
            get { return idHotel; }
            set { idHotel = value; }
        }
    }
}
