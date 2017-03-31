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
        VoitureDAO voitureDAO;
        public VoitureService(VoitureDAO voitureDAO)
        {
            if (voitureDAO == null)
            {
                throw new VoyageAhuntsicException(5678);
            }
            this.voitureDAO = voitureDAO;
        }

        public void Add(VoitureDTO voitureDTO)
        {
            if (voitureDTO == null)
            {
                throw new VoyageAhuntsicException(5678);
            }
            voitureDAO.Add(voitureDTO);
        }

        public VoitureDTO Read(int idVoiture)
        {
            return voitureDAO.Read(idVoiture);
        }

        public void Update(VoitureDTO voitureDTO)
        {
            if (voitureDTO == null)
            {
                throw new VoyageAhuntsicException(5678);
            }
            voitureDAO.Update(voitureDTO);
        }

        public void Delete(VoitureDTO voitureDTO)
        {
            if (voitureDTO == null)
            {
                throw new VoyageAhuntsicException(5678);
            }
            voitureDAO.Delete(voitureDTO);
        }

        public DataSet GetAll()
        {
            return voitureDAO.GetAll();
        }
    }
}
