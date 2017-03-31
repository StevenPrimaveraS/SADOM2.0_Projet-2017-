using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class ReservationVoitureDTO {

        public int IdReservationVoiture { get; set; }

        public int IdVoiture { get; set; }

        public int IdParticulier { get; set; }

        public DateTime DateReservation { get; set; }

        public DateTime DateFinReservation { get; set; }

    }
}
