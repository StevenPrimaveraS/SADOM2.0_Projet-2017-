using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class CompteParticulierService {
        private CompteParticulierDAO compteParticulierDAO;
        private ReservationChambreDAO reservationChambreDAO;
        private ReservationForfaitDAO reservationForfaitDAO;
        private ReservationSiegeDAO reservationSiegeDAO;
        private ReservationVoitureDAO reservationVoitureDAO;

        public CompteParticulierService(CompteParticulierDAO compteParticulierDAO, 
                                        ReservationChambreDAO reservationChambreDAO, 
                                        ReservationForfaitDAO reservationForfaitDAO, 
                                        ReservationSiegeDAO reservationSiegeDAO,
                                        ReservationVoitureDAO reservationVoitureDAO) {
            if (reservationChambreDAO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            if (reservationForfaitDAO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            if (reservationSiegeDAO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            if (reservationVoitureDAO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            if (compteParticulierDAO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            this.compteParticulierDAO = compteParticulierDAO;
            this.reservationChambreDAO = reservationChambreDAO;
            this.reservationForfaitDAO = reservationForfaitDAO;
            this.reservationSiegeDAO = reservationSiegeDAO;
            this.reservationVoitureDAO = reservationVoitureDAO;
        }

        public void Add(CompteParticulierDTO compteParticulierDTO) {
            if (compteParticulierDTO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            if (compteParticulierDAO.FindByCourriel(compteParticulierDTO.Courriel) == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            compteParticulierDAO.Add(compteParticulierDTO);
        }

        public CompteParticulierDTO Read(int idCompteParticulier) {
            return compteParticulierDAO.Read(idCompteParticulier);
        }

        public void Update(CompteParticulierDTO compteParticulierDTO) {
            if (compteParticulierDTO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            compteParticulierDAO.Update(compteParticulierDTO);
        }

        public void Delete(CompteParticulierDTO compteParticulierDTO) {
            if (compteParticulierDTO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            if (reservationChambreDAO.FindByParticulier(compteParticulierDTO.IdParticulier) == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            compteParticulierDAO.Delete(compteParticulierDTO);
        }

        public DataSet GetAll() {
            return compteParticulierDAO.GetAll();
        }

        public CompteParticulierDTO Authenticate(CompteParticulierDTO compteParticulierDTO) {
            return compteParticulierDAO.Authenticate(compteParticulierDTO);
        }

    }
}
