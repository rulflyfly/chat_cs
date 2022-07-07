using System;
using chat.domain;

namespace chat 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = Logger.LogIn();

            var mustBeCensored = user.Age < 18;

            ShowAllChatMessages(mustBeCensored);

            ShowChatMessagesByUserName(mustBeCensored);

        }

        static void ShowAllChatMessages(bool mustBeCensored)
        {
            var messages = ChatService.GetAllMessages();

            foreach (var message in messages)
            {
                if (mustBeCensored && message.NSFW)
                {
                    Logger.LogContentIsExplicit();
                    continue;
                }

                Logger.LogMessageToConsole(message);
            }
        }

        static void ShowChatMessagesByUserName(bool mustBeCensored)
        {
            var askSearchUser = true;

            while (askSearchUser)
            {
                var userName = Logger.AskToLogMessageByUser();

                var userMessages = ChatService.GetUserMessages(userName);

                if (userMessages.Count == 0)
                {
                    Logger.LogNoSuchUser();
                }
                else
                {
                    foreach (var userMessage in userMessages)
                    {
                        if (mustBeCensored && userMessage.NSFW)
                        {
                            Logger.LogContentIsExplicit();
                            continue;
                        }

                        Logger.LogMessageToConsole(userMessage);
                    }
                }

                askSearchUser = Logger.AskYesOrNo("Filter by another user?");
            }
        }
    }
}