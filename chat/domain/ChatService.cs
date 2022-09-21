using System.Text.Json;
namespace chat.domain
{
    public class ChatService : IChatService
    {
        private IChatRepository _chatRepository;
        private IUserRepository _userRepository;

        public ChatService(IChatRepository chatRepository, IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        public List<Message> GetAllMessages(int userId, int chatId)
        {
            var chat = _chatRepository.GetChatById(chatId);
            var user = _userRepository.GetUserById(userId);
            var messages = chat.GetMessagesVisibleToUser(user);

            return messages;
        }

        public List<Message> GetUserMessages(int chatId, int userId, string searchName)
        {
            var chat = _chatRepository.GetChatById(chatId);
            var user = _userRepository.GetUserById(userId);
            var users = _userRepository.GetAllUsers();

            return chat.FilterMessagesByUserName(user, users, searchName);
        }

        public void WriteMessage(int chatId, int userId, string text)
        {
            _chatRepository.WriteMessage(chatId, userId, text);
        }
    }
}

