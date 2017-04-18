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
                CharteErreur[1] = "Une erreur c'est produite";
                //Erreurs DAO :
                CharteErreur[20000] = "Message Erreur 20000";
                //Erreurs Services :
                CharteErreur[30000] = "Message Erreur 30000";

                /*
                 * Num Temporaire
                 * Classe : ReservationChambre = 210xx 310xx
                 * Classe : ReservationForfait = 211xx 311xx
                 * Classe : ReservationSiege = 212xx 312xx
                 * Classe : ReservationVoiture = 213xx 313xx
                 * 
                 */

                CharteErreur[21001] = "Message Erreur 21001";
                CharteErreur[21002] = "Message Erreur 21002";
                CharteErreur[21003] = "Message Erreur 21003";
                CharteErreur[21004] = "Message Erreur 21004";
                CharteErreur[21005] = "Message Erreur 21005";
                CharteErreur[21006] = "Message Erreur 21006";

                CharteErreur[31001] = "Message Erreur 31001";
                CharteErreur[31002] = "Message Erreur 31002";
                CharteErreur[31003] = "Message Erreur 31003";
                CharteErreur[31004] = "Message Erreur 31004";
                CharteErreur[31005] = "Message Erreur 31005";
                CharteErreur[31006] = "Message Erreur 31006";
                CharteErreur[31007] = "Message Erreur 31007";
                CharteErreur[31008] = "Message Erreur 31008";
                CharteErreur[31009] = "Message Erreur 31009";
                CharteErreur[31010] = "Message Erreur 31010";
                CharteErreur[31011] = "Message Erreur 31011";
                CharteErreur[31012] = "Message Erreur 31012";
                CharteErreur[31013] = "Message Erreur 31013";
                CharteErreur[31014] = "Message Erreur 31014";
            }
        }
    }
}