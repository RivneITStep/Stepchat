using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MemberRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
               
        // Navigation properties       
        public virtual ICollection<ChatMember> ChatMember { get; set; }
    }
}
