using StepChat.ServiceReference1;
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
        public MessageControl(Message message)
        {
            InitializeComponent();
            SetMessage(message.Text);
            SetTimeSended(message.SendDate);
            SetMessageState(MessageState.Readed);
        }
        public MessageControl(string message)
        {
            InitializeComponent();
            SetMessage(message);
            SetTimeSended(DateTime.Now);
            SetMessageState(MessageState.Readed);
        }
            public void SetMessageState(MessageState state)
        {
            switch (state)
            {
                case MessageState.Readed:
                    Check.Visibility = Visibility.Collapsed;
                    Checks.Visibility = Visibility.Visible;
                    break;
                case MessageState.NotReaded:
                    Check.Visibility = Visibility.Visible;
                    Checks.Visibility = Visibility.Collapsed;
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
            Date.Text = (time.Hour/10==0?"0"+ time.Hour : time.Hour.ToString()) + ":" + (time.Minute / 10 == 0 ? "0" + time.Minute : time.Minute.ToString());
        }
    }
}
