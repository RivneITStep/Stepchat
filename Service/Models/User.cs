using Service.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Bio { get; private set; }
        public string Email { get; private set; }
        public string PhotoPath { get; private set; }
        public string Login { get; private set; }
        public bool IsOnline { get; private set; }
        public DateTime LastOnlineDate { get; private set; }
        public List<Chat> Chats { get; private set; }

        private static DAL.DALClass dal = DALProxy.GetInstance();


        public User()
        {
            // Automapper ctor
        }

        public IEnumerable<int> GetContacts()
        {
            return dal.GetUserContacts(this.Id);
        }

        public void AddContact(int contactId)
        {
            dal.AddContact(this.Id, contactId);
        }

        private void StartPrivateChat(int userId)
        {
            User user = UsersManager.GetUser(userId);

            ChatsManager.CreatePrivateChat(this, user);
        }


        public Result JoinChat(int chatId)
        {
            Result<Chat> r = ChatsManager.GetChat(chatId);

            if (!r.IsSuccess) return r;

            r.Data.Join(this);
            return Result.OK;
        }


        public Result SendMessage(string message, int toUserId)
        {
            return Result.OK;
        }



    }
}
