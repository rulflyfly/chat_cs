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

        public void AddLikeToMessage(int userId, int chatId, int messageId)
        {
            var chat = _chatRepository.GetChatById(chatId);

            var newLike = new Like(userId);
            var messageIndex = chat.FindMessageIndexByMessageId(messageId);

            chat.Messages[messageIndex].Likes.Add(newLike);

            var updatedChats = _chatRepository.GetUpdatedChatsData(chat);

            _chatRepository.WriteChatData(updatedChats);
        }
    }
}

