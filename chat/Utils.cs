using System;
namespace chat
{
    public class Utils
    {
        public static bool IsValidNumber(string num)
        {
            try
            {
                Int32.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

