using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace StepChat
{
    public partial class WindowControlPanel : UserControl
    {
        #region
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        private struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        private static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
        #endregion
        private bool isWindowsControlPanel_MouseDoubleClick;
        public delegate void ButtonEnter(object sender, RoutedEventArgs e);

        public double x { get; set; }
        public double y { get; set; }

        public event ButtonEnter ButtonClose_MouseClick_Handler;
        public event ButtonEnter ButtonMaximize_MouseClick_Handler;
        public event ButtonEnter ButtonMinimize_MouseClick_Handler;
        public WindowControlPanel()
        {
            InitializeComponent();
            isWindowsControlPanel_MouseDoubleClick = false;
        }


        private void ButtonClose_MouseClick(object sender, RoutedEventArgs e)
        {
            ButtonClose_MouseClick_Handler.Invoke(sender, e);
        }

        private void ButtonMaximize_MouseClick(object sender, RoutedEventArgs e)
        {
            ButtonMaximize_MouseClick_Handler.Invoke(sender, e);
        }

        private void ButtonMinimize_MouseClick(object sender, RoutedEventArgs e)
        {
            ButtonMinimize_MouseClick_Handler.Invoke(sender, e);
        }
    }
}
