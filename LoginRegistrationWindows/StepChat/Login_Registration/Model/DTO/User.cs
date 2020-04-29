using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegistration.Login_Registration.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string PhotoPath { get; set; }
        public string Login { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastOnlineDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
