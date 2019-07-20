using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using TextAndIOHandling.Lib;
using TextAndIOHandling.Model;

namespace TextAndIOHandling.Test.Lib
{
    public class UserValidatorTest
    {
        [Fact]
        public void GetInvalidUsers_should_return_users_with_invalid_email()
        {
            var emailValidator = new Mock<IEmailValidator>();
                emailValidator.Setup(x => x.Validate(It.IsAny<string>()))
                .Returns(false);
                emailValidator.Setup(x => x.Validate(It.Is<string>(email => email == "a@mail.com")))
                .Returns(true);
            var userValidator = new UserValidator(emailValidator.Object);
            var users = new List<User> {
                new User("b@mail", "b", "c", "d"),
                new User("a@mail.com", "b", "c", "d"),
                new User("b@mail..com", "b", "c", "d"),
            };

            var invalidUsers = userValidator.GetInvalidUsers(users);

            var expectedUsers = new List<User>(users);
            expectedUsers.RemoveAt(1);
            Assert.Equal(expectedUsers, invalidUsers);
        }
    }
}
