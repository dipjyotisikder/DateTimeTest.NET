namespace DateTimeChecker
{
    internal static class DateTimeExtension
    {
        public const string UTC = "UTC";

        public static DateTime Convert(this DateTime date, string fromZone, string toZone)
        {
            TimeZoneInfo to = TimeZoneInfo.FindSystemTimeZoneById(toZone);
            TimeZoneInfo from = TimeZoneInfo.FindSystemTimeZoneById(fromZone);
            return new DateTime(TimeZoneInfo.ConvertTime(date, from, to).Ticks, DateTimeKind.Unspecified);
        }

        public static bool IsDayLightSaving(this DateTime date, string zone)
        {
            TimeZoneInfo to = TimeZoneInfo.FindSystemTimeZoneById(zone);
            return to.IsDaylightSavingTime(date);
        }

        public static DateTime ConvertToUTC(this DateTime date, string fromZone)
        {
            return date.Convert(fromZone, UTC);
        }

        public static DateTime ConvertToLocal(this DateTime date, string toZone)
        {
            return date.Convert(UTC, toZone);
        }
    }
}
