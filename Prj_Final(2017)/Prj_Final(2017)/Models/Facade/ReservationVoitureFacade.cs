using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class ReservationVoitureFacade {

        private ReservationVoitureService reservationVoitureService;

        public ReservationVoitureFacade(ReservationVoitureService reservaitonVoitureService) {
            if(reservaitonVoitureService == null) {
                throw new VoyageAhuntsicException(1234);
            }
            this.reservationVoitureService = reservaitonVoitureService;
        }

        public void Add(ReservationVoitureDTO reservationVoitureDTO) {
            reservationVoitureService.Add(reservationVoitureDTO);
        }

        public ReservationVoitureDTO Read(int IdReservationVoiture) {
            return reservationVoitureService.Read(IdReservationVoiture);
        }

        public void Update(ReservationVoitureDTO reservationVoitureDTO) {
            reservationVoitureService.Update(reservationVoitureDTO);
        }

        public void Delete(ReservationVoitureDTO reservationVoitureDTO) {
            reservationVoitureService.Delete(reservationVoitureDTO);
        }

        public DataSet GetAll() {
            return reservationVoitureService.GetAll();
        }
    }
}
