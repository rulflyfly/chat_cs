﻿namespace chat.domain
{
    public record Chat (List<Message> Messages)
    {
        public List<Message> GetMessagesVisibleToUser(IUser activeUser)
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

