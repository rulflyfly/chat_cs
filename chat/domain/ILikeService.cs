using chat.domain;

namespace chat
{
    public interface ILikeService
    {
        void AddLikeToMessage(double userId, Chat chat);
    }
}