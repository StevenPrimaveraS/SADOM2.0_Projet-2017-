using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.DTO {
    public class ForfaitDTO {
        private int idforfait;
        private int idchambre;
        private int idvoiture;
        private int idsiege;
        private int tarifreduit;

        public ForfaitDTO(int idforfait, int idchambre, int idvoiture, int idsiege, int tarifreduit) {
            this.idforfait = idforfait;
            this.idchambre = idchambre;
            this.idvoiture = idvoiture;
            this.idsiege = idsiege;
            this.tarifreduit = tarifreduit;

        }

        public int Idforfait {
            get { return idforfait; }
            set { idforfait = value; }
        }

        public int Idchambre {
            get { return idchambre; }
            set { idchambre = value; }
        }
        public int Idvoiture {
            get { return idvoiture; }
            set { idvoiture = value; }
        }
        public int Idsiege {
            get { return idsiege; }
            set { idsiege = value; }
        }
        public int Tarifreduit {
            get { return tarifreduit; }
            set { tarifreduit = value; }
        }
    }
}
