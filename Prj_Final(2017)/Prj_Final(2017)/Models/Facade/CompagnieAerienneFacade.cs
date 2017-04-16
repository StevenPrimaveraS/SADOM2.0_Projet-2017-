using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class CompagnieAerienneFacade {

        private CompagnieAerienneService compagnieAerienneService;

        public CompagnieAerienneFacade(CompagnieAerienneService compagnieAerienneService) {
            if (compagnieAerienneService == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            this.compagnieAerienneService = compagnieAerienneService;

        }

        public void Add(CompagnieAerienneDTO compagnieAerienneDTO) {
            compagnieAerienneService.Add(compagnieAerienneDTO);
        }

        public CompagnieAerienneDTO Read(int IdCompagnieAerienne) {
            return compagnieAerienneService.Read(IdCompagnieAerienne);
        }

        public void Update(CompagnieAerienneDTO compagnieAerienneDTO) {
            compagnieAerienneService.Update(compagnieAerienneDTO);

        }

        public void Delete(CompagnieAerienneDTO compagnieAerienneDTO) {
            compagnieAerienneService.Delete(compagnieAerienneDTO);
        }

        public DataSet GetAll() {
            return compagnieAerienneService.GetAll();
        }

        public CompagnieAerienneDTO FindByBasicInfo(CompagnieAerienneDTO compagnieAerienneDTO) {
            return compagnieAerienneService.FindByBasicInfo(compagnieAerienneDTO);
        }

    }
}
