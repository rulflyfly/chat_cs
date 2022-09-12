using chat.domain;

namespace chat
{
    public class ChatActionsService
    {
        IChatService _chatService;
        IChatRepository _chatRepository;
        IMenuService _menuService;
        ILikeService _likeService;

        public ChatActionsService(IChatService chatService, IChatRepository chatRepository, IMenuService menuService, ILikeService likeService)
        {
            _chatService = chatService;
            _chatRepository = chatRepository;
            _menuService = menuService;
            _likeService = likeService;
        }

        public void ShowAllChatMessages(double userId, Chat chat)
        {
            var messages = _chatService.GetAllMessages(userId, chat);

            foreach (var message in messages)
            {
                var messageString = Utils.MakeMessageString(message);
                Logger.LogToConsole(messageString);
            }
        }

        public void SearchByUserName(double userId, Chat chat)
        {
            var askSearchUser = true;

            while (askSearchUser)
            {
                Logger.LogToConsole("Type in user name: ");
                var userName = Logger.GetInput();

                var userMessages = _chatService.GetUserMessages(userId, userName, chat);

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

        public void ShowLoggedUserMessages(double userId, Chat chat)
        {
            var user = UserService.GetUserById(userId);
            var messages = _chatService.GetUserMessages(userId, user.Name, chat);
            if (messages.Count == 0) return;

            foreach (var message in messages)
            {
                var messageString = Utils.MakeMessageString(message);
                Logger.LogToConsole(messageString);
            }
        }


        public void EditUserInfo(double userId)
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

            UserRepository.EditUser(user);
        }

        public void RunChat(double userId, Chat chat)
        {
            while (true)
            {
                var newMessage = Logger.GetInput();
                if (newMessage == "*MENU")
                {
                    ManageChatActions(userId, chat);
                }
                if (newMessage == "*EXIT")
                {
                    break;
                }
                else if (newMessage != "*MENU")
                {
                    _chatRepository.WriteMessage(userId, newMessage, chat);
                    ShowLoggedUserMessages(userId, chat);
                }

            }
        }

        public string PickChat()
        {
            var chats = _chatRepository.ReadChatData();

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

        public void ManageChatActions(double userId, Chat chat)
        {
            var option = _menuService.GetOption();
            switch (option)
            {
                case "*ALL":
                    ShowAllChatMessages(userId, chat);
                    break;
                case "*SEARCH":
                    SearchByUserName(userId, chat);
                    break;
                case "*EDIT_INFO":
                    EditUserInfo(userId);
                    break;
                case "*ADD_LIKE":
                    _likeService.AddLikeToMessage(userId, chat);
                    break;
                case "*BACK":
                    return;
            }
        }

        public Chat GetCurrentChat(string chatName)
        {
            var chats = _chatRepository.ReadChatData();

            foreach (var chat in chats)
            {
                if (chat.Name == chatName) return chat;
            }

            return null;
        }
    }
}

