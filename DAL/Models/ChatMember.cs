using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChatMember
    {
        public int Id { get; set; }
        
        // Foreign key
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public int MemberRoleId { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual MemberRole MemberRole  { get; set; }

    }
}
