using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class Chat
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public bool IsPersonal { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string PhotoPath { get; set; }
        [DataMember]
        public int ReadStatusId { get; set; }
    }
}
