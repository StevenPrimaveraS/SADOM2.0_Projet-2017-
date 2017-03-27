using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.dto
{
    public class ReservationSiege
    {
        private int idreservationSiege;
        private int idSiege;
        private int idparticulier;
        private string datereservaton;
        private string datefinreservation;

        public ReservationSiege(int idreservationSiege, int idSiege, int idparticulier, string datereservaton, string datefinreservation)
        {
            this.idreservationSiege = idreservationSiege;
            this.idSiege = idSiege;
            this.idparticulier = idparticulier;
            this.datereservaton = datereservaton;
            this.datefinreservation = datefinreservation;

        }

        public int IdreservationSiege
        {
            get { return idreservationSiege; }
            set { idreservationSiege = value; }
        }

        public int IdSiege
        {
            get { return idSiege; }
            set { idSiege = value; }
        }
        public int Idparticulier
        {
            get { return idparticulier; }
            set { idparticulier = value; }
        }
        public string Datereservaton
        {
            get { return datereservaton; }
            set { datereservaton = value; }
        }
        public string Datefinreservation
        {
            get { return datefinreservation; }
            set { datefinreservation = value; }
        }
    }
}