using System;
using chat.domain;
using chat;

namespace chat 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.LogToConsole("Enter your name:");

            var userName = Logger.GetInput();
            var user = UserService.GetUserByName(userName);

            bool bRunChat = false;

            if (user == null)
            {
                bool bSignUpNewUser = Logger.GetConsent($"There's no user named {userName}. Sing up?");

                if (bSignUpNewUser)
                {
                    user = GetSingedUpUser();
                    bRunChat = true;
                }
            }
            else bRunChat = true;

            if (bRunChat)
            {
                Logger.LogToConsole("You can chat. To access menu type *MENU");
                RunChat(user);
            }
            else
            {
                Logger.LogToConsole("We're sorry but this chat is only for signed up users");
            }
        }

        static string GetOption()
        {
            Logger.LogToConsole("To see all chat messages type *ALL");
            Logger.LogToConsole("To see all chat messages by specific user type *SEARCH");
            Logger.LogToConsole("To edit your personal info type *EDIT_INFO");
            Logger.LogToConsole("To add a like to any message type *ADD_LIKE");
            Logger.LogToConsole("To go back to chat type *BACK");

            var option = Logger.GetInput();

            while (option != "*ALL" &&
                   option != "*SEARCH" &&
                   option != "*EDIT_INFO" &&
                   option != "*ADD_LIKE" &&
                   option != "*BACK")
            {
                Logger.LogToConsole("type *ALL, *SEARCH, *EDIT_INFO, *ADD_LIKE or *BACK");
                option = Logger.GetInput();
            }

            return option;
        }

        static void ManageMenuOptions(User user)
        {
            var option = GetOption();

            switch(option)
            {
                case "*ALL":
                    ShowAllChatMessages(user);
                    break;
                case "*SEARCH":
                    SearchByUserName(user);
                    break;
                case "*EDIT_INFO":
                    EditUserInfo(user);
                    break;
                case "*ADD LIKE":
                    Like.AddLikeToAMessage(user);
                    break;
                case "*BACK":
                    return;
            }
        }
    
        static User GetSingedUpUser()
        {
            Logger.LogToConsole("Your name:");
            var name = Logger.GetInput();

            Logger.LogToConsole("Your birthday MM/DD/YYYY:");
            var bday = Logger.GetInput();

            while (!Utils.IsValidDate(bday))
            {
                Logger.LogToConsole("Type in this format MM/DD/YYYY:");
                bday = Logger.GetInput();
            }

            return UserService.SingUpUser(name, bday);
        }

        static void RunChat(User user)
        {
            while (true)
            {
                var newMessage = Logger.GetInput();
                if (newMessage == "*MENU")
                {
                    ManageMenuOptions(user);
                }
                else
                {
                    ChatService.WriteMessage(user, newMessage);
                    ShowLoggedUserMessages(user, user.Name);
                }
                
            }
        }



        static void ShowAllChatMessages(User user)
        {
            var messages = ChatService.GetAllMessages(user);

            foreach (var message in messages)
            {
                var messageString = Utils.MakeMessageString(message);
                Logger.LogToConsole(messageString);
            }
        }

        static void SearchByUserName(User user)
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

        static void ShowLoggedUserMessages(User user, string name)
        {
            var messages = ChatService.GetUserMessages(user, name);
            if (messages.Count == 0) return;

            foreach (var message in messages)
            {
                var messageString = Utils.MakeMessageString(message);
                Logger.LogToConsole(messageString);
            }
        }

        static void EditUserInfo(User user)
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

        


    }
}