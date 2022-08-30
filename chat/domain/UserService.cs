using System.Text.Json;

namespace chat.domain
{
    public class UserService
    {
        public static List<User> GetAllUsers()
        {
            var allUsers = UserRepository.ReadUserData();

            return allUsers;
        }

        public static User GetUserById(double userId)
        {
            var users = GetAllUsers();

            foreach (var user in users)
            {
                if (user.Id == userId) return user;
            }

            return null;
        }

        public static User GetUserByName(string name)
        {
            var users = GetAllUsers();

            foreach (var user in users)
            {
                if (user.Name == name) return user;
            }

            return null;
        }
    }
}

