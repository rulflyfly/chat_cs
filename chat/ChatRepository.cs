using System.Text.Json;
using chat.domain;

namespace chat
{
    public class ChatRepository
    {
        public string _filePath;

        public ChatRepository(string filePath)
        {
            this._filePath = filePath;
        }

        public List<Chat> ReadChatData()
        {
            var jsonString = File.ReadAllText(_filePath);
            var chatData = JsonSerializer.Deserialize<List<Chat>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return chatData;
        }

        public void WriteChatData(List<Chat> newChatData)
        {
            var newData = JsonSerializer.Serialize(newChatData)!;

            File.WriteAllText(_filePath, newData);
        }
    }
}


//public static List<User> ReadUserData()
//{
//    var jsonText = File.ReadAllText(filePath);
//    var allUsers = JsonSerializer.Deserialize<List<User>>(jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
//    return allUsers;
//}
