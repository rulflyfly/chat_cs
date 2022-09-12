using chat.domain;

namespace chat
{
    public class AuthService
    {
        public static User GetSignedUpUser(string userName)
        {
            var user = UserService.GetUserByName(userName);

            if (user == null)
            {
                bool bSignUpNewUser = Logger.GetConsent($"There's no user named {userName}. Sing up?");

                if (bSignUpNewUser)
                {
                    user = GetSingedUpUser();
                }
                else
                {
                    return null;
                }
            }

            return user;
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

            return UserRepository.AddUser(name, bday);
        }
    }
}

