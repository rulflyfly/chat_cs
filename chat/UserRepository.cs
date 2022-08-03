using System;
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
    }
}

