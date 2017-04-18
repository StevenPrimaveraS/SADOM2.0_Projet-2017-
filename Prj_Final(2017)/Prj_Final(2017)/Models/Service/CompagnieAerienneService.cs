using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class CompagnieAerienneService {

        private CompagnieAerienneDAO compagnieAerienneDAO;
  
        public CompagnieAerienneService(CompagnieAerienneDAO compagnieAerienneDAO) {
            if(compagnieAerienneDAO == null)
            {
                throw new VoyageAhuntsicException(1);
            }

            this.compagnieAerienneDAO =compagnieAerienneDAO;
        }

        public void Add(CompagnieAerienneDTO compagnieAerienneDTO) {
            if(compagnieAerienneDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
           compagnieAerienneDAO.Add(compagnieAerienneDTO);

        }

        public CompagnieAerienneDTO Read(int IdCompagnieAerienne) {
            if(IdCompagnieAerienne < 1)
            {
                throw new VoyageAhuntsicException(1);
            }
            return compagnieAerienneDAO.Read(IdCompagnieAerienne);
        }

        public void Update(CompagnieAerienneDTO compagnieAerienneDTO) {
            if (compagnieAerienneDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            compagnieAerienneDAO.Update(compagnieAerienneDTO);

        }

        public void Delete(CompagnieAerienneDTO compagnieAerienneDTO) {
            if(compagnieAerienneDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            compagnieAerienneDAO.Delete(compagnieAerienneDTO);
        }

        public DataSet GetAll() {
            return compagnieAerienneDAO.GetAll();
        }

        public CompagnieAerienneDTO FindByBasicInfo(CompagnieAerienneDTO compagnieAerienneDTO) {
            if (compagnieAerienneDTO == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (compagnieAerienneDTO.Nom == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (compagnieAerienneDTO.Telephone == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (compagnieAerienneDTO.Adresse == null) {
                throw new VoyageAhuntsicException(1);
            }
            if (compagnieAerienneDTO.Ville == null) {
                throw new VoyageAhuntsicException(1);
            }
            return compagnieAerienneDAO.FindByBasicInfo(compagnieAerienneDTO);
        }

    }
}
