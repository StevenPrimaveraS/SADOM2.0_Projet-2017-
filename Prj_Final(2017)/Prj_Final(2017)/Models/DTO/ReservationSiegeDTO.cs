using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class ReservationSiegeDTO {

        public int IdReservationSiege { get; set; }

        public int IdSiege { get; set; }

        public int IdParticulier { get; set; }

        public string DateReservaton { get; set; }

        public string DateFinReservation { get; set; }
    }
}
