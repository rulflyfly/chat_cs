using System;
using System.Text.Json;
using chat.domain;

namespace chat
{
    public class ChatRepository
    {
        public static readonly string filePath = "data/chat-data.json";

        // Так как у нас Юзеры теперь отдельно от чата, и это общий список залогиненных юзеров в программе,
        //то при загрузке чата нам нужно определить, какие конкретно Юзеры из общего списка залогинены в нашем чате:
        

        public static Chat ReadChatData()
        {
            var stringChat = File.ReadAllText(filePath);
            var chatData = JsonSerializer.Deserialize<Chat>(stringChat, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });

            var messages = new List<Message>();
            foreach(var message in chatData.Messages)
            {
                messages.Add(message);
            }

            var chatUsers = new List<User>();
            foreach(var user in chatData.Users)
            {
                var detectedUser = UserService.GetUserById(user.Id);
                chatUsers.Add(detectedUser);
                
            }

            // Не знаю, как инициализировать свойство, ккоторое скрыто внутри класса
            // можно просто добавить еще одно ствойстао: Chat(List<Message>, List<User>), так как это основные составляющие чата.

            var chat = new Chat(messages);
            return chat;
        }

    }
}

