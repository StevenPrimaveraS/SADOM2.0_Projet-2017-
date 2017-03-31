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

        SiegeDAO siegeDAO = new SiegeDAO();
        public SiegeService(SiegeDAO siegeDAO) {
            if(siegeDAO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
        }

        public void Add(SiegeDTO siegeDTO) {
            if(siegeDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
        }

        public SiegeDTO Read(int IdSiege) {
            return siegeDAO.Read(IdSiege);
        }

        public void Update(SiegeDTO siegeDTO) {
            if(siegeDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
        }

        public void Delete(SiegeDTO siegeDTO) {
            if(siegeDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
        }

        public DataSet GetAll() {
            return siegeDAO.GetAll();
        }
    }
}
