using System;
using chat.domain;

namespace chat 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = LogInUser();

            var mustBeCensored = Utils.GetYearsDifference(user.Birthday, DateTime.Now) < 18;

            EditUserInfo(user);

            ShowAllChatMessages(mustBeCensored);

            Logger.AllowToChat();

            while (true)
            {
                var newMessage = Logger.TakeAnyInput();
                ChatService.WriteMessage(user, newMessage);
                ShowLoggedUserMessages(user.Name);
            }

        }

        static void ShowAllChatMessages(bool mustBeCensored)
        {
            var messages = ChatService.GetAllMessages();

            if (mustBeCensored) messages = ChatService.CensorMessages(messages);

            foreach (var message in messages)
            {
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
                if (mustBeCensored) userMessages = ChatService.CensorMessages(userMessages);

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

        static void ShowLoggedUserMessages(string name)
        {
            var messages = ChatService.GetUserMessages(name);
            if (messages.Count == 0) return;

            foreach (var message in messages)
            {
                Logger.LogMessageToConsole(message);
            }
        }

        static User LogInUser()
        {
            var name = Logger.GetUserNameFromConsole();
            var bday = Logger.GetUserBirthdayFromConsole();

            while (!Utils.IsValidDate(bday))
            {
                Logger.AskLogDateCorrect();
                bday = Logger.TakeAnyInput();
            }

            return new User { Name = name, Birthday = DateTime.Parse(bday) };
        }

        static void EditUserInfo(User user)
        {
            var editName = Logger.AskYesOrNo("Edit user name?");

            if (editName)
            {
                user.Name = Logger.GetUserNameFromConsole();
            }

            var editBirthday = Logger.AskYesOrNo("Edit user birthday?");


            if (editBirthday)
            {
                var bday = Logger.GetUserBirthdayFromConsole();

                while (!Utils.IsValidDate(bday))
                {
                    Logger.AskLogDateCorrect();
                    bday = Logger.TakeAnyInput();
                }

                user.Birthday = DateTime.Parse(bday);
            }
        }
    }
}