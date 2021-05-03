using System;
using System.Globalization;

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
    }
}