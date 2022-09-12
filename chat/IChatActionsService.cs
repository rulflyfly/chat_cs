using chat.domain;

namespace chat
{
    public interface IChatActionsService
    {
        void EditUserInfo(double userId);
        void SearchByUserName(double userId, Chat chat);
        void ShowAllChatMessages(double userId, Chat chat);
    }
}