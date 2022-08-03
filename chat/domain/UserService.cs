using System;
using System.Text.Json;
using chat;

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

        public static User SingUpUser(string name, string bday)
        {
            Random rnd = new Random();
            var id = rnd.Next(9999);

            var user = new User(id) { Name = name, Birthday = bday};

            var userData = UserRepository.ReadUserData();
            userData.Add(user);

            var newUserData = JsonSerializer.Serialize(userData)!;

            File.WriteAllText(UserRepository.filePath, newUserData);

            return user;
        }

        public static void UpdateUserInfo(User updatedUser)
        {
            var oldUser = GetUserById(updatedUser.Id);
            var users = GetAllUsers();
            var index = users.IndexOf(oldUser);

            users[index] = updatedUser;

            var newUserData = JsonSerializer.Serialize(users)!;

            File.WriteAllText(UserRepository.filePath, newUserData);

        }
    }
}

