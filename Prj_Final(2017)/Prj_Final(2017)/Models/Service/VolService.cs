using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class VolService {

        private VolDAO volDAO = new VolDAO();
        private SiegeDAO siegeDAO;
        
        public VolService(VolDAO volDAO, SiegeDAO siegeDAO) {
            if(volDAO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            if (siegeDAO == null)
            {
                throw new VoyageAhuntsicException(2000);
            }
            this.volDAO = volDAO;
            this.siegeDAO = siegeDAO;
        }

        public void Add(VolDTO volDTO) {
            if(volDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }

            volDAO.Add(volDTO);         
        }

        public VolDTO Read(int IdVol) {
            if(IdVol < 1)
            {
                throw new VoyageAhuntsicException(4444);
            }
            return volDAO.Read(IdVol);
        }

        public void Update(VolDTO volDTO) {
            if(volDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            volDAO.Update(volDTO);
        }

        public void Delete(VolDTO volDTO) {
            if(volDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            if (siegeDAO.FindByVol(volDTO.IdVol) == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            volDAO.Delete(volDTO);
        }

        public DataSet GetAll() {
            return volDAO.GetAll();
        }
    }
}
