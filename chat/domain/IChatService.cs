namespace chat.domain
{
    public interface IChatService
    {
        List<Message> GetAllMessages(double userId, Chat chat);
        List<Message> GetUserMessages(double userId, string userName, Chat chat);
    }
}