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
        public VolService(VolDAO volDAO) {
            if(volDAO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            this.volDAO = volDAO;
        }

        public void Add(VolDTO volDTO) {
            if(volDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            
        }

        public VolDTO Read(int IdVol) {
            return volDAO.Read(IdVol);
        }

        public void Update(VolDTO volDTO) {
            if(volDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
        }

        public void Delete(VolDTO volDTO) {
            if(volDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
        }

        public DataSet GetAll() {
            return volDAO.GetAll();
        }
    }
}
