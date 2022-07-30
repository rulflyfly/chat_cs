using System;
using System.Text.Json;
using chat.domain;

namespace chat
{
    public class UserRepository
    {
        private string _filePath;

        public UserRepository(string filePath)
        {
            this._filePath = filePath;
        }

        public List<User> GetAllUsers()
        {
            var jsonText = File.ReadAllText(_filePath);
            var allUsers = JsonSerializer.Deserialize<List<User>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return allUsers;
        }
    }
}

