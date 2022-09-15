using System.Text.Json;
using chat.domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {
        private IChatRepository _chatRepository;

        public record NewMessage (double userId, string text);

        public ExampleController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        // GET: api/chat
        [HttpGet]
        public List<Chat> GetChatData()
        {
            return _chatRepository.ReadChatData();
        }

        // GET api/chat/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value " + id;
        }

        // POST api/chat
        [HttpPost]
        public List<Chat> CreateChatData([FromBody] List<Chat> chats)
        {
            _chatRepository.WriteChatData(chats);
            return _chatRepository.ReadChatData();
        }

        // PUT api/chat/5
        [HttpPut]
        public List<Chat> Put([FromBody] NewMessage newMessage)
        {
            var chat = _chatRepository.ReadChatData();
            _chatRepository.WriteMessage(newMessage.userId, newMessage.text, chat[1]);
           return _chatRepository.ReadChatData();
        }

        // DELETE api/chat/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

