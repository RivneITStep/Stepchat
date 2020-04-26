using LoginRegistration.Login_Registration.ViewModel;
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

namespace LoginRegistration
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginRegistrationWindow : Window
    {
        public LoginRegistrationWindow()
        {
            InitializeComponent();
            WindowControlPanel_.ButtonClose_MouseClick_Handler += Window_Closed;
            WindowControlPanel_.ButtonMinimize_MouseClick_Handler += Window_Minimize;
            WindowControlPanel_.ButtonMaximize_MouseClick_Handler += Window_Maximize;
            RegistrationWindow.Visibility = Visibility.Hidden;
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
        private void Button_Click_Open_Registration_Window(object sender, RoutedEventArgs e)
        {
            LoginWindow.Visibility = Visibility.Collapsed;
            RegistrationWindow.Visibility = Visibility.Visible;
        }

        private void Button_Click_Open_Login_Window(object sender, RoutedEventArgs e)
        {
            RegistrationWindow.Visibility = Visibility.Collapsed;
            LoginWindow.Visibility = Visibility.Visible;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (ConfirmPasswordBox.Password != "" && PasswordBox.Password != "" && ConfirmPasswordBox.Password != PasswordBox.Password)
            {
                ConfirmPasswordBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                PasswordBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else
            {
                ConfirmPasswordBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                PasswordBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 255,255));
            }
        }
    }
}
