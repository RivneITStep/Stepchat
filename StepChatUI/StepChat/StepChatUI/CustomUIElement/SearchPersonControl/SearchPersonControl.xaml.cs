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

namespace StepChat.StepChatUI.CustomUIElement.SearchPersonControl
{
    /// <summary>
    /// Interaction logic for SearchPersonControl.xaml
    /// </summary>
    public partial class SearchPersonControl : UserControl
    {
        public SearchPersonControl()
        {
            InitializeComponent();
        }
        public SearchPersonControl(string name, string surname)
        {
            InitializeComponent();
            contactNameLabel.Content = name;
            contactSurnameLabel.Content = surname;
        }
    }
}
