using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chat.domain;
using ChatAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private IChatRepository _chatRepository;

        public ChatController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        // GET: api/chat/1
        [HttpGet("{id}")]
        public List<Message> GetMessagesVisibleToUser(int id, [FromBody] User user)
        {
            var chats = _chatRepository.ReadChatData();

            var chat = ChatApiUtils.FilterChatsById(chats, id);

            if (chat == null) return null;

            return chat.GetMessagesVisibleToUser(user);
        }
    }
}

