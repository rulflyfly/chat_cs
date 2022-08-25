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

        public Chat ReadChatData()
        {
            var jsonString = File.ReadAllText(_filePath);
            var chatData = JsonSerializer.Deserialize<Chat>(jsonString)!;
            return chatData;
        }

        public void WriteChatData(Chat newChatData)
        {
            var newData = JsonSerializer.Serialize(newChatData)!;

            File.WriteAllText(_filePath, newData);
        }
    }
}

