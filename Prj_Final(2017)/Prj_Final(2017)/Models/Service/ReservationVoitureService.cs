using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class ReservationVoitureService {

        private ReservationVoitureDAO reservationVoitureDAO;
        private VoitureDAO voitureDAO;
        private CompteParticulierDAO compteParticulierDAO;


        public ReservationVoitureService(ReservationVoitureDAO reservationVoitureDAO, VoitureDAO voitureDAO, CompteParticulierDAO compteParticulierDAO­­) {
            if (reservationVoitureDAO == null) {
                throw new VoyageAhuntsicException(1234);
            }
            if (voitureDAO == null) {
                throw new VoyageAhuntsicException(1234);
            }
            if (compteParticulierDAO == null) {
                throw new VoyageAhuntsicException(1234);
            }
            this.reservationVoitureDAO = reservationVoitureDAO;
            this.voitureDAO = voitureDAO;
            this.compteParticulierDAO = compteParticulierDAO;
        }

        public void Add(ReservationVoitureDTO reservationVoitureDTO) {
            if (reservationVoitureDTO == null) {
                throw new VoyageAhuntsicException(1234);
            }
            if (voitureDAO.Read(reservationVoitureDTO.IdVoiture) == null) {
                throw new VoyageAhuntsicException(1234);
            }
            if (voitureDAO.Read(reservationVoitureDTO.IdParticulier) == null) {
                throw new VoyageAhuntsicException(1234);
            }
            if (reservationVoitureDTO.DateReservation > DateTime.Now) {
                throw new VoyageAhuntsicException(1234);
            }
            if (reservationVoitureDTO.DateFinReservation < reservationVoitureDTO.DateReservation) {
                throw new VoyageAhuntsicException(1234);
            }
            reservationVoitureDAO.Add(reservationVoitureDTO);
        }

        public ReservationVoitureDTO Read(int IdReservationVoiture) {
            return reservationVoitureDAO.Read(IdReservationVoiture);
        }

        public void Update(ReservationVoitureDTO reservationVoitureDTO) {
            if (reservationVoitureDTO == null) {
                throw new VoyageAhuntsicException(1234);
            }
            ReservationVoitureDTO newReservationVoitureDTO = reservationVoitureDTO;
            ReservationVoitureDTO oldReservationVoitureDTO = reservationVoitureDAO.Read(reservationVoitureDTO.IdReservationVoiture);
            if (oldReservationVoitureDTO == null) {
                throw new VoyageAhuntsicException(1234);
            }
            if (newReservationVoitureDTO.DateReservation > DateTime.Now) {
                throw new VoyageAhuntsicException(1234);
            }
            if (newReservationVoitureDTO.DateFinReservation < newReservationVoitureDTO.DateReservation) {
                throw new VoyageAhuntsicException(1234);
            }
            reservationVoitureDAO.Update(reservationVoitureDTO);
        }

        public void Delete(ReservationVoitureDTO reservationVoitureDTO) {
            if (reservationVoitureDTO == null) {
                throw new VoyageAhuntsicException(1234);
            }
            if (reservationVoitureDAO.Read(reservationVoitureDTO.IdReservationVoiture) == null) {
                throw new VoyageAhuntsicException(1234);
            }
            reservationVoitureDAO.Delete(reservationVoitureDTO);
        }

        public DataSet GetAll() {
            return reservationVoitureDAO.GetAll();
        }
    }
}
