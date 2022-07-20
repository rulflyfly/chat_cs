using System;

namespace chat
{
    public class Logger
    {
        public static void LogToConsole(string text)
        {
            Console.WriteLine(text);
        }

        public static string GetInput()
        {
            return Console.ReadLine();
        }

        public static bool GetConsent(string question)
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

