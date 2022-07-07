using System;
using System.Text.Json;

namespace chat.domain
{
    public class ChatRepository
    {
        public static Chat ReadChatData()
        {
            var filePath = "/Users/Nastya/Desktop/С#/chat/chat/data/chat-data.json";
            var jsonString = File.ReadAllText(filePath);
            var chatData = JsonSerializer.Deserialize<Chat>(jsonString)!;
            return chatData;
        }
    }
}

