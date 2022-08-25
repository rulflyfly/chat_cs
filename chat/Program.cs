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
               
                var userInput = menuService.GetChatNameFromUser();
                var chat = menuService.GetChatByName(userInput);

                Logger.LogToConsole("You can chat. To access menu type *MENU");
                ChatActionsService.RunChat(user, chat);
            }

            
        }
    }
}