using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class CompteFournisseurSiegeService {
        CompteFournisseurSiegeDAO compteFournisseurSiegeDAO;

        public CompteFournisseurSiegeService(CompteFournisseurSiegeDAO compteFournisseurSiegeDAO)
        {
            if (compteFournisseurSiegeDAO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            this.compteFournisseurSiegeDAO = compteFournisseurSiegeDAO;
        }

        public void Add(CompteFournisseurSiegeDTO compteFournisseurSiegeDTO)
        {
            if (compteFournisseurSiegeDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurSiegeDAO.Add(compteFournisseurSiegeDTO);
        }

        public CompteFournisseurSiegeDTO Read(int IdCompteFournisseurSiege)
        {
            compteFournisseurSiegeDAO.Read(IdCompteFournisseurSiege);
            return null;
        }

        public void Update(CompteFournisseurSiegeDTO compteFournisseurSiegeDTO)
        {
            if (compteFournisseurSiegeDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurSiegeDAO.Update(compteFournisseurSiegeDTO);
        }

        public void Delete(CompteFournisseurSiegeDTO compteFournisseurSiegeDTO)
        {
            if (compteFournisseurSiegeDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurSiegeDAO.Delete(compteFournisseurSiegeDTO);
        }

        public DataSet GetAll()
        {
            return compteFournisseurSiegeDAO.GetAll();
        }
    }
}
