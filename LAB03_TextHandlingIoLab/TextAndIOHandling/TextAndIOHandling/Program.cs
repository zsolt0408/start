using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAndIOHandling.Lib;

namespace TextAndIOHandling
{
    class Program
    {
        public static void Main(string[] args) {
            var userValidator = new UserValidator(new EmailValidator());
            var fileParser = new FileParser();
            var userReporter = new UserReporter();

            var users = fileParser.ParseUserFromFile("../../Data/userdatas.csv");
            var invalidUsers = userValidator.GetInvalidUsers(users);
            var responseJson = userReporter.ReportInvalidUsersToJson(invalidUsers);

            Console.WriteLine("Invalid users(JSON):");
            Console.WriteLine(responseJson);
            Console.ReadKey();
        }
    }
}
