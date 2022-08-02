using System;
using chat;

namespace chat.domain
{
    public record Like (string Author)
    {

       public static void AddLikeToAMessage(User user)
        {
            var chat = ChatRepository.ReadChatData();
            var messageNumber = Utils.GetMessageNumber(chat);
            Utils.CreateLike(messageNumber, chat, user);
        }
    }
}

