namespace chat.domain
{
    public interface IUserService
    {
        void EditUserName(int userId, string newName);
        void EditUserBDay(int userId, string newbDay);
    }
}