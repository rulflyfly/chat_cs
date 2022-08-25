using System.Text.Json;
namespace chat.domain
{
    public class ChatService
    {
        

        public List<Message> GetAllMessages(User authenticatedUser, Chat chat)
        {
            var messages = chat.GetMessagesVisibleToUser(authenticatedUser);

            return messages;
        }

        public List<Message> GetUserMessages(User authenticatedUser, string searchName, Chat chat)
        {
            var allMessages = GetAllMessages(authenticatedUser, chat);
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

        public static void WriteMessage(User user, string text, Chat chat)
        {
            var likes = new List<Like>();
            var newMessage = new Message(user.Id, text, likes, false);

           
            chat.Messages.Add(newMessage);

            var newChatData = JsonSerializer.Serialize(chat)!;

            File.WriteAllText(ChatRepository._filePath, newChatData);
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
    }
}

