using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StepChat.StepChatUI.CustomUIElement.PersonControl
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
