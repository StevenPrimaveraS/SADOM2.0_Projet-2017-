using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class CompteParticulierFacade {

        private CompteParticulierService compteParticulierService;
        public CompteParticulierFacade(CompteParticulierService compteParticulierService) {
            if (compteParticulierService == null)
            {
                throw new VoyageAhuntsicException(1234);
            }
            this.compteParticulierService = compteParticulierService;
        }

        public void Add(CompteParticulierDTO compteParticulierDTO) {
            compteParticulierService.Add(compteParticulierDTO);
        }

        public CompteParticulierDTO Read(int idCompteParticulier) {
            return compteParticulierService.Read(idCompteParticulier);
        }

        public void Update(CompteParticulierDTO compteParticulierDTO) {
            compteParticulierService.Update(compteParticulierDTO);
        }

        public void Delete(CompteParticulierDTO compteParticulierDTO) {
            compteParticulierService.Delete(compteParticulierDTO);
        }

        public DataSet GetAll() {
            return compteParticulierService.GetAll();
        }

        public CompteParticulierDTO Authenticate(CompteParticulierDTO compteParticulierDTO) {
            return compteParticulierService.Authenticate(compteParticulierDTO);
        }

    }
}
