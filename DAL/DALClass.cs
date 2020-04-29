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
        public bool CheckUserExist(string login)
        {
            var existing = context.Users.FirstOrDefault(u => u.Login == login);

            if (existing == null) return false;
            
            else return true;
        }
        public Chat GetChatById(int chatId)
        {
            return context.Chats.FirstOrDefault(c => c.Id == chatId);
        }
        public User GetUserById(int userId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null) return null;
            
            else return existing;
        }
        public IEnumerable<User> GetUsersShortByIds(int[] ids)
        {
            return context.Users.Where(u => ids.Contains(u.Id))
                                .Select(u => new User{
                                    Id = u.Id,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    LastOnlineDate = u.LastOnlineDate,
                                    PhotoPath = u.PhotoPath
                                });
        }
        public IEnumerable<int> GetUserContacts(int userId)
        {
            return context.Users.First(u => u.Id == userId).ContactsIds;
        }
        public void AddContact(int userId, int contactId)
        {
            context.Users.First(u => u.Id == userId).ContactsIds.Add(contactId);
            context.SaveChanges();
        }
        public User GetUserByLogin(string login)
        {
            var existing = context.Users.FirstOrDefault(u => u.Login == login);

            if (existing == null) return null;

            else return existing;
        }
        public bool CheckUserPassword(string password, string login)
        {
            var existing = context.Users.FirstOrDefault(u => u.Login == login);
            
            if (existing == null) return false;

            else 
            {
                if (existing.Password == password)
                    return true;
                else
                    return false;
            }
        }
        public int AddChat(Chat chat)
        {
            context.Chats.Add(chat);
            context.SaveChanges();

            return chat.Id;
        }
        public void AddMessage(Message message)
        {            
            if (message == null) return;

            context.Messages.Add(message);
            context.SaveChanges();
        }
        public IEnumerable<Message> GetMessages(int userId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);
            if (existing == null) return null;

            return existing.Messages;
        }
        public void EditMessages(int messageId, Message newMessage)
        {
            var existing = context.Messages.FirstOrDefault(u => u.Id == messageId);
            if (existing == null) return;

            existing.Attachments = newMessage.Attachments;
            existing.Text = newMessage.Text;

            context.SaveChanges();
        }
        public void RemoveMessages(int messageId)
        {
            var existing = context.Messages.FirstOrDefault(u => u.Id == messageId);
            if (existing == null) return;

            context.Messages.Remove(existing);

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
            existing.LastOnlineDate = newUser.LastOnlineDate;

            context.SaveChanges();
        }
        public List<Chat> GetUserChats(int userId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null) return null;

            List<Chat> chats = new  List<Chat>();

            foreach (var item in existing.ChatMembers)
            {
                chats.Add(item.Chat);
            }

            return chats;
        }
        public void AddChatMemberToChat(ChatMember cm, int chatId)
        {
            var existing = context.Chats.FirstOrDefault(u => u.Id == chatId);
            
            if (existing == null) return;

            existing.ChatMembers.Add(cm);                       
            context.SaveChanges();
        }
        public void ChangePassword (int userId, string newPass)
        {            
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null) return;

            existing.Password = newPass;
            context.SaveChanges();
        }

    }
}
