using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public bool IsPersonal { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }

        
        public virtual List<ChatMember> ChatMembers { get; set; }
        public virtual List<Message> Messages { get; set; }


        public event Action<Chat, User> NewUserJoined;
        public event Action<Chat, User> UserLeaved;
        public event Action<Chat, User, Message> NewMessageAdded;


        public Chat(){/*Automapper ctor*/}

        public Chat(User user1, User user2)
        {
            IsPersonal = true;

            ChatMembers.Add(new ChatMember(this, user1));
            ChatMembers.Add(new ChatMember(this, user2));

        }

        public Chat(string name, User owner)
        {
            IsPersonal = false;
            ChatMembers.Add(new ChatMember(this, owner, 1));
            
        }

        public void Join(User user)
        {
            if(IsPersonal)

            ChatMembers.Add(new ChatMember(this, user));
            NewUserJoined?.Invoke(this, user);
        }

        public void Leave(User user)
        {
            ChatMembers.RemoveAll(cm => cm.User == user);
            UserLeaved?.Invoke(this, user);
        }

        public void SendMessage(User user, Message message)
        {
            Messages.Add(message);
            NewMessageAdded?.Invoke(this, user, message);
        }

    }
}
