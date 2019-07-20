using System.Collections.Generic;
using TextAndIOHandling.Model;

namespace TextAndIOHandling.Lib
{
    public interface IUserValidator
    {
        IEnumerable<User> GetInvalidUsers(IEnumerable<User> users);
    }
}