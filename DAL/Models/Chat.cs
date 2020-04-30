using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Chat
    {
        public int Id { get; set; }
        public bool IsPersonal { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }

        // Foreign key
        public ICollection<int> ReadStatusId { get; set; }

        // Navigation properties
        public virtual ICollection<ChatMember> ChatMembers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ReadStatus> ReadStatuses { get; set; }


        public Chat()
        {
            ChatMembers = new HashSet<ChatMember>();
            Messages = new HashSet<Message>();
            ReadStatuses = new HashSet<ReadStatus>();
        }
    }
}
