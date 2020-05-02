using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }

        // Foreign key
        public int SenderId { get; set; }
        public int ChatId { get; set; }

        // Navigation properties
        public virtual Chat Chat { get; set; }
        public virtual User Sender { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<User> ReadUsers { get; set; }
        
    }
}
