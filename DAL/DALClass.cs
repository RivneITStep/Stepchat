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
        public Attachment GetAttachment(int id)
        {
            return context.Attachments.FirstOrDefault(a => a.Id == id);
        }
        public List<User> GetUserContacts(int userId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null||existing.Contacts==null) return null;

            List<User> contacts = new  List<User>();

            foreach (var item in existing.Contacts)
            {
                contacts.Add(item.UserContact);
            }

            return contacts;
        }
        public void RemoveChatMember(int chatId, int userId)
        {
            context.ChatMembers.Remove(
                context.ChatMembers.First(cm => cm.UserId == userId && cm.ChatId == chatId)
            );
        }

        public void RemoveContact(int contactId)
        {
            var existing = context.Contacts.FirstOrDefault(u => u.UserContactId == contactId);
            
            if (existing == null) return;         

            context.Contacts.Remove(existing);
            
            context.SaveChanges();
        }
        public List<User> FindContactsbyName(int userId, string name)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null) return null;

            List<User> contacts = new List<User>();

            foreach (var item in existing.Contacts)
            {
                if (item.UserContact.FirstName == name)
                    contacts.Add(item.UserContact);
            }

            return contacts;
        }

        public List<User> SearchUsers(string query)
        {
            return context.Users.Where(u => u.FirstName.Contains(query) ||
                                            u.LastName.Contains(query) || 
                                            u.Login.Contains(query)).ToList()
                                .Select(u => new User
                                {
                                    Id = u.Id,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    LastOnlineDate = u.LastOnlineDate,
                                    PhotoPath = u.PhotoPath
                                }).ToList();
        }

        public List<User> FindContactsbySurname(int userId, string surname)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null) return null;

            List<User> contacts = new List<User>();

            foreach (var item in existing.Contacts)
            {
                if (item.UserContact.LastName == surname)
                    contacts.Add(item.UserContact);
            }

            return contacts;
        }
        public User FindContactsbyLogin(int userId, string login)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null) return null;

            foreach (var item in existing.Contacts)
            {
                if (item.UserContact.Login == login)
                    return item.UserContact;
            }

            return null;
        }
        public void AddContact(int userId, int contactUserId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);
            var existingContact = context.Users.FirstOrDefault(u => u.Id == contactUserId);

            if (existing == null) return;
            if (existingContact == null) return;

            context.Contacts.Add(new Contact() { UserId = userId, UserContactId = contactUserId });
            
            context.SaveChanges();
        }
        public User GetUserByLogin(string login)
        {
            var existing = context.Users.FirstOrDefault(u => u.Login == login);

            if (existing == null) return null;

            else return existing;
        }

        public bool CheckChatExist(int chatId)
        {
            return context.Chats.Any(c => c.Id == chatId);
        }
        public bool CheckChatMember(int chatId, int userId)
        {
            return context.Chats.First(c => c.Id == chatId).ChatMembers.Any(c => c.UserId == userId);
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
        public IEnumerable<Message> GetChatMessages(int chatId)
        {
            var existing = context.Chats.FirstOrDefault(u => u.Id == chatId);
            if (existing == null) return null;

            return existing.Messages;
        }
        public bool CheckMessageExist(int messageId)
        {
            return context.Messages.Any(m => m.Id == messageId);
        }
        public Message EditMessage(int messageId, Message newMessage)
        {
            var existing = context.Messages.FirstOrDefault(u => u.Id == messageId);

            existing.Attachments = newMessage.Attachments;
            existing.Text = newMessage.Text;

            context.SaveChanges();
            return existing;
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
            existing.Password = newUser.Password;
            existing.Login = newUser.Login;
            existing.LastOnlineDate = newUser.LastOnlineDate;

            context.SaveChanges();
        }
        public List<Chat> GetUserChats(int userId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null||existing.ChatMembers==null) return null;

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
        public MemberRole GetUserRolebyChatId(int userId, int chatId)
        {
            var existing = context.Users.FirstOrDefault(u => u.Id == userId);

            if (existing == null) return null;

            var existingChat = existing.ChatMembers.FirstOrDefault(u => u.ChatId == chatId);

            return existingChat.MemberRole;
        }

        public void AddAttachment(int messageId, Attachment attachment)
        {
            var existing = context.Messages.FirstOrDefault(u => u.Id == messageId);

            if (existing == null) return;

            existing.Attachments.Add(attachment);

            context.SaveChanges();
        }
        public void RemoveAttachment(int messageId, Attachment attachment)
        {
            var existing = context.Messages.FirstOrDefault(u => u.Id == messageId);

            if (existing == null) return;

            existing.Attachments.Remove(attachment);

            context.SaveChanges();
        }


    }
}
