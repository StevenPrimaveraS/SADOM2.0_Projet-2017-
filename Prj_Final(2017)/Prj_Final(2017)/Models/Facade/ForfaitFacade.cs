using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class ForfaitFacade {
        private ForfaitService forfaitService;
        public ForfaitFacade(ForfaitService forfaitService) {
            if (forfaitService == null)
            {
                throw new VoyageAhuntsicException(6789);
            }
            this.forfaitService = forfaitService;
        }

        public void Add(ForfaitDTO forfaitDTO) {
            forfaitService.Add(forfaitDTO);
        }

        public ForfaitDTO Read(int IdForfait) {
            return forfaitService.Read(IdForfait);
        }

        public void Update(ForfaitDTO forfaitDTO) {
            forfaitService.Update(forfaitDTO);
        }

        public void Delete(ForfaitDTO forfaitDTO) {
            forfaitService.Delete(forfaitDTO);
        }

        public DataSet GetAll() {
            return forfaitService.GetAll();
        }
    }
}
