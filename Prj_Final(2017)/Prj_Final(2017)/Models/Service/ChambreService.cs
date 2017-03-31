using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service {
    public class ChambreService {
        ChambreDAO chambreDAO;
        public ChambreService(ChambreDAO chambreDAO) {
            if (chambreDAO == null)
            {
                throw new VoyageAhuntsicException(7890);
            }
            this.chambreDAO = chambreDAO;
        }

        public void Add(ChambreDTO chambreDTO) {
            if (chambreDTO == null)
            {
                throw new VoyageAhuntsicException(5678);
            }
            chambreDAO.Add(chambreDTO);
        }

        public ChambreDTO Read(int IdChambre) {
            return chambreDAO.Read(IdChambre);
        }

        public void Update(ChambreDTO chambreDTO) {
            if (chambreDTO == null)
            {
                throw new VoyageAhuntsicException(5678);
            }
            chambreDAO.Update(chambreDTO);
        }

        public void Delete(ChambreDTO chambreDTO) {
            if (chambreDTO == null)
            {
                throw new VoyageAhuntsicException(5678);
            }
            chambreDAO.Delete(chambreDTO);
        }

        public DataSet GetAll() {
            return chambreDAO.GetAll();
        }
    }
}
