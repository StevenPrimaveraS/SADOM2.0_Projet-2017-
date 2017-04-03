using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.Service;

namespace Prj_Final_2017_.Models.Facade {
    public class VoitureFacade {
        private VoitureService voitureService;
        public VoitureFacade(VoitureService voitureService) {
            if (voitureService == null)
            {
                throw new VoyageAhuntsicException(5678);
            }
            this.voitureService = voitureService;
        }

        public void Add(VoitureDTO voitureDTO) {
            voitureService.Add(voitureDTO);
        }

        public VoitureDTO Read(int IdVoiture) {
            return voitureService.Read(IdVoiture);
        }

        public void Update(VoitureDTO voitureDTO) {
            voitureService.Update(voitureDTO);
        }

        public void Delete(VoitureDTO voitureDTO) {
            voitureService.Delete(voitureDTO);
        }

        public DataSet GetAll() {
            return voitureService.GetAll();
        }
    }
}
