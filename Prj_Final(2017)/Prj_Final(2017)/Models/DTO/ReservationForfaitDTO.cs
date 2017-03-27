using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class ReservationForfaitDTO {
        private int idreservationForfait;
        private int idForfait;
        private int idparticulier;
        private string datereservaton;
        private string datefinreservation;

        public ReservationForfaitDTO(int idreservationForfait, int idForfait, int idparticulier, string datereservaton, string datefinreservation) {
            this.idreservationForfait = idreservationForfait;
            this.idForfait = idForfait;
            this.idparticulier = idparticulier;
            this.datereservaton = datereservaton;
            this.datefinreservation = datefinreservation;

        }

        public int IdreservationForfait {
            get { return idreservationForfait; }
            set { idreservationForfait = value; }
        }

        public int IdForfait {
            get { return idForfait; }
            set { idForfait = value; }
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
