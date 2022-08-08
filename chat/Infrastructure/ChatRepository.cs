using System.Text.Json;
using chat.domain;

namespace chat
{
    public class ChatRepository : IChatRepository
    {
        public static readonly string filePath = "/Users/Nastya/Documents/learning/cs/chat/chat/data/chat-data.json";

        public Chat ReadChatData()
        {
            var jsonString = File.ReadAllText(filePath);
            var chatData = JsonSerializer.Deserialize<Chat>(jsonString)!;
            return chatData;
        }
    }
}

