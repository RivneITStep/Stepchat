using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALClass
    {
        ChatDBModel context;

        public DALClass()
        {
            context = new ChatDBModel();
        }

        public bool Login (string login, string hashPassword)
        {
            User user = context.Users.FirstOrDefault(u => u.Login == login);

            if (user == null)
                return false;

            if (user.Password == hashPassword)
                return true;
            else
                return false;
        }
        public void Register(User user)
        {
            var existing = context.Users.FirstOrDefault(u => u.Login == user.Login);

            if (existing != null) return;

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
