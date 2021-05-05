using System;
using System.Globalization;
using NoorsoftHomework.Web.Exceptions;

namespace NoorsoftHomework.Web.Helpers
{
    public static class Date
    {
        private static readonly PersianCalendar PersianCalendar = new();

        public static string ToPersianDate(this DateTime dateTime)
        {
            var persianDate =
                $"{PersianCalendar.GetYear(dateTime)}/{PersianCalendar.GetMonth(dateTime)}/{PersianCalendar.GetDayOfMonth(dateTime)}";
            return persianDate;
        }

        public static int TillNowInYears(this DateTime dateTime)
        {
            var today    = DateTime.Today;
            var duration = today - dateTime;
            if (duration.Days <= 0) return 0;
            var years = duration.ToDateTime().Year - 1;
            return years;
        }

        private static readonly DateTime ZeroTime = new(1, 1, 1);
        private static          DateTime ToDateTime(this TimeSpan duration) => ZeroTime + duration;

        public static DateTime PersianToDateTime(this string persianDate)
        {
            var      dateArray = persianDate.Split('/');
            var      year      = int.Parse(dateArray[0]);
            var      month     = int.Parse(dateArray[1]);
            var      day       = int.Parse(dateArray[2]);
            DateTime dateTime;
            try
            {
                dateTime = PersianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new DateOutOfRangeException();
            }

            return dateTime;
        }
    }
}