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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ColorConverter colorConverter;
        private bool isDarkTheme;
        public MainWindow()
        {
            InitializeComponent();
            isDarkTheme = true;
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(isDarkTheme)
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
         Application.Current.Resources["PrimarySecondColor"]= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#90a4ae"));
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
    }
}
