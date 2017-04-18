using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class SiegeService {

        private SiegeDAO siegeDAO;
        //private CompteFournisseurSiegeDTO compteFournisseurSiegeDTO;
        //private CompteFournisseurSiegeDAO compteFournisseurSiegeDAO;

        public SiegeService(SiegeDAO siegeDAO) {
            if(siegeDAO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            this.siegeDAO = siegeDAO;

        }

        public void Add(SiegeDTO siegeDTO) {
            if(siegeDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            //if (compteFournisseurSiegeDAO.FindByCourriel(compteFournisseurSiegeDTO.Courriel) == null)
            //{
            //    throw new VoyageAhuntsicException(1);
            //}
            siegeDAO.Add(siegeDTO);
        }

        public SiegeDTO Read(int IdSiege) {
            if (IdSiege < 1)
            {
                throw new VoyageAhuntsicException(1);
            }
            return siegeDAO.Read(IdSiege);
        }

        public void Update(SiegeDTO siegeDTO) {
            if(siegeDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            siegeDAO.Update(siegeDTO);
        }

        public void Delete(SiegeDTO siegeDTO) {
            if(siegeDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            siegeDAO.Delete(siegeDTO);
        }

        public DataSet GetAll() {
            return siegeDAO.GetAll();
        }
    }
}
