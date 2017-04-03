using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class HotelService {
        private HotelDAO hotelDAO;
        private ChambreDAO chambreDAO;
        private CompteFournisseurChambreDAO compteFournisseurChambreDAO;

        public HotelService(HotelDAO hotelDAO, ChambreDAO chambreDAO, CompteFournisseurChambreDAO compteFournisseurChambreDAO) {
            if (hotelDAO == null)
            {
                throw new VoyageAhuntsicException(2000);
            }
            if (chambreDAO == null)
            {
                throw new VoyageAhuntsicException(2000);
            }
            if (compteFournisseurChambreDAO == null)
            {
                throw new VoyageAhuntsicException(2000);
            }
            this.hotelDAO = hotelDAO;
            this.chambreDAO = chambreDAO;
            this.compteFournisseurChambreDAO = compteFournisseurChambreDAO;
        }

        public void Add(HotelDTO hotelDTO) {
            if (hotelDTO == null)
            {
                throw new VoyageAhuntsicException(2000);
            }
            //if (compteFournisseurChambreDAO.FindByCourriel(compteFournisseurChambreDTO.Courriel) == null)
            //{
            //    throw new VoyageAhuntsicException(2000);
            //}
            hotelDAO.Add(hotelDTO);
        }

        public HotelDTO Read(int idHotel) {
            return hotelDAO.Read(idHotel);
        }

        public void Update(HotelDTO hotelDTO) {
            if (hotelDTO == null)
            {
                throw new VoyageAhuntsicException(2000);
            }
            hotelDAO.Update(hotelDTO);
        }

        public void Delete(HotelDTO hotelDTO) {
            if (hotelDTO == null)
            {
                throw new VoyageAhuntsicException(2000);
            }
            if (chambreDAO.FindByHotel(hotelDTO.IdHotel) == null)
            {
                throw new VoyageAhuntsicException(2000);
            }
            hotelDAO.Delete(hotelDTO);
        }

        public DataSet GetAll() {
            return hotelDAO.GetAll();
        }
    }
}
