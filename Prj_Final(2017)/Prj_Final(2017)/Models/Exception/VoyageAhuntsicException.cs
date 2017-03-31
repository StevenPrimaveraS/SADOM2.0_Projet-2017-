using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.Models.Exception {
    public class VoyageAhuntsicException : System.Exception {

        public int NumeroException { get; private set; }
        public static Dictionary<int, string> CharteErreur { get; private set; }

        public VoyageAhuntsicException(int numero) :base() {
            NumeroException = numero;
            fillChart();
        }
        public VoyageAhuntsicException(int numero, string message) : base(message) {
            NumeroException = numero;
            fillChart();
        }
        public VoyageAhuntsicException(int numero, string message, System.Exception innerException) : base(message,innerException) {
            NumeroException = numero;
            fillChart();
        }

        //Initialiser la charte des codes d'erreur
        private void fillChart() {
            if(CharteErreur == null) {
                CharteErreur = new Dictionary<int,string>();
                //Erreurs Application :
                CharteErreur[10000] = "Message Erreur 10000";
                //Erreurs DAO :
                CharteErreur[20000] = "Message Erreur 20000";
                //Erreurs Services :
                CharteErreur[30000] = "Message Erreur 30000";
                
            }
        }
    }
}