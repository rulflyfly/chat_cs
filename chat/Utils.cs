using System;
namespace chat
{
    public class Utils
    {
        public static bool IsValidDate(string date)
        {
            try
            {
                DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int GetYearsDifference(DateTime start, DateTime end)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);

            TimeSpan span = end - start;
            
            return (zeroTime + span).Year - 1;
        }
    }
}

