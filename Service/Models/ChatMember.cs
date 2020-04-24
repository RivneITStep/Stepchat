using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class ChatMember
    {
        public int Id { get; set; }

        public User User { get; set; }
        public Chat Chat { get; set; }
        public int MemberRoleId { get; set; }

        public ChatMember() { }

        public ChatMember(Chat chat, User user)
        {
            Chat = chat;
            User = user;
        }
        public ChatMember(Chat chat, User user, int roleId)
        {
            Chat = chat;
            User = user;
            MemberRoleId = roleId;
        }

        public void ChangeRole(int newRoleId)
        {
            MemberRoleId = newRoleId;
        }
    }
}
