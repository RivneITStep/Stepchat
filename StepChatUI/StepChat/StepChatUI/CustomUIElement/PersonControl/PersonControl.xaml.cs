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

namespace StepChat.StepChatUI.CustomUIElement.PersonControl
{
    public partial  class PersonControl : UserControl
    {
        public int ChatId { get; set; }
        private string _lastMessage;
        public string LastMessage
        {
            get => _lastMessage;
            set
            {
                _lastMessage = value;
                SetMessage(value);
            }
        }
        private string _contactName;
        public string ContactName
        {
            get => _contactName;
            set
            {
                _contactName = value;
                contactNameLabel.Content = _contactName;
            }
        }
        private DateTime _timeOfLastMessage;
        public DateTime TimeOfLastMessage
        {
            get => _timeOfLastMessage;
            set
            {
                _timeOfLastMessage = value;
                SetTimeSended(value);
            }
        }
        private ImageSource _userImage;
        public ImageSource ImageSource
        {
            get => _userImage;
            set
            {
                _userImage = value;
                SetImage(value);
            }
        }
        public delegate void EmptyDelegate(object sender, RoutedEventArgs e);
        public event EmptyDelegate OpenPersonalInfo;
        public PersonControl(int id, string lastMessage, string contactName, DateTime _lastSendedMessageTime, ImageSource image = null)
        {
            InitializeComponent();
            //SetImage(image);
            ChatId = id;
            LastMessage = lastMessage;
            ContactName = contactName;
            TimeOfLastMessage = _lastSendedMessageTime;
            contactNameLabel.Content = ContactName;
            lastSendedMessageTime.Content = TimeOfLastMessage.ToShortTimeString();


        }
        private void SetImage(ImageSource image)
        {
            if (image == null)
            {
                userImage.Visibility = Visibility.Visible;
            }
            else
            {
                userImage.Visibility = Visibility.Hidden;
                UserImage.ImageSource = image;
            }
        }
        private void SetMessage(string message)
        {
            lastMessage.Text = message.Substring(0, 20) + "...";
        }
        private void SetTimeSended(DateTime time)
        {
            lastSendedMessageTime.Content = (time.Hour / 10 == 0 ? "0" + time.Hour : time.Hour.ToString()) + ":" + (time.Minute / 10 == 0 ? "0" + time.Minute : time.Minute.ToString());
        }

     

        private void OpenPersonalInfoClick(object sender, RoutedEventArgs e)
        {
            if(OpenPersonalInfo!=null)
            {
                OpenPersonalInfo.Invoke(sender, e);
            }
        }
    }
}
