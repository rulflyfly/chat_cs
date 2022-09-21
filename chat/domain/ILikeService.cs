using chat.domain;

namespace chat
{
    public interface ILikeService
    {
        void AddLikeToMessage(int userId, int chatId, int messageId);
    }
}