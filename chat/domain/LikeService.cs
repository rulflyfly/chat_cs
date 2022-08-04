using System.Text.Json;
using chat.domain;
namespace chat
{
    public class LikeService
    {
        public static void AddLikeToMessage(User user)
        {
            var chatData = ChatRepository.ReadChatData();
            var messageNumber = GetMessageNumber();

            var newLike = new Like(Convert.ToString(user.Id));

            chatData.Messages[messageNumber].Likes.Add(newLike);
            var newChatData = JsonSerializer.Serialize(chatData)!;

            File.WriteAllText(ChatRepository.filePath, newChatData);

            Logger.LogToConsole("Liked! You can keep chatting");
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

