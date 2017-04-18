using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class ChambreService {
        private HotelDAO hotelDAO;
        private ChambreDAO chambreDAO;
        private CompteFournisseurChambreDAO compteFournisseurChambreDAO;
        public ChambreService(ChambreDAO chambreDAO, HotelDAO hotelDAO, CompteFournisseurChambreDAO compteFournisseurChambreDAO) {
            if (chambreDAO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            if (compteFournisseurChambreDAO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            if (hotelDAO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            this.chambreDAO = chambreDAO;
            this.hotelDAO = hotelDAO;
            this.compteFournisseurChambreDAO = compteFournisseurChambreDAO;
        }

        public void Add(ChambreDTO chambreDTO) {
            if (chambreDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            chambreDAO.Add(chambreDTO);
        }

        public ChambreDTO Read(int IdChambre) {
            if (IdChambre < 1)
            {
                throw new VoyageAhuntsicException(1);
            }
            return chambreDAO.Read(IdChambre);
        }

        public void Update(ChambreDTO chambreDTO) {
            if (chambreDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            chambreDAO.Update(chambreDTO);
        }

        public void Delete(ChambreDTO chambreDTO) {
            if (chambreDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            chambreDAO.Delete(chambreDTO);
        }

        public DataSet GetAll() {
            return chambreDAO.GetAll();
        }
    }
}
