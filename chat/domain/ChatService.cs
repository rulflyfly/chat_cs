using System.Text.Json;
namespace chat.domain
{
    public class ChatService
    {
        

        public List<Message> GetAllMessages(double userId, Chat chat)
        {
            var user = UserService.GetUserById(userId);
            var messages = chat.GetMessagesVisibleToUser(user);

            return messages;
        }

        public List<Message> GetUserMessages(double userId, string searchName, Chat chat)
        {
            var allMessages = GetAllMessages(userId, chat);
            var filtered = new List<Message>();

            foreach (var message in allMessages)
            {
                if (UserService.GetUserById(message.UserId).Name == searchName)
                {
                    filtered.Add(message);
                }
            }

            return filtered;
        }

        public static void WriteMessage(double userId, string text, Chat chat)
        {
            var likes = new List<Like>();
            var newMessage = new Message(userId, text, likes, false);

            var updatedChat = chat;

            updatedChat.Messages.Add(newMessage);

            var newChatData = JsonSerializer.Serialize(GetUpdatedChatsData(updatedChat))!;

            var chatRepository = new ChatRepository("data/chat-data.json");

            File.WriteAllText(chatRepository._filePath, newChatData);
        }

        public List<string> ShowNumberedChatMessages(Chat chat)
        {
           
            List<string> indices = new List<string>();

            for (var i = 0; i < chat.Messages.Count; i++)
            {
                Logger.LogToConsole($"[{i + 1}] - {Utils.MakeMessageString(chat.Messages[i])}");
                indices.Add($"{i + 1}");
            }
            return indices;
        }

        public static Chat GetCurrentChat(string chatName)
        {
            var chatRepository = new ChatRepository("data/chat-data.json");
            var chats = chatRepository.ReadChatData();


            foreach (var chat in chats)
            {
                if (chat.Name == chatName) return chat;
            }

            return null;
        }

        public static List<Chat> GetUpdatedChatsData(Chat updatedChat)
        {
            var chatRepository = new ChatRepository("data/chat-data.json");
            var chats = chatRepository.ReadChatData();

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
    }
}

