﻿using StepChat.StepChatUI.CustomUIElement.PersonControl;
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

namespace StepChat.StepChatUI.MainWindow.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :  UserControl
    {
        private ColorConverter colorConverter;
        private bool isDarkTheme;
        public MainWindow()
        {
            InitializeComponent();
            isDarkTheme = true;
        }

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
    }
}
