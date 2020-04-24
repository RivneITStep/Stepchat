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

        public bool IsPersonal { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public int ReadStatusId { get; set; }
    }
}
