using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class CompteParticulierService {
        private CompteParticulierDAO compteParticulierDAO;

        public CompteParticulierService(CompteParticulierDAO compteParticulierDAO) {
            if (compteParticulierDAO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
        }

        public void Add(CompteParticulierDTO compteParticulierDTO) {
            if (compteParticulierDTO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            compteParticulierDAO.Add(compteParticulierDTO);
        }

        public CompteParticulierDTO Read(int idCompteParticulier) {
            return compteParticulierDAO.Read(idCompteParticulier);
        }

        public void Update(CompteParticulierDTO compteParticulierDTO) {
            if (compteParticulierDTO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            compteParticulierDAO.Update(compteParticulierDTO);
        }

        public void Delete(CompteParticulierDTO compteParticulierDTO) {
            if (compteParticulierDTO == null)
            {
                throw new VoyageAhuntsicException(3000);
            }
            compteParticulierDAO.Delete(compteParticulierDTO);
        }

        public DataSet GetAll() {
            return compteParticulierDAO.GetAll();
        }
    }
}
