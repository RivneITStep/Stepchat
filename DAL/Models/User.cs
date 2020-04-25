using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {
        // Primary key
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastOnlineDate { get; set; }


        // Navigation properties      
        //public virtual ICollection<Contact> Contacts { get; set; }

        public virtual ICollection<int> ContactsIds { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<MessageView> MessageViews { get; set; }
        public virtual ICollection<ReadStatus> ReadStatuses { get; set; }
        public virtual ICollection<ChatMember> ChatMembers { get; set; }


        public User()
        {
            ContactsIds = new HashSet<int>();
        }
    }
}
