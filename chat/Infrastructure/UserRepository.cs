using System.Text.Json;
using chat.domain;

namespace chat
{
    public class UserRepository
    {
        public static readonly string filePath = "/Users/Nastya/Documents/learning/cs/chat/chat/data/users-data.json";
        public static List<User> ReadUserData()
        {
            var jsonText = File.ReadAllText(filePath);
            var allUsers = JsonSerializer.Deserialize<List<User>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return allUsers;
        }

        public static User AddUser(string name, string bday)
        {
            Random rnd = new Random();
            var id = rnd.Next(9999);

            var user = new User(id) { Name = name, Birthday = bday };

            var userData = UserRepository.ReadUserData();
            userData.Add(user);

            var newUserData = JsonSerializer.Serialize(userData)!;

            File.WriteAllText(UserRepository.filePath, newUserData);

            return user;
        }

        public static void EditUser(User editedUser)
        {
            var oldUser = UserService.GetUserById(editedUser.Id);
            var users = UserService.GetAllUsers();
            var index = users.IndexOf(oldUser);

            users[index] = editedUser;

            var newUserData = JsonSerializer.Serialize(users)!;

            File.WriteAllText(UserRepository.filePath, newUserData);
        }
    }
}

