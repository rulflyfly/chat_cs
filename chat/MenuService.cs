using chat.domain;

namespace chat
{
    public class MenuService : IMenuService
    {
        public string GetOption()
        {
            Logger.LogToConsole("To see all chat messages type *ALL");
            Logger.LogToConsole("To see all chat messages by specific user type *SEARCH");
            Logger.LogToConsole("To edit your personal info type *EDIT_INFO");
            Logger.LogToConsole("To add a like to any message type *ADD_LIKE");
            Logger.LogToConsole("To go back to chat type *BACK");

            var option = Logger.GetInput();

            while (option != "*ALL" &&
                   option != "*SEARCH" &&
                   option != "*EDIT_INFO" &&
                   option != "*ADD_LIKE" &&
                   option != "*BACK")
            {
                Logger.LogToConsole("type *ALL, *SEARCH, *EDIT_INFO, *ADD_LIKE or *BACK");
                option = Logger.GetInput();
            }

            return option;
        }
    }
}

