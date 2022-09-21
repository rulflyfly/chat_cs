using System.Text.Json;
using chat.domain;

namespace chat
{
    public class UserRepository : IUserRepository
    {
        public static readonly string filePath = "/Users/Nastya/Documents/learning/cs/chat/chat/data/users-data.json";
        public List<User> GetAllUsers()
        {
            var jsonText = File.ReadAllText(filePath);
            var allUsers = JsonSerializer.Deserialize<List<User>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return allUsers;
        }

        public User GetUserById(int userId)
        {
            var users = GetAllUsers();

            foreach (var user in users)
            {
                if (user.Id == userId) return user;
            }

            return null;
        }

        public User GetUserByName(string name)
        {
            var users = GetAllUsers();

            foreach (var user in users)
            {
                if (user.Name == name) return user;
            }

            return null;
        }

        public User AddUser(string name, string bday)
        {
            Random rnd = new Random();
            var id = rnd.Next(9999);

            var user = new User(id) { Name = name, Birthday = bday };

            var userData = GetAllUsers();
            userData.Add(user);

            var newUserData = JsonSerializer.Serialize(userData)!;

            File.WriteAllText(filePath, newUserData);

            return user;
        }

        public void EditUser(User editedUser)
        {
            var oldUser = GetUserById(editedUser.Id);
            var users = GetAllUsers();
            var index = users.IndexOf(oldUser);

            users[index] = editedUser;

            var newUserData = JsonSerializer.Serialize(users)!;

            File.WriteAllText(filePath, newUserData);
        }
    }
}

