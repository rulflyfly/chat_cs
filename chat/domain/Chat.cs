namespace chat.domain
{
    public record Chat (int Id, string Name, List<Message> Messages)
    {
        public List<Message> GetMessagesVisibleToUser(User activeUser)
        {
            var visibleMessages = new List<Message>();
            foreach (var message in Messages)
            {
                if (message.NSFW != true && activeUser.IsAdult())
                {
                    visibleMessages.Add(message);
                }
            }

            return visibleMessages;
        }

        public List<Message> FilterMessagesByUserName(User user, List<User> allUsers, string searchName)
        {
            var visibleMassages = GetMessagesVisibleToUser(user);
            var searchedId = -1;

            foreach (var u in allUsers)
            {
                if (u.Name == searchName) searchedId = u.Id;
            }

            if (searchedId == -1) return null;

            var filtered = new List<Message>();

            foreach (var message in visibleMassages)
            {
                if (message.UserId == searchedId)
                {
                    filtered.Add(message);
                }
            }

            return filtered;
        }

        public int FindMessageIndexByMessageId(int id)
        {
            foreach (var m in Messages)
            {
                if (m.Id == id) return Messages.IndexOf(m);
            }

            return -1;
        }
    }
}

