
using NodaTime;
using System;
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

var dhakaDatetime = "2023/01/17 12:21:40";
var dhakaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
var utcTimeZone = TimeZoneInfo.Utc;

var localDhaka = DateTime.Parse(dhakaDatetime, CultureInfo.GetCultureInfo("en-BD"), DateTimeStyles.AssumeLocal);
//var universalDhaka = DateTime.Parse(dhakaDatetime, CultureInfo.GetCultureInfo("en-BD"), DateTimeStyles.AssumeUniversal);

var localValid = dhakaTimeZone.IsInvalidTime(localDhaka);
utcTimeZone.IsInvalidTime(localDhaka);

//var localToLocalDateTimeCurrentCulture = new DateTime(result, CultureInfo.GetCultureInfo("en-BD"),timezor dhaka).ToLocalTime();

Console.WriteLine("");

var nowDateTime = DateTime.Now;
var nowDate = DateTime.Now.Date;
var yesterdayDateTime = DateTime.Now.AddDays(-1);
var yesterdayDate = DateTime.Now.Date.AddDays(-1);

Console.WriteLine("");


