using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class ReservationForfaitService {

        private ReservationForfaitDAO reservationForfaitDAO;
        private ForfaitDAO forfaitDAO;
        private CompteParticulierDAO compteParticulierDAO;


        public ReservationForfaitService(ReservationForfaitDAO reservationForfaitDAO, ForfaitDAO forfaitDAO, CompteParticulierDAO compteParticulierDAO­­) {
            if (reservationForfaitDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (forfaitDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (compteParticulierDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            this.reservationForfaitDAO = reservationForfaitDAO;
            this.forfaitDAO = forfaitDAO;
            this.compteParticulierDAO = compteParticulierDAO;
        }

        public void Add(ReservationForfaitDTO reservationForfaitDTO) {
            if (reservationForfaitDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (forfaitDAO.Read(reservationForfaitDTO.IdForfait) == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (forfaitDAO.Read(reservationForfaitDTO.IdParticulier) == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (reservationForfaitDTO.DateReservation < DateTime.Now) {
                throw new VoyageAhuntsicException(1);
            }
            if (reservationForfaitDTO.DateFinReservation < reservationForfaitDTO.DateReservation) {
                throw new VoyageAhuntsicException(1);
            }
            //
            if (reservationForfaitDAO.FindByDateAndForfait(reservationForfaitDTO) != null) {
                throw new VoyageAhuntsicException(1);
            }
            reservationForfaitDAO.Add(reservationForfaitDTO);
        }

        public ReservationForfaitDTO Read(int IdReservationForfait) {
            return reservationForfaitDAO.Read(IdReservationForfait);
        }

        public void Update(ReservationForfaitDTO reservationForfaitDTO) {
            if (reservationForfaitDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            ReservationForfaitDTO newReservationForfaitDTO = reservationForfaitDTO;
            ReservationForfaitDTO oldReservationForfaitDTO = reservationForfaitDAO.Read(reservationForfaitDTO.IdReservationForfait);
            if (oldReservationForfaitDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (newReservationForfaitDTO.DateReservation > DateTime.Now) {
                throw new VoyageAhuntsicException(1);
            }
            if (newReservationForfaitDTO.DateFinReservation < newReservationForfaitDTO.DateReservation) {
                throw new VoyageAhuntsicException(1);
            }
            reservationForfaitDAO.Update(reservationForfaitDTO);
        }

        public void Delete(ReservationForfaitDTO reservationForfaitDTO) {
            if (reservationForfaitDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (reservationForfaitDAO.Read(reservationForfaitDTO.IdReservationForfait) == null) {
                throw new VoyageAhuntsicException(1);
            }
            reservationForfaitDAO.Delete(reservationForfaitDTO);
        }

        public DataSet GetAll() {
            return reservationForfaitDAO.GetAll();
        }
    }
}
