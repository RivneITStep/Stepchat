using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Attachment
    {
        public int Id { get; set; }  
        public string Path { get; set; }          

        // Foreign key
        public int MessageId { get; set; }       

        // Navigation properties
        public virtual Message Message { get; set; }
    }
}
