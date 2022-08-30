using System.Text.Json;
using chat.domain;
using chat;

namespace chat
{
    public class LikeService
    {
        public void AddLikeToMessage(double userId, Chat chat)
        {
            var messageNumber = GetMessageNumber(chat);

            var newLike = new Like(Convert.ToString(userId));

            chat.Messages[messageNumber].Likes.Add(newLike);

            var updatedChats = ChatService.GetUpdatedChatsData(chat);


            Logger.LogToConsole("Liked! You can keep chatting");
            var chatRepository = new ChatRepository("data/chat-data.json");
            chatRepository.WriteChatData(updatedChats);
            // нужно добавить "Функцию записи чата"
        }

        static int GetMessageNumber(Chat chat)
        {
            var chatService = new ChatService();
            var messageIndices = chatService.ShowNumberedChatMessages(chat);

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

