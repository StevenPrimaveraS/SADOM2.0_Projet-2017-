using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class CompteFournisseurVoitureService {
        CompteFournisseurVoitureDAO compteFournisseurVoitureDAO;
        AgenceVoitureDAO agenceVoitureDAO;

        public CompteFournisseurVoitureService(CompteFournisseurVoitureDAO compteFournisseurVoitureDAO, AgenceVoitureDAO agenceVoitureDAO)
        {
            if (compteFournisseurVoitureDAO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            if (agenceVoitureDAO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            this.compteFournisseurVoitureDAO = compteFournisseurVoitureDAO;
            this.agenceVoitureDAO = agenceVoitureDAO;
        }

        public void Add(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO)
        {
            if (compteFournisseurVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            if (agenceVoitureDAO.Read(compteFournisseurVoitureDTO.IdAgenceVoiture) == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurVoitureDAO.Add(compteFournisseurVoitureDTO);
        }

        public CompteFournisseurVoitureDTO Read(int IdCompteFournisseurVoiture)
        {
           return compteFournisseurVoitureDAO.Read(IdCompteFournisseurVoiture);
            
        }

        public void Update(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO)
        {
            if (compteFournisseurVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            if (agenceVoitureDAO.Read(compteFournisseurVoitureDTO.IdAgenceVoiture) == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurVoitureDAO.Update(compteFournisseurVoitureDTO);
        }

        public void Delete(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO)
        {
            if (compteFournisseurVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            if (agenceVoitureDAO.Read(compteFournisseurVoitureDTO.IdAgenceVoiture) == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurVoitureDAO.Delete(compteFournisseurVoitureDTO);
        }

        public DataSet GetAll()
        {
            return compteFournisseurVoitureDAO.GetAll(); ;
        }

        public CompteFournisseurVoitureDTO Authenticate(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO) {
            return compteFournisseurVoitureDAO.Authenticate(compteFournisseurVoitureDTO);
        }

    }
}
