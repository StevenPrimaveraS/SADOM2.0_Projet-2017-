using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.dto
{
    public class ReservationVoitureDTO
    {

        private int idreservationVoiture;
        private int idvoiture;
        private int idparticulier;
        private string datereservaton;
        private string datefinreservation;

        public ReservationVoitureDTO(int idreservationVoiture, int idvoiture, int idparticulier, string datereservaton, string datefinreservation)
        {
            this.idreservationVoiture = idreservationVoiture;
            this.idvoiture = idvoiture;
            this.idparticulier = idparticulier;
            this.datereservaton = datereservaton;
            this.datefinreservation = datefinreservation;

        }

        public int IdreservationVoiture
        {
            get { return idreservationVoiture; }
            set { idreservationVoiture = value; }
        }

        public int Idvoiture
        {
            get { return idvoiture; }
            set { idvoiture = value; }
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
