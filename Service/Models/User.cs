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
        public string Password { get; private set; }
        public bool IsOnline { get; private set; }
        public DateTime LastOnlineDate { get; private set; }

        public List<Chat> Chats { get; set; } 


        public User()
        {
            // Automapper ctor
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
