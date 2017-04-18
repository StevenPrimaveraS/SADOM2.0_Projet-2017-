using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class CompteFournisseurChambreService {
        CompteFournisseurChambreDAO compteFournisseurChambreDAO;
        HotelDAO hotelDAO;
        
        public CompteFournisseurChambreService(CompteFournisseurChambreDAO compteFournisseurChambreDAO, HotelDAO hotelDAO) {
            if (compteFournisseurChambreDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (hotelDAO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            this.compteFournisseurChambreDAO = compteFournisseurChambreDAO;
            this.hotelDAO = hotelDAO;
        }

        public void Add(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            if (compteFournisseurChambreDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            if (hotelDAO.Read(compteFournisseurChambreDTO.IdHotel) == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            compteFournisseurChambreDAO.Add(compteFournisseurChambreDTO);
        }

        public CompteFournisseurChambreDTO Read(int IdCompteFournisseurChambre) {
            return compteFournisseurChambreDAO.Read(IdCompteFournisseurChambre);
            
        }

        public void Update(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            if (compteFournisseurChambreDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            if (hotelDAO.Read(compteFournisseurChambreDTO.IdHotel) == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            compteFournisseurChambreDAO.Update(compteFournisseurChambreDTO);
        }

        public void Delete(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            if (compteFournisseurChambreDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            if (hotelDAO.Read(compteFournisseurChambreDTO.IdHotel) == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            compteFournisseurChambreDAO.Delete(compteFournisseurChambreDTO);
        }

        public DataSet GetAll() {
            return compteFournisseurChambreDAO.GetAll();
        }

        public CompteFournisseurChambreDTO Authenticate(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            return compteFournisseurChambreDAO.Authenticate(compteFournisseurChambreDTO);
        }

    }
}
