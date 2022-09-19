using System;
using chat.domain;

namespace ChatAPI.Utils
{
    public class ChatApiUtils
    {
        public static Chat FilterChatsById(List<Chat> chats, int id)
        {
            var _chat = new Chat(0, null, null);
            foreach (var chat in chats)
            {
                if (chat.Id == Convert.ToDouble(id))
                {
                    _chat = chat;
                }
            }

            if (_chat.Id == 0) return null;

            return _chat;
        }
    }
}

