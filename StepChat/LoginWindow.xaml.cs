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

namespace StepChat
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            WindowControlPanel_.ButtonClose_MouseClick_Handler += Window_Closed;
            WindowControlPanel_.ButtonMinimize_MouseClick_Handler += Window_Minimize;
            WindowControlPanel_.ButtonMaximize_MouseClick_Handler += Window_Maximize;
        }

        private void Window_Closed(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Window_Maximize(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
    }
}
