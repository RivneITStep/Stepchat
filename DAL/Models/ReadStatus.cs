using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReadStatus
    {
        public int Id { get; set; }
        public DateTime LastReadMessageDate { get; set; }
     
        // Foreign key
        public int UserId { get; set; }        

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Chat Chat { get; set; }
    }
}