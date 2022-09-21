namespace chat.domain
{
    public interface IChatRepository
    {
        List<Chat> ReadChatData();
        List<Chat> GetUpdatedChatsData(Chat chat);
        void WriteChatData(List<Chat> chats);
        void WriteMessage(int chatId, int userId, string text);
        Chat GetChatById(int chatId);
    }
}