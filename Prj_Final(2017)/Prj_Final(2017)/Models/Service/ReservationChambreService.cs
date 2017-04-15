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
                throw new VoyageAhuntsicException(31001);
            }
            if (chambreDAO == null) {
                throw new VoyageAhuntsicException(31002);
            }
            if (compteParticulierDAO == null) {
                throw new VoyageAhuntsicException(31003);
            }
            this.reservationChambreDAO = reservationChambreDAO;
            this.chambreDAO = chambreDAO;
            this.compteParticulierDAO = compteParticulierDAO;
        }

        public void Add(ReservationChambreDTO reservationChambreDTO) {
            if (reservationChambreDTO == null) {
                throw new VoyageAhuntsicException(31004);
            }
            if (chambreDAO.Read(reservationChambreDTO.IdChambre) == null) {
                throw new VoyageAhuntsicException(31005);
            }
            if (chambreDAO.Read(reservationChambreDTO.IdParticulier) == null) {
                throw new VoyageAhuntsicException(31006);
            }
            if (reservationChambreDTO.DateReservation < DateTime.Now) {
                throw new VoyageAhuntsicException(31007);
            }
            if (reservationChambreDTO.DateFinReservation < reservationChambreDTO.DateReservation) {
                throw new VoyageAhuntsicException(31008);
            }
            reservationChambreDAO.Add(reservationChambreDTO);
        }

        public ReservationChambreDTO Read(int IdReservationChambre) {
            return reservationChambreDAO.Read(IdReservationChambre);
        }

        public void Update(ReservationChambreDTO reservationChambreDTO) {
            if (reservationChambreDTO == null) {
                throw new VoyageAhuntsicException(31009);
            }
            ReservationChambreDTO newReservationChambreDTO = reservationChambreDTO;
            ReservationChambreDTO oldReservationChambreDTO = reservationChambreDAO.Read(reservationChambreDTO.IdReservationChambre);
            if (oldReservationChambreDTO == null) {
                throw new VoyageAhuntsicException(31010);
            }
            if (newReservationChambreDTO.DateReservation > DateTime.Now) {
                throw new VoyageAhuntsicException(31011);
            }
            if (newReservationChambreDTO.DateFinReservation < newReservationChambreDTO.DateReservation) {
                throw new VoyageAhuntsicException(31012);
            }
            reservationChambreDAO.Update(reservationChambreDTO);
        }

        public void Delete(ReservationChambreDTO reservationChambreDTO) {
            if (reservationChambreDTO == null) {
                throw new VoyageAhuntsicException(31013);
            }
            if (reservationChambreDAO.Read(reservationChambreDTO.IdReservationChambre) == null) {
                throw new VoyageAhuntsicException(31014);
            }
            reservationChambreDAO.Delete(reservationChambreDTO);
        }

        public DataSet GetAll() {
            return reservationChambreDAO.GetAll();
        }
    }
}
