using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }

        public Chat Chat { get; set; }
        public User Sender { get; set; }


        public Message(Chat chat, User sender, string text)
        {
            Chat = chat;
            Sender = sender;
            Text = text;
            SendDate = DateTime.Now;
        }

    }
}
