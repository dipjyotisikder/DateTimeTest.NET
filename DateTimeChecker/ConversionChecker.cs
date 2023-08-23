namespace DateTimeChecker
{
    public class ConversionChecker
    {
        public void ConvertGMTToUTC()
        {
            string inputTime = "2023-08-24T02:53:40:988 GMT+0600";
            DateTime originalDateTime = DateTime.Parse(inputTime);

            // Convert to UTC
            DateTime utcDateTime = originalDateTime.ToUniversalTime();

            // Format in UTC with "Z" at the end
            string formattedUtcTime = utcDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            Console.WriteLine("Original Time: " + inputTime);
            Console.WriteLine("Formatted UTC Time: " + formattedUtcTime);

        }
    }
}
