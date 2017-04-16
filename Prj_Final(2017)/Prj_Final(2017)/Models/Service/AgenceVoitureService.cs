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
        private AgenceVoitureDAO agenceVoitureDAO;

        public AgenceVoitureService(AgenceVoitureDAO agenceVoitureDAO) {
            if(agenceVoitureDAO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            this.agenceVoitureDAO = agenceVoitureDAO;
        }

        public void Add(AgenceVoitureDTO agenceVoitureDTO) {
            if(agenceVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            //if (compteFournisseurVoitureDAO.FindByCourriel(compteFournisseurVoitureDTO.Courriel) == null)
            //{
            //    throw new VoyageAhuntsicException(4444);
            //}
            agenceVoitureDAO.Add(agenceVoitureDTO);

        }

        public AgenceVoitureDTO Read(int IdAgenceVoiture) {
            if(IdAgenceVoiture < 1)
            {
                throw new VoyageAhuntsicException(4444);
            }
            return agenceVoitureDAO.Read(IdAgenceVoiture) ;
        }

        public void Update(AgenceVoitureDTO agenceVoitureDTO) {
            if(agenceVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            agenceVoitureDAO.Update(agenceVoitureDTO);
        }

        public void Delete(AgenceVoitureDTO agenceVoitureDTO) {
            if(agenceVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            agenceVoitureDAO.Delete(agenceVoitureDTO);

        }

        public DataSet GetAll() {
            return agenceVoitureDAO.GetAll();
        }

        public AgenceVoitureDTO FindByBasicInfo(AgenceVoitureDTO agenceVoitureDTO) {
            if (agenceVoitureDTO == null) {
                throw new VoyageAhuntsicException(2000);
            }
            if (agenceVoitureDTO.Nom == null) {
                throw new VoyageAhuntsicException(2000);
            }
            if (agenceVoitureDTO.Telephone == null) {
                throw new VoyageAhuntsicException(2000);
            }
            if (agenceVoitureDTO.Adresse == null) {
                throw new VoyageAhuntsicException(2000);
            }
            if (agenceVoitureDTO.Ville == null) {
                throw new VoyageAhuntsicException(2000);
            }
            return agenceVoitureDAO.FindByBasicInfo(agenceVoitureDTO);
        }

    }
}
