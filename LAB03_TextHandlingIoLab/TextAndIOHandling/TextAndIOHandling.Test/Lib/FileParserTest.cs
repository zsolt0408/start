using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAndIOHandling.Lib;
using TextAndIOHandling.Model;
using Xunit;

namespace TextAndIOHandling.Test.Lib
{
    public class FileParserTest
    {
        [Fact]
        public void ParseUserFromFile_shoud_return_with_user_list()
        {
            var path = @"../../TestData/testusertable.csv";
            var parser = new FileParser();

            var users = parser.ParseUserFromFile(path);

            Assert.Equal(5, users.Count());

            _assertUser(new User("chris@mail.com", "Chris", "Green", "Chris Green"), users.ElementAt(0));
            _assertUser(new User("ben@ma#il.com", "Ben", "Andrews", "Ben Andrews"), users.ElementAt(1));
            _assertUser(new User("david@mail..com", "David", "Longmuir", "David Longmuir"), users.ElementAt(2));
            _assertUser(new User("cynthia@mail.com", "Cynthia", "Carey", "Cynthia Carey"), users.ElementAt(3));
            _assertUser(new User("melissa@mail.com", "Melissa", "MacBeth", "Melissa MacBeth"), users.ElementAt(4));
        }

        private void _assertUser(User expected, User actual)
        {
            Assert.Equal(expected.Email, actual.Email);
            Assert.Equal(expected.Firstname, actual.Firstname);
            Assert.Equal(expected.Lastname, actual.Lastname);
            Assert.Equal(expected.Displayname, actual.Displayname);
        }
    }
}
