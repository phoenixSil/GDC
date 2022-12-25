using System;

namespace Gdc.Features.Utils
{
    public static class UtilDateTime
    {
        public static int ComparerDeuxDate(DateTime dateDeDepart, DateTime dateDeFin)
        {
            var resultDate = dateDeDepart.CompareTo(dateDeFin);
            return resultDate ;
        }

        public static DateTime Convertir(this DateTime date)
        {
            var nouvelleDate = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
            return nouvelleDate;
        }

        public static DateTime AjusterLaDateDeFinSiNecessaire(DateTime dateDeDebut)
        {
            var finDeSession = dateDeDebut.AddHours(2);
            return finDeSession;
        }

        public static bool VerifierSiCetteDateNesPasUnWeekend(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
                return false;
            return true;
        }
    }
}
