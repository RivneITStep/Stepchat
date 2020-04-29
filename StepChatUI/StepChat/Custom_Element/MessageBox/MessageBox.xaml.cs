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
using System.Windows.Shapes;

namespace StepChat.Custom_Element
{
    public partial class MessageBox : Window
    {
        public MessageBox()
        {
            InitializeComponent();
            WindowControlPanel_.ButtonClose_MouseClick_Handler += Window_Closed;
        }
        private void Window_Closed(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void SetMessage(string message)
        {
            ErrorTextBox.Text = message;
        }
    }
}
