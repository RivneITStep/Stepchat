using StepChat.ServiceReference1;
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

namespace StepChat.StepChatUI.CustomUIElement.ContactControl
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        private User user;
        public User User { get { return user; } set { if (value != null) user = value; } }

        public ContactControl()
        {
            InitializeComponent();
        }
        public ContactControl(User usr)
        {
            InitializeComponent();
            User = usr;
            contactNameLabel.Content = usr.FirstName;
            contactSurnameLabel.Content = usr.LastName;
            if (usr.IsOnline)
            {
                isContactOnline.Content = "Online";
                isContactOnline.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                isContactOnline.Content = "Offline";
                isContactOnline.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
