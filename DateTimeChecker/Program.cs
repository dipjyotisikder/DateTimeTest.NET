using System.Globalization;

DateTime UnixTimeStampToUTCDateTime(double unixTimeStamp)
{
    var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
    dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp);
    return dtDateTime;
}

long dateTimeEpoc = 1673932005944;

DateTime dateTime = UnixTimeStampToUTCDateTime(dateTimeEpoc);
var result = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
var result2 = dateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

Console.WriteLine(result);
Console.WriteLine("");

var datetimeParsed = DateTime.Parse(result);
var invariantCultureDateTime = DateTime.Parse(result, CultureInfo.InvariantCulture);
Console.WriteLine("{0} {1}", datetimeParsed, invariantCultureDateTime);
Console.WriteLine("");

var localDatetime = "17/01/2023 12:21:40";

var localDateTimeCurrentCulture = DateTime.Parse(result, CultureInfo.GetCultureInfo("en-BD"));
var localToUtcDateTimeCurrentCulture = DateTime.Parse(result, CultureInfo.GetCultureInfo("en-BD")).ToUniversalTime();
var localToLocalDateTimeCurrentCulture = DateTime.Parse(result, CultureInfo.GetCultureInfo("en-BD")).ToLocalTime();
Console.WriteLine("Local: {0}, \n" +
    "localDateTimeCurrentCulture: {1}, \n" +
    "localToUtcDateTimeCurrentCulture: {2} \n" +
    "localToLocalDateTimeCurrentCulture: {3}",
    localDatetime,
    localDateTimeCurrentCulture,
    localToUtcDateTimeCurrentCulture,
    localToLocalDateTimeCurrentCulture);

var data = TimeZoneInfo.GetSystemTimeZones();

var dhakaTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
/*var dhakaDatetime = "2023/01/18 15:36:00";
var localDhaka = DateTime.Parse(dhakaDatetime, CultureInfo.GetCultureInfo("en-BD"), DateTimeStyles.None);
var localValid = dhakaTimeZoneInfo.IsInvalidTime(localDhaka);
var isDaylightSaving = dhakaTimeZoneInfo.IsDaylightSavingTime(localDhaka);
var rule = dhakaTimeZoneInfo.GetAdjustmentRules().FirstOrDefault();
var daylightDelta = rule?.DaylightDelta;
var utcDateTimeConverted = TimeZoneInfo.ConvertTimeToUtc(localDhaka, dhakaTimeZoneInfo);*/


var australiaTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
var australiaDatetime = "18/01/2023 17:12:00";
var systemZones = TimeZoneInfo.GetSystemTimeZones();
var australiaLocal = DateTime.Parse(australiaDatetime, CultureInfo.GetCultureInfo("en-AU"));
var australiaLocalValid = australiaTimeZoneInfo.IsInvalidTime(australiaLocal);
var australiaIsDaylightSaving = australiaTimeZoneInfo.IsDaylightSavingTime(australiaLocal);
var australiaRule = australiaTimeZoneInfo.GetAdjustmentRules().FirstOrDefault();
var australiaDaylightDelta = australiaRule?.DaylightDelta;

var australiaUtcDateTimeConverted = TimeZoneInfo.ConvertTimeToUtc(australiaLocal, australiaTimeZoneInfo);
// So! Send this australiaUtcDateTimeConverted UTC time to front-end.



var australiaToDhakaDateTimeConvertedFromUTC = TimeZoneInfo.ConvertTimeFromUtc(australiaUtcDateTimeConverted, dhakaTimeZoneInfo);


// Conversion
Console.WriteLine("");

var nowDateTime = DateTime.Now;
var nowDate = DateTime.Now.Date;
var utcNowDate = DateTime.UtcNow.Date;
var yesterdayDateTime = DateTime.Now.AddDays(-1);
var yesterdayDate = DateTime.Now.Date.AddDays(-1);

Console.WriteLine("");


// During user input
void SaveLocalDateTime(string localDateTime, string systemTimezoneId)
{
    var localParsed = DateTime.Parse(localDateTime, CultureInfo.GetCultureInfo("en-AU"));
    // SAVE NOW localParsed IN DB
    // Save systemTimezoneId also
};


// During user date-time retrieval
DateTime GetUserDateTime()
{
    var user = new Tuple<string, DateTime, string>(item1: "dip", item2: DateTime.Now, item3: "Bangladesh Standard Time");

    var timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById(user.Item3);
    var utcDateTime = TimeZoneInfo.ConvertTimeToUtc(user.Item2, timezoneInfo);
    return utcDateTime;
};

// When user changes his location.
DateTime ChangeUsersLocation(string destinationSystemTimezoneId)
{
    var destinationTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(destinationSystemTimezoneId);

    var user = new Tuple<string, DateTime, string>(item1: "dip", item2: DateTime.Now, item3: "Bangladesh Standard Time");
    var timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById(user.Item3);
    var utcDateTime = TimeZoneInfo.ConvertTimeToUtc(user.Item2, timezoneInfo);
    var destinationDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, destinationTimeZoneInfo);
    return destinationDateTime;
};

