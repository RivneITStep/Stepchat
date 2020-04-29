using System;
using System.Windows.Controls;

namespace MainWindowUI
{
    public partial class PersonControl : UserControl
    {
        private Contact contact;

        private string contactLastMessage;
        private DateTime timeOfLastMessage;

        public PersonControl()
        {
            InitializeComponent();
        }
        public PersonControl(Contact contact_)
        {
            InitializeComponent();
            contact = contact_;

            contactNameLabel.Content = contact.FirstName;
        }


        public void EditContactName(string userName)
        {
            contact.FirstName = userName;
            contactNameLabel.Content = contact.FirstName;
        }
        public void EditContactMessage(string message, DateTime time)
        {
            timeOfLastMessage = time;
            lastSendedMessageTime.Content = timeOfLastMessage.ToShortTimeString();

            contactLastMessage = message;
            lastMessage.Text = contactLastMessage;
        }
        public void EditContactImage(Image image)
        {
        }
    }
}
