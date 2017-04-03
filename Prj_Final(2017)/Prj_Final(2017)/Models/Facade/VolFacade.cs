using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class VolFacade {

        private VolService volService;
        
        public VolFacade(VolService volService) {
            if (volService == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            this.volService = volService;
        }

        public void Add(VolDTO volDTO) {
            volService.Add(volDTO);
        }

        public VolDTO Read(int IdVol) {
            return volService.Read(IdVol);
        }

        public void Update(VolDTO volDTO) {
            volService.Update(volDTO);
        }

        public void Delete(VolDTO volDTO) {
            volService.Delete(volDTO);
        }

        public DataSet GetAll() {
            return volService.GetAll();
        }
    }
}
