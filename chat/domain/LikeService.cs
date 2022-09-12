using System.Text.Json;
using chat.domain;
using chat;

namespace chat
{
    public class LikeService : ILikeService
    {
        private IChatRepository _chatRepository;

        public LikeService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public void AddLikeToMessage(double userId, Chat chat)
        {
            var messageNumber = GetMessageNumber(chat);

            var newLike = new Like(Convert.ToString(userId));

            chat.Messages[messageNumber].Likes.Add(newLike);

            var updatedChats = _chatRepository.GetUpdatedChatsData(chat);


            Logger.LogToConsole("Liked! You can keep chatting");
            _chatRepository.WriteChatData(updatedChats);
        }

        static int GetMessageNumber(Chat chat)
        {
            var messageIndices = ShowNumberedChatMessages(chat);

            Logger.LogToConsole("Type in the number of the message you like: ");
            var number = Logger.GetInput();
            while (!messageIndices.Contains(number))
            {
                Logger.LogToConsole("No message with this number. Try again: ");
                number = Logger.GetInput();
            }

            return Int32.Parse(number) - 1;
        }


        private static List<string> ShowNumberedChatMessages(Chat chat)
        {
            List<string> indices = new List<string>();

            for (var i = 0; i < chat.Messages.Count; i++)
            {
                Logger.LogToConsole($"[{i + 1}] - {Utils.MakeMessageString(chat.Messages[i])}");
                indices.Add($"{i + 1}");
            }
            return indices;
        }
    }
}

