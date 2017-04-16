using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Facade {
    public class HotelFacade {

        private HotelService hotelService;

        public HotelFacade(HotelService hotelService) {
            if(hotelService == null)
            {
                throw new VoyageAhuntsicException(1234);
            }
            this.hotelService = hotelService;
        }

        public void Add(HotelDTO hotelDTO) {
            hotelService.Add(hotelDTO);
        }

        public HotelDTO Read(int idHotel) {
            return hotelService.Read(idHotel);
        }

        public void Update(HotelDTO hotelDTO) {
            hotelService.Update(hotelDTO);
        }

        public void Delete(HotelDTO hotelDTO) {
            hotelService.Delete(hotelDTO);
        }

        public DataSet GetAll() {
            return hotelService.GetAll();
        }

        public HotelDTO FindByBasicInfo(HotelDTO hotelDTO) {
            return hotelService.FindByBasicInfo(hotelDTO);
        }

    }
}
