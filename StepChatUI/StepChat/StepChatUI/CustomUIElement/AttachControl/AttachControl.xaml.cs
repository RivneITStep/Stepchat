using System;
using System.Collections.Generic;
using System.IO;
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

namespace StepChat.StepChatUI.CustomUIElement.AttachControl
{
    public partial class AttachControl : UserControl
    {
        public int id { get; set; }
        public delegate void ButtonEnter(object sender, RoutedEventArgs e, int id);
        public event ButtonEnter Button_MouseClick_Handler;
        public AttachControl(string FileName, string fileType, int Id)
        {
            InitializeComponent();
            id = Id;
            file_extension.Text = fileType;
            ToolTipGrid.ToolTip = FileName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button_MouseClick_Handler?.Invoke(sender, e, id);
        }
    }
}
