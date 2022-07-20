using System;
using System.Text.Json;

namespace chat.domain
{
    public class UserService
    {
        public static List<User> GetAllUsers()
        {
            return ChatRepository.ReadChatData().Users;
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

            var chatData = ChatRepository.ReadChatData();
            chatData.Users.Add(user);

            var newChatData = JsonSerializer.Serialize(chatData)!;

            File.WriteAllText(ChatRepository.filePath, newChatData);

            return user;
        }

        public static void UpdateUserInfo(User updatedUser)
        {
            var oldUser = GetUserById(updatedUser.Id);
            var users = GetAllUsers();
            var index = users.IndexOf(oldUser);

            users[index] = updatedUser;

            var chatData = ChatRepository.ReadChatData();
            chatData.Users = users;

            var newChatData = JsonSerializer.Serialize(chatData)!;

            File.WriteAllText(ChatRepository.filePath, newChatData);

        }
    }
}

