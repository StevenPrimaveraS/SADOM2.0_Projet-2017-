using Prj_Final_2017_.Models.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.Models.util {
    public class VADateHandler {
        internal static List<DateTime> reservationDates(string sDatesReservation) {
            List<DateTime> datesReservation = new List<DateTime>();
            try {
                string[] sDates = sDatesReservation.Split(';');

                foreach (string date in sDates) {
                    string[] infoDate = date.Split('-');
                    int day = int.Parse(infoDate[0]);
                    int month = int.Parse(infoDate[1]);
                    int year = int.Parse(infoDate[2]);
                    DateTime dateTime = new DateTime(year, month, day);
                    datesReservation.Add(dateTime);
                }
            }
            catch (FormatException e) {
                throw new VoyageAhuntsicException(1234);
            }
            catch (NullReferenceException e) {
                throw new VoyageAhuntsicException(1234);
            }
            return datesReservation;
        }
    }
}