using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class AgenceVoitureFacade {

        private AgenceVoitureService agenceVoitureService;

        public AgenceVoitureFacade(AgenceVoitureService agenceVoitureService) {
            if (agenceVoitureService == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            this.agenceVoitureService = agenceVoitureService;
        }

        public void Add(AgenceVoitureDTO agenceVoitureDTO) {
            agenceVoitureService.Add(agenceVoitureDTO);
        }

        public AgenceVoitureDTO Read(int IdAgenceVoiture) {
            return agenceVoitureService.Read(IdAgenceVoiture);
        }

        public void Update(AgenceVoitureDTO agenceVoitureDTO)  {
            agenceVoitureService.Update(agenceVoitureDTO);
        }

        public void Delete(AgenceVoitureDTO agenceVoitureDTO) {
            agenceVoitureService.Delete(agenceVoitureDTO);
        }

        public DataSet GetAll() {
            return agenceVoitureService.GetAll();
        }

        public AgenceVoitureDTO FindByBasicInfo(AgenceVoitureDTO agenceVoitureDTO) {
            return agenceVoitureService.FindByBasicInfo(agenceVoitureDTO);
        }

    }
}
