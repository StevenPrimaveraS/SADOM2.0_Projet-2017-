using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;

namespace Prj_Final_2017_.Models.Facade {
    public class CompteFournisseurVoitureFacade {
        CompteFournisseurVoitureService compteFournisseurVoitureService;
        public CompteFournisseurVoitureFacade(CompteFournisseurVoitureService compteFournisseurVoitureService) {
            this.compteFournisseurVoitureService = compteFournisseurVoitureService;
        }

        public void Add(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO) {
            compteFournisseurVoitureService.Add(compteFournisseurVoitureDTO);
        }

        public CompteFournisseurVoitureDTO Read(int IdCompteFournisseurVoiture) {
            return compteFournisseurVoitureService.Read(IdCompteFournisseurVoiture);
             
        }

        public void Update(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO) {
            compteFournisseurVoitureService.Update(compteFournisseurVoitureDTO);
        }

        public void Delete(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO) {
            compteFournisseurVoitureService.Delete(compteFournisseurVoitureDTO);
        }

        public DataSet GetAll() {
            return compteFournisseurVoitureService.GetAll(); ;
        }
    }
}
