using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;

namespace Prj_Final_2017_.Models.Facade {
    public class CompteFournisseurSiegeFacade {
        CompteFournisseurSiegeService compteFournisseurSiegeService;
        public CompteFournisseurSiegeFacade(CompteFournisseurSiegeService compteFournisseurSiegeService)
        {
            this.compteFournisseurSiegeService = compteFournisseurSiegeService;
        }

        public void Add(CompteFournisseurSiegeDTO compteFournisseurSiegeDTO)
        {
            compteFournisseurSiegeService.Add(compteFournisseurSiegeDTO);
        }

        public CompteFournisseurSiegeDTO Read(int IdCompteFournisseurVoiture)
        {
            return compteFournisseurSiegeService.Read(IdCompteFournisseurVoiture);

        }

        public void Update(CompteFournisseurSiegeDTO compteFournisseurSiegeDTO)
        {
            compteFournisseurSiegeService.Update(compteFournisseurSiegeDTO);
        }

        public void Delete(CompteFournisseurSiegeDTO compteFournisseurSiegeDTO)
        {
            compteFournisseurSiegeService.Delete(compteFournisseurSiegeDTO);
        }

        public DataSet GetAll()
        {
            return compteFournisseurSiegeService.GetAll(); ;
        }
    }
}
