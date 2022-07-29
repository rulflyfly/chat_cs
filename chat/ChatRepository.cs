using System.Text.Json;
using chat.domain;

namespace chat
{
    public class ChatRepository
    {
        public static readonly string filePath = "/Users/Nastya/Documents/learning/cs/chat/chat/data/chat-data.json";

        public static Chat ReadChatData()
        {
            var jsonString = File.ReadAllText(filePath);
            var chatData = JsonSerializer.Deserialize<Chat>(jsonString)!;
            return chatData;
        }
    }
}

