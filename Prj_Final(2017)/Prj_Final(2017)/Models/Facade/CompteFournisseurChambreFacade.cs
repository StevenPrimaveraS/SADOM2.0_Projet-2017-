using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;

namespace Prj_Final_2017_.Models.Facade {
    public class CompteFournisseurChambreFacade {
        CompteFournisseurChambreService compteFournisseurChambreService;
        public CompteFournisseurChambreFacade(CompteFournisseurChambreService compteFournisseurChambreService)
        {
            this.compteFournisseurChambreService = compteFournisseurChambreService;
        }

        public void Add(CompteFournisseurChambreDTO compteFournisseurChambreDTO)
        {
            compteFournisseurChambreService.Add(compteFournisseurChambreDTO);
        }

        public CompteFournisseurChambreDTO Read(int IdCompteFournisseurVoiture)
        {
            return compteFournisseurChambreService.Read(IdCompteFournisseurVoiture);

        }

        public void Update(CompteFournisseurChambreDTO compteFournisseurChambreDTO)
        {
            compteFournisseurChambreService.Update(compteFournisseurChambreDTO);
        }

        public void Delete(CompteFournisseurChambreDTO compteFournisseurChambreDTO)
        {
            compteFournisseurChambreService.Delete(compteFournisseurChambreDTO);
        }

        public DataSet GetAll()
        {
            return compteFournisseurChambreService.GetAll(); ;
        }
    }
}
