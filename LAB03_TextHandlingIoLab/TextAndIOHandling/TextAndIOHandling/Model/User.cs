using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAndIOHandling.Model
{
    public class User
    {
        public User(string email, string firstname, string lastname, string displayname)
        {
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Displayname = displayname;
        }
        public string Email;
        public string Firstname;
        public string Lastname;
        public string Displayname;

        public override bool Equals(object obj)
        {
            if (!(obj is User))
                return false;
            var user = (User)obj;

            return (Email == user.Email &&
                Firstname == user.Firstname &&
                Lastname == user.Lastname &&
                Displayname == user.Displayname);
        }

        public override int GetHashCode()
        {
            var hashCode = -244052127;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Firstname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Lastname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Displayname);
            return hashCode;
        }
    }
}
