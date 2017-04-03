using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class ChambreFacade {
        private ChambreService chambreService;
        public ChambreFacade(ChambreService chambreService) {
            if (chambreService == null)
            {
                throw new VoyageAhuntsicException(7890);
            }
            this.chambreService = chambreService;
        }

        public void Add(ChambreDTO chambreDTO) {
            chambreService.Add(chambreDTO);
        }

        public ChambreDTO Read(int IdChambre) {
            return chambreService.Read(IdChambre);
        }

        public void Update(ChambreDTO chambreDTO) {
            chambreService.Update(chambreDTO);
        }

        public void Delete(ChambreDTO chambreDTO) {
            chambreService.Delete(chambreDTO);
        }

        public DataSet GetAll() {
            return chambreService.GetAll();
        }
    }
}
