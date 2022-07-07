using System;
namespace chat
{
    public class Logger
    {
        public static void LogMessageToConsole(Message message)
        {
           Console.WriteLine($"{message.Author}: {message.Text}; (likes: {message.Likes.Count})");
        }

        public static string AskToLogMessageByUser()
        {
            Console.WriteLine("Type in user name: ");
            return Console.ReadLine();
        }

        public static void LogNoSuchUser()
        {
            Console.WriteLine("There's no such user");
        }

        public static bool AskYesOrNo(string question)
        {
            Console.WriteLine($"{question} y/n");

            string answer = Console.ReadLine();

            while (answer != "y" && answer != "n")
            {
                Console.WriteLine("type 'y' or 'n'");
                answer = Console.ReadLine();
            }

            if (answer == "n") return false;

            return true;
        }
    }
}

