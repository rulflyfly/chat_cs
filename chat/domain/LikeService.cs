using System.Text.Json;
using chat.domain;
namespace chat
{
    public class LikeService
    {
        public static void AddLikeToMessage(User User, int MessageIndex, Chat Chat)
        {
            var newLike = new Like(Convert.ToString(User.Id));
            Chat.Messages[MessageIndex].Likes.Add(newLike);

            var newChatData = JsonSerializer.Serialize(Chat)!;
            File.WriteAllText(ChatRepository.filePath, newChatData);

            Logger.LogToConsole("Liked! You can keep chatting");
        }

        public static int GetMessageNumber(List<string> stringNumbers)
        {
            
            Logger.LogToConsole("Type in the number of the message you like: ");
            var number = Logger.GetInput();
            while (!stringNumbers.Contains(number))
            {
                Logger.LogToConsole("No message with this number. Try again: ");
                number = Logger.GetInput();
            }

            return Int32.Parse(number) - 1;
        }

        public static List<string> ShowNumberedChatMessages(Chat Chat)
        {
            List<string> indices = new List<string>();

            for (var i = 0; i < Chat.Messages.Count; i++)
            {
                Logger.LogToConsole($"[{i + 1}] - {Utils.MakeMessageString(Chat.Messages[i])}");
                indices.Add($"{i + 1}");
            }
            return indices;
        }
    }
}

