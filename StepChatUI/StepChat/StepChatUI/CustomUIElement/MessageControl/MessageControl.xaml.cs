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

namespace StepChat.StepChatUI.CustomUIElement.MessageControl
{
    public enum MessageState
    {
        Readed,
        NotReaded
    }
    public partial class MessageControl : UserControl
    {
        public MessageControl(string message, DateTime timeSended)
        {
            InitializeComponent();
            SetMessage(message);
            SetTimeSended(timeSended);
            SetMessageState(MessageState.Readed);
        }
        public void SetMessageState(MessageState state)
        {
            switch (state)
            {
                case MessageState.Readed:
                    Check.Visibility = Visibility.Hidden;
                    Checks.Visibility = Visibility.Visible;
                    break;
                case MessageState.NotReaded:
                    Check.Visibility = Visibility.Visible;
                    Checks.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }
        public void ChangeMessage(string message)
        {
            SetMessage(message);
        }
        private void SetMessage(string message)
        {
            Message.Text = message;
        }
        private void SetTimeSended(DateTime time)
        {
            Date.Text = time.Hour + time.Minute+"";
        }
    }
}
