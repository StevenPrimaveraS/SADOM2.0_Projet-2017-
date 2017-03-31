using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class ReservationSiegeFacade {

        private ReservationSiegeService reservationSiegeService;

        public ReservationSiegeFacade(ReservationSiegeService reservaitonSiegeService) {
            if (reservaitonSiegeService == null) {
                throw new VoyageAhuntsicException(1234);
            }
            this.reservationSiegeService = reservaitonSiegeService;
        }

        public void Add(ReservationSiegeDTO reservationSiegeDTO) {
            reservationSiegeService.Add(reservationSiegeDTO);
        }

        public ReservationSiegeDTO Read(int IdReservationSiege) {
            return reservationSiegeService.Read(IdReservationSiege);
        }

        public void Update(ReservationSiegeDTO reservationSiegeDTO) {
            reservationSiegeService.Update(reservationSiegeDTO);
        }

        public void Delete(ReservationSiegeDTO reservationSiegeDTO) {
            reservationSiegeService.Delete(reservationSiegeDTO);
        }

        public DataSet GetAll() {
            return reservationSiegeService.GetAll();
        }
    }
}
