using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class CompteFournisseurChambreService {
        CompteFournisseurChambreDAO compteFournisseurChambreDAO;

        public CompteFournisseurChambreService(CompteFournisseurChambreDAO compteFournisseurChambreDAO) {
            if (compteFournisseurChambreDAO == null) {
                throw new VoyageAhuntsicException(44);
            }
            this.compteFournisseurChambreDAO = compteFournisseurChambreDAO;
        }

        public void Add(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            if (compteFournisseurChambreDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurChambreDAO.Add(compteFournisseurChambreDTO);
        }

        public CompteFournisseurChambreDTO Read(int IdCompteFournisseurChambre) {
            compteFournisseurChambreDAO.Read(IdCompteFournisseurChambre);
            return null;
        }

        public void Update(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            if (compteFournisseurChambreDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurChambreDAO.Update(compteFournisseurChambreDTO);
        }

        public void Delete(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            if (compteFournisseurChambreDTO == null)
            {
                throw new VoyageAhuntsicException(44);
            }
            compteFournisseurChambreDAO.Delete(compteFournisseurChambreDTO);
        }

        public DataSet GetAll() {
            return compteFournisseurChambreDAO.GetAll();
        }
    }
}
