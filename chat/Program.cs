using System;
using chat.domain;

namespace chat 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var messages = Chat.GetAllMessages();

            foreach (var message in messages)
            {
                Logger.LogMessageToConsole(message);
            }

            var askSearchUser = true;

            while (askSearchUser)
            {
                var user = Logger.AskToLogMessageByUser();

                var userMessages = Chat.GetUserMessages(user);

                if (userMessages.Count == 0)
                {
                    Logger.LogNoSuchUser();
                }
                else
                {
                    foreach (var userMessage in userMessages)
                    {
                        Logger.LogMessageToConsole(userMessage);
                    }
                }

                askSearchUser = Logger.AskYesOrNo("Filter by another user?");
            }

        }
    }
}