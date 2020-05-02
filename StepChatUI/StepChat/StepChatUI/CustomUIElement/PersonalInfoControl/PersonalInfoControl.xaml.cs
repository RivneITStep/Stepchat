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

namespace StepChat.StepChatUI.CustomUIElement.PersonalInfoControl
{
    public partial class PersonalInfoControl : UserControl
    {
        private User user;
        public User User { get { return user; } set { if (value != null) user = value; } }

        public int UserID { get; set; }
        public PersonalInfoControl()
        {

        }
        public PersonalInfoControl(User usr)
        {
            InitializeComponent();
            User = usr;
            userFirstNameLabel.Content = usr.FirstName;
            userLastNameLabel.Content = usr.LastName;
            userEmail.Content = usr.Email;

        }

      
    }
}
