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
        CompteFournisseurVoitureDAO compteFournisseurSiegeDAO;

        public CompteFournisseurVoitureService(CompteFournisseurVoitureDAO compteFournisseurSiegeDAO)
        {
            if (compteFournisseurSiegeDAO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            this.compteFournisseurSiegeDAO = compteFournisseurSiegeDAO;
        }

        public void Add(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO)
        {
            if (compteFournisseurVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurSiegeDAO.Add(compteFournisseurVoitureDTO);
        }

        public CompteFournisseurVoitureDTO Read(int IdCompteFournisseurVoiture)
        {
            compteFournisseurSiegeDAO.Read(IdCompteFournisseurVoiture);
            return null;
        }

        public void Update(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO)
        {
            if (compteFournisseurVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurSiegeDAO.Update(compteFournisseurVoitureDTO);
        }

        public void Delete(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO)
        {
            if (compteFournisseurVoitureDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurSiegeDAO.Delete(compteFournisseurVoitureDTO);
        }

        public DataSet GetAll()
        {
            return null;
        }
    }
}
