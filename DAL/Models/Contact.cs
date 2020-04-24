using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contact
    {
        public int Id { get; set; }
        // Foreign key
        public int UserId { get; set; }
        public int ContactId { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual User UserContact { get; set; }
    }
}
