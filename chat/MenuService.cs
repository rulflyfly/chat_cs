﻿using chat.domain;

namespace chat
{
    public class MenuService
    {
        public static void ManageMenuOptions(User user)
        {
            var option = GetOption();

            switch (option)
            {
                case "*ALL":
                    ChatActionsService.ShowAllChatMessages(user);
                    break;
                case "*SEARCH":
                    ChatActionsService.SearchByUserName(user);
                    break;
                case "*EDIT_INFO":
                    ChatActionsService.EditUserInfo(user);
                    break;
                case "*BACK":
                    return;
            }
        }

        static string GetOption()
        {
            Logger.LogToConsole("To see all chat messages type *ALL");
            Logger.LogToConsole("To see all chat messages by specific user type *SEARCH");
            Logger.LogToConsole("To edit your personal info type *EDIT_INFO");
            Logger.LogToConsole("To go back to chat type *BACK");

            var option = Logger.GetInput();

            while (option != "*ALL" &&
                   option != "*SEARCH" &&
                   option != "*EDIT_INFO" &&
                   option != "*BACK")
            {
                Logger.LogToConsole("type *ALL, *SEARCH, *EDIT_INFO or *BACK");
                option = Logger.GetInput();
            }

            return option;
        }
    }
}
