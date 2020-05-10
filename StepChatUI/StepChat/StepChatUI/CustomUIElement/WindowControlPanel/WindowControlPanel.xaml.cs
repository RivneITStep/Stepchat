using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StepChat.StepChatUI.CustomUIElement.WindowControlPanel
{
    public partial class WindowControlPanel : UserControl
    {
        public delegate void ButtonEnter(object sender, RoutedEventArgs e);

        public event ButtonEnter ButtonClose_MouseClick_Handler;
        public event ButtonEnter ButtonMaximize_MouseClick_Handler;
        public event ButtonEnter ButtonMinimize_MouseClick_Handler;
        public WindowControlPanel()
        {
            InitializeComponent();
        }
        private void ButtonClose_MouseClick(object sender, RoutedEventArgs e)
        {
            ButtonClose_MouseClick_Handler?.Invoke(sender, e);
        }

        private void ButtonMaximize_MouseClick(object sender, RoutedEventArgs e)
        {
            ButtonMaximize_MouseClick_Handler?.Invoke(sender, e);
        }

        private void ButtonMinimize_MouseClick(object sender, RoutedEventArgs e)
        {
            ButtonMinimize_MouseClick_Handler?.Invoke(sender, e);
        }
    }
}
