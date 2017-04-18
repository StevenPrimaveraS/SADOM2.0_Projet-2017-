using Prj_Final_2017_.Models.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.Models.util {
    public class VADateHandler {

        public static List<DateTime> getReservationDates(string sDatesReservation) {
            List<DateTime> datesReservation = new List<DateTime>();
            try {
                string[] sDates = sDatesReservation.Split(';');

                foreach (string date in sDates) {
                    string[] infoDate = date.Split('-');
                    int day = int.Parse(infoDate[2]);
                    int month = int.Parse(infoDate[1]);
                    int year = int.Parse(infoDate[0]);
                    DateTime dateTime = new DateTime(year, month, day);
                    datesReservation.Add(dateTime);
                }
            }
            catch (FormatException e) {
                throw new VoyageAhuntsicException(1);
            }
            catch (NullReferenceException e) {
                throw new VoyageAhuntsicException(1);
            }
            return datesReservation;
        }

        //TODO
        public static string ToReservationDates(string sDateDebut, string sDateFin) {
            return sDateDebut + ";" + sDateFin;
        }

        public static List<DateTime> BetweenDate(DateTime dateDebut) {
            List<DateTime> retour = new List<DateTime>();
            retour.Add(new DateTime(dateDebut.Year, dateDebut.Month, dateDebut.Day));
            retour.Add(new DateTime(dateDebut.Year, dateDebut.Month, dateDebut.Day+1));
            return retour;
        }


    }
}