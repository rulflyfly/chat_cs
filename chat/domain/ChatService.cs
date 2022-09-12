using System.Text.Json;
namespace chat.domain
{
    public class ChatService : IChatService
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
    }
}

