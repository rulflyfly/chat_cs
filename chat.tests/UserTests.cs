using chat.domain;

namespace chat.tests
{
    public class UserTests
    {
        [Test]
        public void CheckUserIsUnderage_PassesWhenUserIsYoungerThan18()
        {
            var user = new User(1) { Name = "Nastya", Birthday = "08/01/2020" };

            var isUnderage = !user.IsAdult();
            Assert.That(isUnderage, Is.EqualTo(true));
        }

        [Test]
        public void CheckUserIsAdult_PassesWhenUserIs18OrElder()
        {
            var user = new User(1) { Name = "Nastya", Birthday = "08/01/2004" };

            var isAdult = user.IsAdult();
            Assert.That(isAdult, Is.EqualTo(true));
        }
    }
}

