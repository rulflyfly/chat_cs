using System;
using chat.domain;

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

        public static User LogIn()
        {
            Console.WriteLine("Enter your name:");

            var name = Console.ReadLine();

            Console.WriteLine("Enter your age:");

            var age = Console.ReadLine();

            while (!Utils.IsValidNumber(age))
            {
                Console.WriteLine("Enter a valid number for age:");
                age = Console.ReadLine();
            }

            return new User(name, Int32.Parse(age));

        }

        public static void LogContentIsExplicit()
        {
            Console.WriteLine("Explicit content");
        }

        
    }
}

