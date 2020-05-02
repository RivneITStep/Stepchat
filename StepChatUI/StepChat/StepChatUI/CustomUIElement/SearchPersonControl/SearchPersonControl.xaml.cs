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
using StepChat.ServiceReference1;

namespace StepChat.StepChatUI.CustomUIElement.SearchPersonControl
{
    /// <summary>
    /// Interaction logic for SearchPersonControl.xaml
    /// </summary>
    public partial class SearchPersonControl : UserControl
    {
        private User user;
        public User User { get { return user; } set { if (value != null) user = value; } }
        public SearchPersonControl()
        {
            InitializeComponent();
        }
        public SearchPersonControl(User usr)
        {
            InitializeComponent();
            User = usr;
            contactNameLabel.Content = usr.FirstName;
            contactSurnameLabel.Content = usr.LastName;
            if(usr.IsOnline)
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
