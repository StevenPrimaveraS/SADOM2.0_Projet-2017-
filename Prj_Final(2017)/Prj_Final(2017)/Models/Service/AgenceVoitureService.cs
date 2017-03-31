using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class AgenceVoitureService {
        AgenceVoitureDAO agenceVoitureDAO = new AgenceVoitureDAO();
        public AgenceVoitureService(AgenceVoitureDAO agenceVoitureDAO) {
            if(agenceVoitureDAO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
        }

        public void Add(AgenceVoitureDTO agenceVoitureDTO) {
            if(agenceVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }

        }

        public AgenceVoitureDTO Read(int IdAgenceVoiture) {

            return agenceVoitureDAO.Read(IdAgenceVoiture) ;
        }

        public void Update(AgenceVoitureDTO agenceVoitureDTO) {
            if(agenceVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
        }

        public void Delete(AgenceVoitureDTO agenceVoitureDTO) {
            if(agenceVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }

        }

        public DataSet GetAll() {
            return agenceVoitureDAO.GetAll();
        }
    }
}
