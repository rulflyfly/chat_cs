using chat.domain;

namespace chat 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // infrastructure
            var menuService = new MenuService();


            // domain
            Logger.LogToConsole("Enter your name:");

            var userName = Logger.GetInput();
            var user = AuthService.GetSignedUpUser(userName);

            if (user == null)
            {
                Logger.LogToConsole("We're sorry but this chat is only for signed up users");
            }
            else
            {
                while (true)
                {
                    var chatActionService = Compose();
                    var chatName = chatActionService.PickChat();
                    var chat = chatActionService.GetCurrentChat(chatName);
                    Logger.LogToConsole("You can chat. To access menu type *MENU, to exit chat type *EXIT");
                    chatActionService.RunChat(user.Id, chat);
                }
                
            }

        }

        private static ChatActionsService Compose()
        {
            var chatRepository = new ChatRepository();
            var chatService = new ChatService();
            var menuService = new MenuService();
            var likeService = new LikeService(chatRepository);

            return new ChatActionsService(chatService, chatRepository, menuService, likeService);
        }
    }
}