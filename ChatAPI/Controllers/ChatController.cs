using chat;
using chat.domain;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private IChatService _chatService;
        private ILikeService _likeservice;

        public ChatController(IChatService chatService, ILikeService likeService)
        {
            _chatService = chatService;
            _likeservice = likeService;
        }

        public class Config
        {
            public string Text { get; set; }
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

        // PUT api/chat/1/user/1/message
        [HttpPut("{chatId}/user/{userId}/{message}")]
        public void PutMessage(int chatId, int userId, [FromBody] Config config)
        {
            var newMessage = config.Text;
            _chatService.WriteMessage(chatId, userId, newMessage);
        }

        // Put Like api/chat/2/user/5295/likeMessage/2
        [HttpPut("{chatId}/user/{userId}/likemessage/{messageId}")]
        public void PostLike(int chatId, int userId, int messageId)
        {
            _likeservice.AddLikeToMessage(userId, chatId, messageId);       
        }
    }
}

