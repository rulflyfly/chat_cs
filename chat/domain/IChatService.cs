
namespace chat.domain
{
    public interface IChatService
    {
        List<Message> GetAllMessages(User authenticatedUser);
        List<Message> GetUserMessages(User authenticatedUser, string searchName);
        List<string> ShowNumberedChatMessages();
        void WriteMessage(User user, string text);
    }
}