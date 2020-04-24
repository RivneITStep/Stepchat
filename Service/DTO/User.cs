using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Bio { get; set; }
        [DataMember]
        public string PhotoPath { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public bool IsOnline { get; set; }
        [DataMember]
        public DateTime LastOnlineDate { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
