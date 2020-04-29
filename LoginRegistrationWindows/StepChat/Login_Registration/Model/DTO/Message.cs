using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegistration.Login_Registration.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; }
    }
}
