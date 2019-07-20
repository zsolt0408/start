using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextAndIOHandling.Lib;
using TextAndIOHandling.Model;
using Xunit;

namespace TextAndIOHandling.Test.Lib
{
    public class UserReporterTest
    {
        [Fact]
        public void ReportInvalidUsersToJson_should_make_a_json_object_from_user_list()
        {
            var users = new List<User>
            {
                new User("user1@mail", "fuser1", "luser1", "duser1"),
                new User("user2@mail", "fuser2", "luser2", "duser2"),
            };

            var userReporter = new UserReporter();

            var reportJson = userReporter.ReportInvalidUsersToJson(users);

            var expected = @"{
                ""invalidusers"": [
                    {
                        ""email"": ""user1@mail"",
                        ""firstname"": ""fuser1"",
                        ""lastname"": ""luser1"",
                        ""displayname"": ""duser1""
                    },
                    {
                        ""email"": ""user2@mail"",
                        ""firstname"": ""fuser2"",
                        ""lastname"": ""luser2"",
                        ""displayname"": ""duser2""
                    }
                ]
            }";

            Assert.Equal(Regex.Replace(expected, @"\s+", ""), Regex.Replace(reportJson, @"\s+", ""));
        }
    }
}
