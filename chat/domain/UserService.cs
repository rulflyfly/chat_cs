using System.Text.Json;

namespace chat.domain
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void EditUserName(int userId, string newName)
        {
            var user = _userRepository.GetUserById(userId);
            
            user.Name = newName;

            _userRepository.EditUser(user);
        }

        public void EditUserBDay(int userId, string newbDay)
        {
            var user = _userRepository.GetUserById(userId);

            user.Birthday = newbDay;

            _userRepository.EditUser(user);
        }
    }
}

