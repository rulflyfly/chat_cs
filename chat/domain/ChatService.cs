using System;

namespace chat.domain
{
    public class ChatService
    {
        public static List<Message> GetAllMessages()
        {
            return ChatRepository.ReadChatData().Messages;
        }

        public static List<Message> GetUserMessages(string author)
        {
            var allMessages = ChatRepository.ReadChatData().Messages;
            var filtered = new List<Message>();

            foreach (var message in allMessages)
            {
                if (message.Author == author)
                {
                    filtered.Add(message);
                }
            }

            return filtered;
        }

        public static void WriteMessage(User user, string text)
        {
            var likes = new List<Like>();
            var newMessage = new Message(user.Name, text, likes, false);
            ChatRepository.AddMessageToChatData(newMessage);
        }

        public static List<Message> CensorMessages(List<Message> messages)
        {
            var filtered = new List<Message>();

            foreach (var message in messages)
            {
                if (message.NSFW == false)
                {
                    filtered.Add(message);
                }
            }

            return filtered;
        }
    }
}

