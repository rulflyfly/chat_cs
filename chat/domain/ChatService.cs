using System.Text.Json;
namespace chat.domain
{
    public class ChatService : IChatService
    {
        private IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public List<Message> GetAllMessages(User authenticatedUser)
        {
            var chat = _chatRepository.ReadChatData();

            var messages = chat.GetMessagesVisibleToUser(authenticatedUser);

            return messages;
        }

        public List<Message> GetUserMessages(User authenticatedUser, string searchName)
        {
            var allMessages = GetAllMessages(authenticatedUser);
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

        public void WriteMessage(User user, string text)
        {
            var likes = new List<Like>();
            var newMessage = new Message(user.Id, text, likes, false);

            var chatData = _chatRepository.ReadChatData();
            chatData.Messages.Add(newMessage);

            var newChatData = JsonSerializer.Serialize(chatData)!;

            File.WriteAllText(ChatRepository.filePath, newChatData);
        }

        public List<string> ShowNumberedChatMessages()
        {
            var chatData = _chatRepository.ReadChatData();
            List<string> indices = new List<string>();

            for (var i = 0; i < chatData.Messages.Count; i++)
            {
                Logger.LogToConsole($"[{i + 1}] - {Utils.MakeMessageString(chatData.Messages[i])}");
                indices.Add($"{i + 1}");
            }
            return indices;
        }
    }
}

