namespace chat.domain
{
    public record Chat (double Id, string Name, List<Message> Messages)
    {
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

