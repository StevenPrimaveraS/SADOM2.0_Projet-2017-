using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class VoitureService {
        private VoitureDAO voitureDAO;
        private CompteFournisseurVoitureDAO compteFournisseurVoitureDAO;
        public VoitureService(VoitureDAO voitureDAO, CompteFournisseurVoitureDAO compteFournisseurVoitureDAO)
        {
            if (voitureDAO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            if (compteFournisseurVoitureDAO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            this.voitureDAO = voitureDAO;
            this.compteFournisseurVoitureDAO = compteFournisseurVoitureDAO;
        }

        public void Add(VoitureDTO voitureDTO)
        {
            if (voitureDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            voitureDAO.Add(voitureDTO);
        }

        public VoitureDTO Read(int IdVoiture)
        {
            if (IdVoiture < 1)
            {
                throw new VoyageAhuntsicException(1);
            }
            return voitureDAO.Read(IdVoiture);
        }

        public void Update(VoitureDTO voitureDTO)
        {
            if (voitureDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            voitureDAO.Update(voitureDTO);
        }

        public void Delete(VoitureDTO voitureDTO)
        {
            if (voitureDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            voitureDAO.Delete(voitureDTO);
        }

        public DataSet GetAll()
        {
            return voitureDAO.GetAll();
        }
    }
}
