using System;
using System.Text.Json;
using chat.domain;

namespace chat
{
    public class ChatRepository
    {
        static readonly string filePath = "/Users/Nastya/Documents/learning/С#/chat/chat/data/chat-data.json";

        public static Chat ReadChatData()
        {
            var jsonString = File.ReadAllText(filePath);
            var chatData = JsonSerializer.Deserialize<Chat>(jsonString)!;
            return chatData;
        }

        public static void AddMessageToChatData(Message message)
        {
            var jsonString = File.ReadAllText(filePath);
            var chatData = JsonSerializer.Deserialize<Chat>(jsonString)!;
            chatData.Messages.Add(message);
            var newChatData = JsonSerializer.Serialize(chatData)!;

            File.WriteAllText(filePath, newChatData);
        }
    }
}

