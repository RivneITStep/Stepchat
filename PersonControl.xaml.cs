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

namespace MainWindowUI
{
    /// <summary>
    /// Interaction logic for PersonControl.xaml
    /// </summary>
    public partial class PersonControl : UserControl
    {
        private string contactUserName;
        private Image contactImage;
        private string contactLastMessage;
        private DateTime timeOfLastMessage;
        public PersonControl()
        {
            InitializeComponent();
        }

        public void EditContactName(string userName)
        {
            contactUserName = userName;
            contactNameLabel.Content = contactUserName;
        }
        public void EditContactName(string message, DateTime time)
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
