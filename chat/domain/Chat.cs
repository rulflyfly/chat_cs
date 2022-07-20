using System;

namespace chat.domain
{
    public record Chat (List<Message> Messages)
    {
        public List<User> Users { get; set; }
        public List<Message> GetMessagesVisibleToUser(User activeUser)
        {
            var visibleMessages = new List<Message>();
            foreach (var message in Messages)
            {
                if (!message.NSFW || activeUser.IsAdult())
                {
                    visibleMessages.Add(message);
                }
            }

            return visibleMessages;
        }
    }

}

