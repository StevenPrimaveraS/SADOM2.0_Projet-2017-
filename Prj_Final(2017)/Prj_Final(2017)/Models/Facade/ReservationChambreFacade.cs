using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class ReservationChambreFacade {

        private ReservationChambreService reservationChambreService;

        public ReservationChambreFacade(ReservationChambreService reservaitonChambreService) {
            if (reservaitonChambreService == null) {
                throw new VoyageAhuntsicException(1234);
            }
            this.reservationChambreService = reservaitonChambreService;
        }

        public void Add(ReservationChambreDTO reservationChambreDTO) {
            reservationChambreService.Add(reservationChambreDTO);
        }

        public ReservationChambreDTO Read(int IdReservationChambre) {
            return reservationChambreService.Read(IdReservationChambre);
        }

        public void Update(ReservationChambreDTO reservationChambreDTO) {
            reservationChambreService.Update(reservationChambreDTO);
        }

        public void Delete(ReservationChambreDTO reservationChambreDTO) {
            reservationChambreService.Delete(reservationChambreDTO);
        }

        public DataSet GetAll() {
            return reservationChambreService.GetAll();
        }
    }
}
