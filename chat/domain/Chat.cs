using System;
using System.Text.Json;
namespace chat.domain
{
    public class Chat
    {
        public static List<Message> GetAllMessages()
        {
            return ReadChatData().Messages;
        }

        public static List<Message> GetUserMessages(string author)
        {
            var allMessages = ReadChatData().Messages;
            var filtered = new List<Message>();

            foreach (var message in allMessages)
            {
                if (message.Author == author)
                {
                    filtered.Add(message);
                }
            }

            return filtered;
        }

        static ChatData ReadChatData()
        {
            var filePath = "/Users/Nastya/Desktop/С#/chat/chat/data/chat-data.json";
            var jsonString = File.ReadAllText(filePath);
            var chatData = JsonSerializer.Deserialize<ChatData>(jsonString)!;
            return chatData;
        }
    }
}

