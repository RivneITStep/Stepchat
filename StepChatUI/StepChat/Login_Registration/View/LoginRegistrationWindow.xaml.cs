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
using StepChat.Custom_Element.CustomMessageBox;

namespace LoginRegistration
{
    public partial class LoginRegistrationWindow : Window
    {
        public LoginRegistrationWindow()
        {
            InitializeComponent();
            WindowControlPanel_.ButtonClose_MouseClick_Handler += Window_Closed;
            WindowControlPanel_.ButtonMinimize_MouseClick_Handler += Window_Minimize;
            WindowControlPanel_.ButtonMaximize_MouseClick_Handler += Window_Maximize;
            RegistratinWindow_NextButton.IsEnabled = false;
        }
        private bool _isPasswordConfirmed = false;
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
            //if (this.WindowState == WindowState.Normal)
            //{
            //    this.WindowState = WindowState.Maximized;
            //}
            //else
            //{
            //    this.WindowState = WindowState.Normal;
            //}
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxInRegister.Password != "" &&
                ConfirmPasswordBox.Password != PasswordBoxInRegister.Password)
            {
                ConfirmPasswordBox.Foreground = new SolidColorBrush(Color.FromRgb(210, 0, 0));
                PasswordBoxInRegister.Foreground = new SolidColorBrush(Color.FromRgb(210, 0, 0));
                _isPasswordConfirmed = false;
            }
            else
            {
                ConfirmPasswordBox.Foreground = new SolidColorBrush(Color.FromRgb(230, 230, 230));
                PasswordBoxInRegister.Foreground = new SolidColorBrush(Color.FromRgb(230, 230, 230));
                _isPasswordConfirmed = true;
            }
            InputDataValidator();
        }

        private void RegistratinWindow_NextButtonClick(object sender, RoutedEventArgs e)
        {
            //ConfirmPasswordBox.Password = "";
            //PasswordBoxInRegister.Password = "";
            //RegistrationWindow_EmailTextBox.Text = "";
            //RegistrationWindow_FirstNameTextBox.Text = "";
            //RegistrationWindow_LastNameTextBox.Text = "";
            //RegistrationWindow_LoginTextBox.Text = "";
        }

        private void AnyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputDataValidator();
        }
        private void InputDataValidator()
        {
            if (RegistrationWindow_EmailTextBox.Text != "" &&
               RegistrationWindow_FirstNameTextBox.Text != "" &&
               RegistrationWindow_LastNameTextBox.Text != "" &&
               RegistrationWindow_LoginTextBox.Text != "" &&
               PasswordBoxInRegister.Password != "" &&
               ConfirmPasswordBox.Password != "" &&
               _isPasswordConfirmed
               )
            {
                RegistratinWindow_NextButton.IsEnabled = true;
            }
            else
            {
                RegistratinWindow_NextButton.IsEnabled = false;
            }
        }
    }
}
