using chat.domain;
namespace chat.tests;

public class ChatTests
{
    [Test]
    public void GetMessagesVisibleToUnderageUser_OnlyReturnsMessagesWithNSFWFalse()
    {
        var user = new User(1) { Name = "Nastya", Birthday = "08/01/2020" };

        List<Like> likes = new();
        var nutralMessage = new chat.domain.Message(1.0, "prtivet", likes, false);
        var adultMessage = new chat.domain.Message(1.0, "explicit text", likes, true);

        List<chat.domain.Message> messages = new();
        messages.Add(nutralMessage);
        messages.Add(adultMessage);


        var chat = new Chat(messages);


        var filteredMessages = chat.GetMessagesVisibleToUser(user);

        CollectionAssert.DoesNotContain(filteredMessages, adultMessage);
    }

    [Test]
    public void GetMessagesVisibleToAdultUser_ReturnsAllChatMessages()
    {
        var user = new FakeUser { IsAdultFlag = true };

        List<Like> likes = new();
        var nutralMessage = new chat.domain.Message(1.0, "prtivet", likes, false);
        var adultMessage = new chat.domain.Message(1.0, "explicit text", likes, true);

        List<chat.domain.Message> messages = new();
        messages.Add(nutralMessage);
        messages.Add(adultMessage);


        var chat = new Chat(messages);


        var filteredMessages = chat.GetMessagesVisibleToUser(user);

        CollectionAssert.Contains(filteredMessages, nutralMessage);
        CollectionAssert.Contains(filteredMessages, adultMessage);
    }

    [Test]
    public void GetMessagesWhenChatIsEmpty_ReturnsEmptyArray()
    {
        var fakeRepository = new FakeRepository();
        var chatService = new ChatService(fakeRepository);
        var chat = new Chat(new List<Message>());
        fakeRepository.TestChat = chat;
        var user = new User(1) { Name = "Nastya", Birthday = "08/01/1997" };

        var allMessages = chatService.GetAllMessages(user);

        CollectionAssert.IsEmpty(allMessages);
    }

    public class FakeUser : IUser
    {
        public bool IsAdultFlag { get; set; }
        public bool IsAdult()
        {
            return IsAdultFlag;
        }
    }
    // fake, stub
    public class FakeRepository : IChatRepository
    {
        public Chat TestChat { get; set; }

        public Chat ReadChatData()
        {
            return TestChat;
        }
    }
}