using System;
using chat.domain;

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

        public static string MakeMessageString(Message message)
        {
            var userName = UserService.GetUserById(message.UserId).Name;
            return $"{userName}: {message.Text}; (likes: {message.Likes.Count})";
        }

        public static string WrapStringInQuotes(string input)
        {
            return @"""" + input + @"""";
        }
    }
}

