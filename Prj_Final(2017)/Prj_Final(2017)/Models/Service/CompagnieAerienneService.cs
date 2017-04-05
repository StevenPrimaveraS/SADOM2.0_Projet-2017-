using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.Models.DTO;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class CompagnieAerienneService {

        private CompagnieAerienneDAO compagnieAerienneDAO;
  
        public CompagnieAerienneService(CompagnieAerienneDAO compagnieAerienneDAO) {
            if(compagnieAerienneDAO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }

            this.compagnieAerienneDAO =compagnieAerienneDAO;
        }

        public void Add(CompagnieAerienneDTO compagnieAerienneDTO) {
            if(compagnieAerienneDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
           compagnieAerienneDAO.Add(compagnieAerienneDTO);

        }

        public CompagnieAerienneDTO Read(int IdCompagnieAerienne) {
            if(IdCompagnieAerienne < 1)
            {
                throw new VoyageAhuntsicException(4444);
            }
            return compagnieAerienneDAO.Read(IdCompagnieAerienne);
        }

        public void Update(CompagnieAerienneDTO compagnieAerienneDTO) {
            if (compagnieAerienneDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            compagnieAerienneDAO.Update(compagnieAerienneDTO);

        }

        public void Delete(CompagnieAerienneDTO compagnieAerienneDTO) {
            if(compagnieAerienneDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            compagnieAerienneDAO.Delete(compagnieAerienneDTO);
        }

        public DataSet GetAll() {
            return compagnieAerienneDAO.GetAll();
        }
    }
}
