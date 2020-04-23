using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime SendDate { get; set; }
        [DataMember]
        public int SenderId { get; set; }
        [DataMember]
        public int ChatId { get; set; }

    }
}
