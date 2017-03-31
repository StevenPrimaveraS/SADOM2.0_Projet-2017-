using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class ReservationForfaitFacade {

        private ReservationForfaitService reservationForfaitService;

        public ReservationForfaitFacade(ReservationForfaitService reservaitonForfaitService) {
            if (reservaitonForfaitService == null) {
                throw new VoyageAhuntsicException(1234);
            }
            this.reservationForfaitService = reservaitonForfaitService;
        }

        public void Add(ReservationForfaitDTO reservationForfaitDTO) {
            reservationForfaitService.Add(reservationForfaitDTO);
        }

        public ReservationForfaitDTO Read(int IdReservationForfait) {
            return reservationForfaitService.Read(IdReservationForfait);
        }

        public void Update(ReservationForfaitDTO reservationForfaitDTO) {
            reservationForfaitService.Update(reservationForfaitDTO);
        }

        public void Delete(ReservationForfaitDTO reservationForfaitDTO) {
            reservationForfaitService.Delete(reservationForfaitDTO);
        }

        public DataSet GetAll() {
            return reservationForfaitService.GetAll();
        }
    }
}
