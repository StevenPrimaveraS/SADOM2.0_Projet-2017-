using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class ReservationChambreDTO {

        public int IdReservationChambre { get; set; }

        public int IdChambre { get; set; }

        public int IdParticulier { get; set; }

        public string DateReservation { get; set; }

        public string DateFinReservation { get; set; }
    }
}
