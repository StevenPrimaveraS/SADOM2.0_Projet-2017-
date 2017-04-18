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
            if (hotelDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (chambreDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (compteFournisseurChambreDAO == null) {
                throw new VoyageAhuntsicException(1);
            }
            this.hotelDAO = hotelDAO;
            this.chambreDAO = chambreDAO;
            this.compteFournisseurChambreDAO = compteFournisseurChambreDAO;
        }

        public void Add(HotelDTO hotelDTO) {
            if (hotelDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            hotelDAO.Add(hotelDTO);
        }

        public HotelDTO Read(int idHotel) {
            return hotelDAO.Read(idHotel);
        }

        public void Update(HotelDTO hotelDTO) {
            if (hotelDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            hotelDAO.Update(hotelDTO);
        }

        public void Delete(HotelDTO hotelDTO) {
            if (hotelDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (chambreDAO.FindByHotel(hotelDTO.IdHotel) == null) {
                throw new VoyageAhuntsicException(1);
            }
            hotelDAO.Delete(hotelDTO);
        }

        public DataSet GetAll() {
            return hotelDAO.GetAll();
        }

        public HotelDTO FindByBasicInfo(HotelDTO hotelDTO) {
            if(hotelDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (hotelDTO.Nom == null) {
                throw new VoyageAhuntsicException(1);
            }
            if(hotelDTO.Telephone == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (hotelDTO.Adresse == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (hotelDTO.Ville == null) {
                throw new VoyageAhuntsicException(1);
            }
            return hotelDAO.FindByBasicInfo(hotelDTO);
        }

    }
}
