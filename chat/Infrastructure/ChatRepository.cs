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

        public void WriteMessage(double userId, string text, Chat chat)
        {
            var likes = new List<Like>();
            var newMessage = new Message(userId, text, likes, false);

            var updatedChat = chat;

            updatedChat.Messages.Add(newMessage);

            var newChatData = JsonSerializer.Serialize(GetUpdatedChatsData(updatedChat))!;


            File.WriteAllText(filePath, newChatData);
        }
    }
}
