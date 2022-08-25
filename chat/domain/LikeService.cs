using System.Text.Json;
using chat.domain;
using chat;

namespace chat
{
    public class LikeService
    {
        public void AddLikeToMessage(User user, Chat chat)
        {
            var messageNumber = GetMessageNumber();

            var newLike = new Like(Convert.ToString(user.Id));

            chat.Messages[messageNumber].Likes.Add(newLike);
           
            Logger.LogToConsole("Liked! You can keep chatting");
            ChatRepository.WriteChatData(chat);
            // нужно добавить "Функцию записи чата"
        }

        static int GetMessageNumber()
        {
            var messageIndices = ChatService.ShowNumberedChatMessages();

            Logger.LogToConsole("Type in the number of the message you like: ");
            var number = Logger.GetInput();
            while (!messageIndices.Contains(number))
            {
                Logger.LogToConsole("No message with this number. Try again: ");
                number = Logger.GetInput();
            }

            return Int32.Parse(number) - 1;
        }
    }
}

