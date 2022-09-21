namespace chat.domain
{
    public interface IChatService
    {
        List<Message> GetAllMessages(int userId, int chatId);
        List<Message> GetUserMessages(int chatId, int userId, string searchName);
    }
}