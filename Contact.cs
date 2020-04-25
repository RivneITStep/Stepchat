using System;
using System.Windows.Controls;

namespace MainWindowUI
{
   public class Contact
    {
        private int id;
        private string firstName;
        private string lastName;
        private string bio;
        private Image contactImage;
        private bool isOnline;
        private DateTime lastOnlineDate;

        public int ID { get {return id; } }
        public string FirstName { get { return firstName; } set { if(value!=null) firstName = value; } }
        public string LastName { get { return lastName; } set { if (value != null) lastName = value; } }
        public string BIO { get { return bio; } }
        public bool IsOnline { get { return isOnline; } set { isOnline = value; } }
        public DateTime LastOnlineDate { get { return lastOnlineDate; } set { lastOnlineDate = value; } }

        public Contact(int contactId,string contactFirstName,string contactLastName,string contactBio)
        {
            id = contactId;
            firstName = contactFirstName;
            lastName = contactLastName;
            bio = contactBio;

        }
        public void SetImage(Image img)
        {
            contactImage = img;
        }
        

        
    }
}
