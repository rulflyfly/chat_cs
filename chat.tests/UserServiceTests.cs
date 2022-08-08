using System;
using chat;
using chat.domain;
using Microsoft.VisualStudio.TestPlatform;


namespace chat.tests
{
    
    public class UserServiceTests
    {
        // GetAllUsers
        [Test]
        public void GetsAllUsersFromOriginalDataBase_Returns5()
        {
            var expected = 5;
            
            var actual = UserService.GetAllUsers().Count();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllUsers_AllUsersContainsUserWithSameProperties()
        { 
            var user2 = new User(4032);
            user2.Name = "Suhasya";
            user2.Birthday = "08/01/2020";

            var actual = UserService.GetAllUsers()[1];

            Assert.AreEqual(user2, actual);
        }

        // GetUserById
        [Test]
        public void FunctionGetsNumber_OneOfUserIdEqualsNumber()
        {
            var list = UserService.GetAllUsers();
            var users = list.ToArray();
            var number = 4032;

            var actual = UserService.GetUserById(number);

            CollectionAssert.Contains(users, actual);
        }

        [Test]
        public void GetUserByNameWhenUserIsRegistered_ReturnsUserWithSpecifiedName()
        {
            var userInput = "Test_2";

            var actual = UserService.GetUserByName(userInput).Name;

            Assert.AreEqual(actual, userInput);
        }

        [Test]
        public void GetUserByNameWhenUserIsNotRegistered_ReturnsNull()
        {
            var actual = "";

            var expected = UserService.GetUserByName(actual);

            //Assert.AreEqual(actual, expected);
            Assert.Null(expected);
        }

        // SingUpUser
        [Test]
        public void NewUsersInputsNameAndBirth_DataContainsNewUserWithGivenParameters()
        {
            var name = "TestUser124";
            var bday = "02/02/2004";
            int[] arr = Enumerable.Range(0, 9999 + 1).ToArray();
            var expectedUserName = "TestUser124";
            var expectedUserBirthday = "02/02/2004";

            var actual = UserService.SingUpUser(name, bday);

            Assert.AreEqual(actual.Name, expectedUserName);
            Assert.AreEqual(actual.Birthday, expectedUserBirthday);
            CollectionAssert.Contains(arr, actual.Id);

        }



    }
}

