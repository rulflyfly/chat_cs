using System;
using System.Text.Json;

namespace chat.domain
{
    public class ChatService
    {
        public static List<Message> GetAllMessages(User authenticatedUser)
        {
            var chat = ChatRepository.ReadChatData();

            var messages = chat.GetMessagesVisibleToUser(authenticatedUser);

            return messages;
        }

        public static List<Message> GetUserMessages(User authenticatedUser, string searchName)
        {
            var allMessages = GetAllMessages(authenticatedUser);
            var filtered = new List<Message>();

            foreach (var message in allMessages)
            {
                if (UserService.GetUserById(message.UserId).Name == searchName)
                {
                    filtered.Add(message);
                }
            }

            return filtered;
        }

        public static void WriteMessage(User user, string text)
        {
            var likes = new List<Like>();
            var newMessage = new Message(user.Id, text, likes, false);

            var chatData = ChatRepository.ReadChatData();
            chatData.Messages.Add(newMessage);

            var newChatData = JsonSerializer.Serialize(chatData)!;

            File.WriteAllText(ChatRepository.filePath, newChatData);
        }

    }
}

