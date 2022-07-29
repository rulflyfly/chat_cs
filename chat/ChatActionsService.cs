﻿using chat.domain;

namespace chat
{
    public class ChatActionsService
    {
        public static void ShowAllChatMessages(User user)
        {
            var messages = ChatService.GetAllMessages(user);

            foreach (var message in messages)
            {
                var messageString = Utils.MakeMessageString(message);
                Logger.LogToConsole(messageString);
            }
        }

        public static void SearchByUserName(User user)
        {
            var askSearchUser = true;

            while (askSearchUser)
            {
                Logger.LogToConsole("Type in user name: ");
                var userName = Logger.GetInput();

                var userMessages = ChatService.GetUserMessages(user, userName);

                if (userMessages.Count == 0)
                {
                    Logger.LogToConsole("There's no such user");
                }
                else
                {
                    foreach (var userMessage in userMessages)
                    {
                        var messageString = Utils.MakeMessageString(userMessage);
                        Logger.LogToConsole(messageString);
                    }
                }

                askSearchUser = Logger.GetConsent("Filter by another user?");
            }
        }

        public static void ShowLoggedUserMessages(User user, string name)
        {
            var messages = ChatService.GetUserMessages(user, name);
            if (messages.Count == 0) return;

            foreach (var message in messages)
            {
                var messageString = Utils.MakeMessageString(message);
                Logger.LogToConsole(messageString);
            }
        }


        public static void EditUserInfo(User user)
        {
            var editName = Logger.GetConsent("Edit user name?");

            if (editName)
            {
                Logger.LogToConsole("Your name:");
                user.Name = Logger.GetInput();
            }

            var editBirthday = Logger.GetConsent("Edit user birthday?");

            if (editBirthday)
            {
                Logger.LogToConsole("Your birthday MM/DD/YYYY:");
                var bday = Logger.GetInput();

                while (!Utils.IsValidDate(bday))
                {
                    Logger.LogToConsole("Type in this format MM/DD/YYYY:");
                    bday = Logger.GetInput();
                }

                user.Birthday = bday;
            }

            Logger.LogToConsole("Successfully edited! You can keep chatting");

            UserService.UpdateUserInfo(user);
        }

        public static void RunChat(User user)
        {
            while (true)
            {
                var newMessage = Logger.GetInput();
                if (newMessage == "*MENU")
                {
                    MenuService.ManageMenuOptions(user);
                }
                else
                {
                    ChatService.WriteMessage(user, newMessage);
                    ChatActionsService.ShowLoggedUserMessages(user, user.Name);
                }

            }
        }
    }
}
