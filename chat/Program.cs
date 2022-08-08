using chat.domain;

namespace chat 
{
    internal class Program
    {
        // solid
        // single responsibility
        // open closed
        // liskov substitution
        // interface segregation
        // dependency inversion

        static void Main(string[] args)
        {
            var chatActionsService = Compose();

            Logger.LogToConsole("Enter your name:");

            var userName = Logger.GetInput();
            var user = AuthService.GetSignedUpUser(userName);

            if (user == null)
            {
                Logger.LogToConsole("We're sorry but this chat is only for signed up users");
            }
            else
            {
                Logger.LogToConsole("You can chat. To access menu type *MENU");
                chatActionsService.RunChat(user);
            }
        }

        private static ChatActionsService Compose()
        {
            var chatRepository = new PostgresChatRepository();
            var chatService = new ChatService(chatRepository);
            var chatActionsService = new ChatActionsService(chatService);
            return chatActionsService;
        }
        // composition root
    }
}