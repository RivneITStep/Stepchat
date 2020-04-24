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

        public bool Login(string login, string hashPassword)
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

        public bool CheckUserExist(int userId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null) return false;
            
            else return true;
        }
        public User GetUserById(int userId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null) return null;
            
            else return existing;
        }
        public bool CheckUserPassword(string password, int userId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);
            
            if (existing == null) return false;

            else 
            {
                if (existing.Password == password)
                    return true;
                else
                    return false;
            }

        }

        public void AddMessage(Message message)
        {            
            if (message == null) return;

            context.Messages.Add(message);
            context.SaveChanges();
        }

        public void EditUser(User newUser)
        {
            var existing = context.Users.FirstOrDefault(u=>u.Id == newUser.Id);

            if (existing == null) return;

            existing.FirstName = newUser.FirstName;
            existing.LastName = newUser.LastName;
            existing.Bio = newUser.Bio;
            existing.Email = newUser.Email;
            existing.PhotoPath = newUser.PhotoPath;
            existing.Login = newUser.Login;
            existing.Password = newUser.Password;
            existing.IsOnline = newUser.IsOnline;
            existing.LastOnlineDate = newUser.LastOnlineDate;

            context.SaveChanges();
        }
    }
}
