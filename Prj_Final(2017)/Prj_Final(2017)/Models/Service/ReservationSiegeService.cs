using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class ReservationSiegeService {

        private ReservationSiegeDAO reservationSiegeDAO;
        private SiegeDAO siegeDAO;
        private CompteParticulierDAO compteParticulierDAO;


        public ReservationSiegeService(ReservationSiegeDAO reservationSiegeDAO, SiegeDAO siegeDAO, CompteParticulierDAO compteParticulierDAO­­) {
            if (reservationSiegeDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (siegeDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (compteParticulierDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            this.reservationSiegeDAO = reservationSiegeDAO;
            this.siegeDAO = siegeDAO;
            this.compteParticulierDAO = compteParticulierDAO;
        }

        public void Add(ReservationSiegeDTO reservationSiegeDTO) {
            if (reservationSiegeDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (siegeDAO.Read(reservationSiegeDTO.IdSiege) == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (siegeDAO.Read(reservationSiegeDTO.IdParticulier) == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (reservationSiegeDTO.DateReservation < DateTime.Now) {
                throw new VoyageAhuntsicException(1);
            }
            if (reservationSiegeDTO.DateFinReservation < reservationSiegeDTO.DateReservation) {
                throw new VoyageAhuntsicException(1);
            }
            //
            if (reservationSiegeDAO.FindByDateAndSiege(reservationSiegeDTO) != null) {
                throw new VoyageAhuntsicException(1);
            }
            reservationSiegeDAO.Add(reservationSiegeDTO);
        }

        public ReservationSiegeDTO Read(int IdReservationSiege) {
            return reservationSiegeDAO.Read(IdReservationSiege);
        }

        public void Update(ReservationSiegeDTO reservationSiegeDTO) {
            if (reservationSiegeDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            ReservationSiegeDTO newReservationSiegeDTO = reservationSiegeDTO;
            ReservationSiegeDTO oldReservationSiegeDTO = reservationSiegeDAO.Read(reservationSiegeDTO.IdReservationSiege);
            if (oldReservationSiegeDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (newReservationSiegeDTO.DateReservation > DateTime.Now) {
                throw new VoyageAhuntsicException(1);
            }
            if (newReservationSiegeDTO.DateFinReservation < newReservationSiegeDTO.DateReservation) {
                throw new VoyageAhuntsicException(1);
            }
            reservationSiegeDAO.Update(reservationSiegeDTO);
        }

        public void Delete(ReservationSiegeDTO reservationSiegeDTO) {
            if (reservationSiegeDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (reservationSiegeDAO.Read(reservationSiegeDTO.IdReservationSiege) == null) {
                throw new VoyageAhuntsicException(1);
            }
            reservationSiegeDAO.Delete(reservationSiegeDTO);
        }

        public DataSet GetAll() {
            return reservationSiegeDAO.GetAll();
        }
    }
}
