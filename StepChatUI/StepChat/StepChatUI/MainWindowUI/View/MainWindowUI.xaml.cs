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

namespace StepChat.StepChatUI.MainWindowUI.View
{
    public partial class MainWindowUI : Window
    {
        private bool _isPasswordConfirmed = false;
        public MainWindowUI()
        {
            InitializeComponent();
            WindowControlPanel_.ButtonClose_MouseClick_Handler += Window_Closed;
            WindowControlPanel_.ButtonMinimize_MouseClick_Handler += Window_Minimize;
            WindowControlPanel_.ButtonMaximize_MouseClick_Handler += Window_Maximize;
            RegistratinWindow_NextButton.IsEnabled = false;
            isDarkTheme = true;
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
        #region LoginRegistration
        //#####################################################################################
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
        //#####################################################################################
        #endregion
        #region MainWindow
        //#####################################################################################
        private ColorConverter colorConverter;
        private bool isDarkTheme;

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //PrimaryColor primary = PrimaryColor.DeepPurple;
            //Color primaryColor = SwatchHelper.Lookup[(MaterialDesignColor.Red)];

            //SecondaryColor secondary = SecondaryColor.Teal;
            //Color secondaryColor = SwatchHelper.Lookup[(MaterialDesignColor)SecondaryColor.Blue];

            //IBaseTheme baseTheme = Theme.Dark;

            //ITheme theme = Theme.Create(baseTheme, primaryColor, secondaryColor);



            if (isDarkTheme)
            {
                ChangeThemeToLight();

            }
            else
            {
                ChangeThemeToDark();

            }
            isDarkTheme = !isDarkTheme;

        }
        private void ChangeThemeToLight()
        {
            Application.Current.Resources["PrimaryColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#eceff1"));
            Application.Current.Resources["PrimarySecondColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#90a4ae"));
            Application.Current.Resources["AccentColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1565c0"));
            Application.Current.Resources["ForegroundColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }
        private void ChangeThemeToDark()
        {
            Application.Current.Resources["PrimaryColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF303030"));
            Application.Current.Resources["PrimarySecondColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#394045"));
            Application.Current.Resources["AccentColor"] = new SolidColorBrush(Colors.Indigo);
            Application.Current.Resources["ForegroundColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Margin = new Thickness(0);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Margin = new Thickness(2);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenSearchMenu();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            OpenSettingsMenu();
        }

        //private void AddContact(PersonControl person)
        //{
        //    contactsList.Items.Add(person);
        //}
        //private void Delete(int id)
        //{
        //    contactsList.Items.RemoveAt(id);
        //}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void CloseAllMenus()
        {
            searchMenuGrid.Visibility = Visibility.Collapsed;
            settingsMenuGrid.Visibility = Visibility.Collapsed;
        }
        private void OpenSearchMenu()
        {
            searchMenuGrid.Visibility = Visibility.Visible;
        }
        private void OpenSettingsMenu()
        {
            settingsMenuGrid.Visibility = Visibility.Visible;
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            CloseAllMenus();
        }
        //#####################################################################################
        #endregion

        private void SaveChages(object sender, RoutedEventArgs e)
        {

        }
    }
}
