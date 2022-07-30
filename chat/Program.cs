namespace chat 
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                ChatActionsService.RunChat(user);
            }
        }
    }
}