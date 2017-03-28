using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class ReservationForfaitDTO {
        public int IdReservationForfait { get; set; }

        public int IdForfait { get; set; }

        public int IdParticulier { get; set; }

        public string DateReservation { get; set; }

        public string DateFinReservation { get; set; }
    }
}
