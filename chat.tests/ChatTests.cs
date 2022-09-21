using chat.domain;
namespace chat.tests;

public class ChatTests
{
    [Test]
    public void GetMessagesVisibleToUnderageUser_OnlyReturnsMessagesWithNSFWFalse()
    {
        var user = new User(1) { Name = "Nastya", Birthday = "08/01/2020" };

        List<Like> likes = new();
        var nutralMessage = new Message(1, 1, "prtivet", likes, false);
        var adultMessage = new Message(2, 1, "explicit text", likes, true);

        List<chat.domain.Message> messages = new();
        messages.Add(nutralMessage);
        messages.Add(adultMessage);


        var chat = new Chat(1, "Main Chat", messages);


        var filteredMessages = chat.GetMessagesVisibleToUser(user);

        CollectionAssert.DoesNotContain(filteredMessages, adultMessage);
    }

    [Test]
    public void GetMessagesVisibleToAdultUser_ReturnsAllChatMessages()
    {
        var user = new User(1) { Name = "Nastya", Birthday = "08/01/1997" };

        List<Like> likes = new();
        var nutralMessage = new Message(1, 1, "prtivet", likes, false);
        var adultMessage = new Message(2, 1, "explicit text", likes, true);

        List<chat.domain.Message> messages = new();
        messages.Add(nutralMessage);
        messages.Add(adultMessage);


        var chat = new Chat(1, "Main Chat", messages);


        var filteredMessages = chat.GetMessagesVisibleToUser(user);

        CollectionAssert.Contains(filteredMessages, nutralMessage);
        CollectionAssert.Contains(filteredMessages, adultMessage);
    }
}
