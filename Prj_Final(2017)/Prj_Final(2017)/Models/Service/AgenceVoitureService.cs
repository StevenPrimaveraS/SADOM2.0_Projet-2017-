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
        private CompteFournisseurVoitureDTO compteFournisseurVoitureDTO;
        private CompteFournisseurVoitureDAO compteFournisseurVoitureDAO;

        public AgenceVoitureService(AgenceVoitureDAO agenceVoitureDAO, CompteFournisseurVoitureDTO compteFournisseurVoitureDTO) {
            if(agenceVoitureDAO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            if(compteFournisseurVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            this.agenceVoitureDAO = agenceVoitureDAO;
            this.compteFournisseurVoitureDTO = compteFournisseurVoitureDTO;
        }

        public void Add(AgenceVoitureDTO agenceVoitureDTO) {
            if(agenceVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            if (compteFournisseurVoitureDAO.FindByCourriel(compteFournisseurVoitureDTO.Courriel) == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
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
    }
}
