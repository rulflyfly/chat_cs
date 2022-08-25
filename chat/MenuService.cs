using chat.domain;

namespace chat
{
    public class MenuService
    {
        //public Chat GetChatByName(string chatNameUserInput)
        //{

        //    switch (chatNameUserInput)
        //    {
        //        case "*MAIN_CHAT":
        //            var mainChatData = new ChatRepository("data/chat-data.json");
        //            return mainChatData.ReadChatData();
        //        case "*WORK_CHAT":
        //            var workChatData = new ChatRepository("");
        //            return workChatData.ReadChatData();
        //    }
        //    return null;
        //}

        //public string GetChatNameFromUser()
        //{
        //    Logger.LogToConsole("*MAIN_CHAT");
        //    Logger.LogToConsole("*WORK_CHAT");

        //    var option = Logger.GetInput();

        //    while (option != "*MAIN_CHAT" &&
        //           option != "*WORK_CHAT")
        //    {
        //        Logger.LogToConsole("Type *MAIN_CHAT or *WORK_CHAT");
        //        option = Logger.GetInput();
        //    }
        //    return option;
        //}
        // еуые
        public static void ManageMenuOptions(double userId, Chat chat)
        {
            var option = GetOption();

            switch (option)
            {
                case "*ALL":
                    ChatActionsService.ShowAllChatMessages(userId, chat);
                    break;
                case "*SEARCH":
                    ChatActionsService.SearchByUserName(userId, chat);
                    break;
                case "*EDIT_INFO":
                    ChatActionsService.EditUserInfo(userId);
                    break;
                case "*ADD_LIKE":
                    var likeService = new LikeService();
                    likeService.AddLikeToMessage(userId, chat);
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

