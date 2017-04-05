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
        private CompteFournisseurSiegeDTO compteFournisseurSiegeDTO;
        private CompteFournisseurSiegeDAO compteFournisseurSiegeDAO;

        public SiegeService(SiegeDAO siegeDAO, CompteFournisseurSiegeDTO compteFournisseurSiegeDTO) {
            if(siegeDAO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            if (compteFournisseurSiegeDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            this.siegeDAO = siegeDAO;
            this.compteFournisseurSiegeDTO = compteFournisseurSiegeDTO;

        }

        public void Add(SiegeDTO siegeDTO) {
            if(siegeDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            if (compteFournisseurSiegeDAO.FindByCourriel(compteFournisseurSiegeDTO.Courriel) == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            siegeDAO.Add(siegeDTO);
        }

        public SiegeDTO Read(int IdSiege) {
            if (IdSiege < 1)
            {
                throw new VoyageAhuntsicException(4444);
            }
            return siegeDAO.Read(IdSiege);
        }

        public void Update(SiegeDTO siegeDTO) {
            if(siegeDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            siegeDAO.Update(siegeDTO);
        }

        public void Delete(SiegeDTO siegeDTO) {
            if(siegeDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            siegeDAO.Delete(siegeDTO);
        }

        public DataSet GetAll() {
            return siegeDAO.GetAll();
        }
    }
}
