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
                throw new VoyageAhuntsicException(44);
            }
            if (hotelDAO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            this.compteFournisseurChambreDAO = compteFournisseurChambreDAO;
            this.hotelDAO = hotelDAO;
        }

        public void Add(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            if (compteFournisseurChambreDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            if (hotelDAO.Read(compteFournisseurChambreDTO.IdHotel) == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurChambreDAO.Add(compteFournisseurChambreDTO);
        }

        public CompteFournisseurChambreDTO Read(int IdCompteFournisseurChambre) {
            return compteFournisseurChambreDAO.Read(IdCompteFournisseurChambre);
            
        }

        public void Update(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            if (compteFournisseurChambreDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            if (hotelDAO.Read(compteFournisseurChambreDTO.IdHotel) == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurChambreDAO.Update(compteFournisseurChambreDTO);
        }

        public void Delete(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            if (compteFournisseurChambreDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            if (hotelDAO.Read(compteFournisseurChambreDTO.IdHotel) == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurChambreDAO.Delete(compteFournisseurChambreDTO);
        }

        public DataSet GetAll() {
            return compteFournisseurChambreDAO.GetAll();
        }
    }
}
