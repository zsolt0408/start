using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics
{
    public class UserRepository
    {
        private User[] users = new User[5];
        private int count = 0;

        public UserRepository()
        {
        }

        public int Count()
        {
            return count;
        }

        public User Get(int index)
        {
            return users[index];
        }

        public void Insert(User user)
        {
            users[count] = user;
            count++;
        }

        public void InsertInAbcOrderById(User user)
        {
            var pos = 0;
            while (pos < count && string.Compare(users[pos].Id, user.Id) < 0)
            {
                pos++;
            }

            for (int i = count + 1; i > pos; i--)
            {
                users[i] = users[i - 1];
            }
            users[pos] = user;
            count++;
        }

        public User GetByIdNumber(string id)
        {
            for (int i = 0; i < count; i++)
            {
                if (users[i].Id == id)
                {
                    return users[i];
                }
            }

            return null;
        }
    }
}
