using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class SiegeFacade {

        private SiegeService siegeService;

        public SiegeFacade(SiegeService siegeService) {
            if (siegeService == null)
            {
                throw new VoyageAhuntsicException(4444);
            }
            this.siegeService = siegeService;
        }

        public void Add(SiegeDTO siegeDTO) {
            siegeService.Add(siegeDTO);
        }

        public SiegeDTO Read(int IdSiege) {
            return siegeService.Read(IdSiege);
        }

        public void Update(SiegeDTO siegeDTO) {
            siegeService.Update(siegeDTO);
        }

        public void Delete(SiegeDTO siegeDTO) {
            siegeService.Delete(siegeDTO);
        }

        public DataSet GetAll() {
            return siegeService.GetAll();
        }
    }
}
