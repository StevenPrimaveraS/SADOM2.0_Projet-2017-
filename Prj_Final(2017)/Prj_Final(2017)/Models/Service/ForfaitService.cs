using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.Service
{
    public class ForfaitService
    {
        private ForfaitDAO forfaitDAO;
        public ForfaitService(ForfaitDAO forfaitDAO)
        {
            if (forfaitDAO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            this.forfaitDAO = forfaitDAO;
        }

        public void Add(ForfaitDTO forfaitDTO)
        {
            if (forfaitDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            forfaitDAO.Add(forfaitDTO);
        }

        public ForfaitDTO Read(int IdForfait)
        {
            if (IdForfait < 1)
            {
                throw new VoyageAhuntsicException(1);
            }
            return forfaitDAO.Read(IdForfait); ;
        }

        public void Update(ForfaitDTO forfaitDTO)
        {
            if (forfaitDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            forfaitDAO.Update(forfaitDTO);
        }

        public void Delete(ForfaitDTO forfaitDTO)
        {
            if (forfaitDTO == null)
            {
                throw new VoyageAhuntsicException(1);
            }
            forfaitDAO.Delete(forfaitDTO);
        }

        public DataSet GetAll()
        {
            return forfaitDAO.GetAll();
        }
    }
}
