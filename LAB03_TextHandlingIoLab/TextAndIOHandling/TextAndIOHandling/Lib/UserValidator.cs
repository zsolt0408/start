using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAndIOHandling.Model;

namespace TextAndIOHandling.Lib
{
    public class UserValidator : IUserValidator
    {
        IEmailValidator _emailValidator;
        public UserValidator(IEmailValidator emailValidator)
        {
            _emailValidator = emailValidator;
        }
        public IEnumerable<User> GetInvalidUsers(IEnumerable<User> users)
        {
            return users;
        }
    }
}
