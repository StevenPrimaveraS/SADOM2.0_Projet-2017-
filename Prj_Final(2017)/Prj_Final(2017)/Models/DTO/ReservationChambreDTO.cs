using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class ReservationChambreDTO {

        private int idreservationChambre;
        private int idchambre;
        private int idparticulier;
        private string datereservaton;
        private string datefinreservation;

        public ReservationChambreDTO(int idreservationChambre, int idchambre, int idparticulier, string datereservaton, string datefinreservation) {
            this.idreservationChambre = idreservationChambre;
            this.idchambre = idchambre;
            this.idparticulier = idparticulier;
            this.datereservaton = datereservaton;
            this.datefinreservation = datefinreservation;

        }

        public int IdreservationChambre {
            get { return idreservationChambre; }
            set { idreservationChambre = value; }
        }

        public int Idchambre {
            get { return idchambre; }
            set { idchambre = value; }
        }
        public int Idparticulier {
            get { return idparticulier; }
            set { idparticulier = value; }
        }
        public string Datereservaton {
            get { return datereservaton; }
            set { datereservaton = value; }
        }
        public string Datefinreservation {
            get { return datefinreservation; }
            set { datefinreservation = value; }
        }
    }
}
