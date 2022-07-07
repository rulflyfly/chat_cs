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

    }
}

