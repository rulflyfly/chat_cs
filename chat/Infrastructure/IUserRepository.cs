namespace chat.domain
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserByName(string name);
        User AddUser(string name, string bday);
        void EditUser(User editedUser);
    }
}