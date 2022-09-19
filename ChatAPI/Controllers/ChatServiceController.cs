using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chat.domain;
using ChatAPI.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChatServiceController : Controller
    {

        private IChatRepository _chatRepository;

        public ChatServiceController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        // GET api/chatservice/1/1
        [HttpGet("{chatId}/{userId}")]
        public List<Message> GetAllMessages(int chatId, int userId)
        {
            var chats = _chatRepository.ReadChatData();

            var chat = ChatApiUtils.FilterChatsById(chats, chatId);

            if (chat == null) return null;

            var chatService = new ChatService();

            return chatService.GetAllMessages(Convert.ToDouble(userId), chat);
        }

        // GET api/chatservice/1/1/searchName
        [HttpGet("{chatId}/{userId}/{searchName}")]
        public List<Message> GetUserMessages(int chatId, int userId, string searchName)
        {
            var chats = _chatRepository.ReadChatData();

            var chat = ChatApiUtils.FilterChatsById(chats, chatId);

            if (chat == null) return null;

            var chatService = new ChatService();

            return chatService.GetUserMessages(Convert.ToDouble(userId), searchName, chat);
        }
    }
}

