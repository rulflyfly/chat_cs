using chat.domain;

namespace chat
{
    public class ChatActionsService
    {
        public static void ShowAllChatMessages(double userId, Chat chat)
        {
            var chatService = new ChatService();
            var messages = chatService.GetAllMessages(userId, chat);

            foreach (var message in messages)
            {
                var messageString = Utils.MakeMessageString(message);
                Logger.LogToConsole(messageString);
            }
        }

        public static void SearchByUserName(double userId, Chat chat)
        {
            var askSearchUser = true;

            while (askSearchUser)
            {
                Logger.LogToConsole("Type in user name: ");
                var userName = Logger.GetInput();

                var chatService = new ChatService();

                var userMessages = chatService.GetUserMessages(userId, userName, chat);

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

        public static void ShowLoggedUserMessages(double userId, Chat chat)
        {
            var chatService = new ChatService();
            var user = UserService.GetUserById(userId);
            var messages = chatService.GetUserMessages(userId, user.Name, chat);
            if (messages.Count == 0) return;

            foreach (var message in messages)
            {
                var messageString = Utils.MakeMessageString(message);
                Logger.LogToConsole(messageString);
            }
        }


        public static void EditUserInfo(double userId)
        {
            var user = UserService.GetUserById(userId);
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

        public static void RunChat(double userId, Chat chat)
        {
            while (true)
            {
                var newMessage = Logger.GetInput();
                if (newMessage == "*MENU")
                {
                    MenuService.ManageMenuOptions(userId, chat);
                }
                if (newMessage == "*EXIT")
                {
                    break;
                }
                else
                {
                    ChatService.WriteMessage(userId, newMessage, chat);
                    ShowLoggedUserMessages(userId, chat);
                }

            }
        }

        public static string PickChat()
        {
            var chatRepository = new ChatRepository("data/chat-data.json");
            var chats = chatRepository.ReadChatData();

            List<string> chatNames = new List<string>();

            foreach (var chat in chats)
            {
                chatNames.Add(chat.Name);
            }

            Logger.LogToConsole("Pick a chat:");

            foreach (var chatName in chatNames)
            {
                Logger.LogToConsole(chatName);
            }

            var pickedChatName = Logger.GetInput();

            while (!chatNames.Contains(pickedChatName))
            {
                Logger.LogToConsole("Choose from existing names: ");
                foreach (var chatName in chatNames)
                {
                    Logger.LogToConsole(chatName);
                }
                pickedChatName = Logger.GetInput();
            }

            return pickedChatName;
        }
    }
}

