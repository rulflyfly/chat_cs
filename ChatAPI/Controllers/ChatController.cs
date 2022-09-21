using chat.domain;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        // GET api/chat
        [HttpGet]
        public string Start()
        {
            return "try this in postman :)";
        }

        // GET api/chat/1/user/1
        [HttpGet("{chatId}/user/{userId}")]
        public List<Message> GetAllMessages(int chatId, int userId)
        {
            return _chatService.GetAllMessages(userId, chatId);
        }

        // GET api/chat/1/user/1/Nastya
        [HttpGet("{chatId}/user/{userId}/{searchName}")]
        public List<Message> GetUserMessages(int chatId, int userId, string searchName)
        {
            return _chatService.GetUserMessages(chatId, userId, searchName);
        }
    }
}

