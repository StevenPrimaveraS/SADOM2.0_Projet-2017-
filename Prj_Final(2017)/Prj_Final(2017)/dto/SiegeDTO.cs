using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.dto
{
    public class SiegeDTO
    {
        private int idSiege;
        private string type;
        private int numero;
        private int idvol;
       
        public SiegeDTO(int idSiege, string type, int numero, int idvol)
        {
            this.idSiege = idSiege;
            this.type = type;
            this.numero = numero;
            this.idvol = idvol;
            
        }

        public int IdSiege
        {
            get { return idSiege; }
            set { idSiege = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public int Idvol
        {
            get { return idvol; }
            set { idvol = value; }
        }
    }
}