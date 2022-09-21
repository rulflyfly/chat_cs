using System;
using System.Text.Json;
using chat.domain;

namespace chat
{
    public class ChatRepository : IChatRepository
    {
        private string filePath = "/Users/Nastya/Documents/learning/cs/chat/chat/data/chat-data.json";

        public List<Chat> ReadChatData()
        {
            var jsonString = File.ReadAllText(filePath);
            var chatData = JsonSerializer.Deserialize<List<Chat>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return chatData;
        }

        public Chat GetChatById(int chatId)
        {
            var chats = ReadChatData();
            var _chat = new Chat(0, null, null);
            foreach (var chat in chats)
            {
                if (chat.Id == Convert.ToDouble(chatId))
                {
                    _chat = chat;
                }
            }

            if (_chat.Id == 0) return null;

            return _chat;
        }

        public List<Chat> GetUpdatedChatsData(Chat updatedChat)
        {
            var chats = ReadChatData();

            foreach (var chat in chats)
            {
                if (chat.Name == updatedChat.Name)
                {
                    chats[chats.IndexOf(chat)] = updatedChat;
                    break;
                }
            }

            return chats;
        }

        public void WriteChatData(List<Chat> chats)
        {
            var newData = JsonSerializer.Serialize(chats)!;

            File.WriteAllText(filePath, newData);
        }

        public void WriteMessage(int chatId, int userId, string text)
        {
            var likes = new List<Like>();
            Random rnd = new Random();
            var messageId = rnd.Next(9999);
            var newMessage = new Message(messageId, userId, text, likes, false);

            var updatedChat = GetChatById(chatId);

            updatedChat.Messages.Add(newMessage);

            var newChatData = JsonSerializer.Serialize(GetUpdatedChatsData(updatedChat))!;


            File.WriteAllText(filePath, newChatData);
        }

    }
}
