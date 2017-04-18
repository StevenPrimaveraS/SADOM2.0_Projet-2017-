using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class ReservationChambreService {

        private ReservationCham­breDAO reservationChambreDAO;
        private ChambreDAO chambreDAO;
        private CompteParticulierDAO compteParticulierDAO;


        public ReservationChambreService(ReservationCham­breDAO reservationChambreDAO, ChambreDAO chambreDAO, CompteParticulierDAO compteParticulierDAO­­) {
            if(reservationChambreDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (chambreDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (compteParticulierDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            this.reservationChambreDAO = reservationChambreDAO;
            this.chambreDAO = chambreDAO;
            this.compteParticulierDAO = compteParticulierDAO;
        }

        public void Add(ReservationChambreDTO reservationChambreDTO) {
            if (reservationChambreDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (chambreDAO.Read(reservationChambreDTO.IdChambre) == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (chambreDAO.Read(reservationChambreDTO.IdParticulier) == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (reservationChambreDTO.DateReservation < DateTime.Now) {
                throw new VoyageAhuntsicException(1);
            }
            if (reservationChambreDTO.DateFinReservation < reservationChambreDTO.DateReservation) {
                throw new VoyageAhuntsicException(1);
            }
            //
            if(reservationChambreDAO.FindByDateAndChambre(reservationChambreDTO) != null) {
                throw new VoyageAhuntsicException(1);
            }
            reservationChambreDAO.Add(reservationChambreDTO);
        }

        public ReservationChambreDTO Read(int IdReservationChambre) {
            return reservationChambreDAO.Read(IdReservationChambre);
        }

        public void Update(ReservationChambreDTO reservationChambreDTO) {
            if (reservationChambreDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            ReservationChambreDTO newReservationChambreDTO = reservationChambreDTO;
            ReservationChambreDTO oldReservationChambreDTO = reservationChambreDAO.Read(reservationChambreDTO.IdReservationChambre);
            if (oldReservationChambreDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (newReservationChambreDTO.DateReservation > DateTime.Now) {
                throw new VoyageAhuntsicException(1);
            }
            if (newReservationChambreDTO.DateFinReservation < newReservationChambreDTO.DateReservation) {
                throw new VoyageAhuntsicException(1);
            }
            reservationChambreDAO.Update(reservationChambreDTO);
        }

        public void Delete(ReservationChambreDTO reservationChambreDTO) {
            if (reservationChambreDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (reservationChambreDAO.Read(reservationChambreDTO.IdReservationChambre) == null) {
                throw new VoyageAhuntsicException(1);
            }
            reservationChambreDAO.Delete(reservationChambreDTO);
        }

        public DataSet GetAll() {
            return reservationChambreDAO.GetAll();
        }
    }
}
