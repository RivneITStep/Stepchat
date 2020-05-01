using StepChat.ServiceReference1;
using StepChat.StepChatUI.CustomUIElement.MessageControl;
using StepChat.StepChatUI.CustomUIElement.PersonControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    public enum RendererWindow
    {
        LoginRegistrationWindow,
        MainWindow
    }
    partial class MainWindowUIViewModel
    {
        private User User { get; set; }
        private ServiceClient Service { get; set; }
        public MainWindowUIViewModel()
        {
            SetRengerState(RendererWindow.LoginRegistrationWindow);


            MainWindowMessageControlListView = new ObservableCollection<MessageControl>();
            MainWindowContactListListView = new ObservableCollection<PersonControl>();

            //#############################################################################
            //Login Registration
            ProgressBarVisibility = Visibility.Hidden;
            LoginWindowVisibility = Visibility.Visible;
            RegistrationWindowVisibility = Visibility.Hidden;
            //#############################################################################
            //#############################################################################
            Min_MaxWindowHeight = 500;
            Min_MaxWindowWidth = 500;
            //#############################################################################
        }
        private void SetRengerState(RendererWindow window)
        {
            switch (window)
            {
                case RendererWindow.LoginRegistrationWindow:
                    MainWindow_Visibility = Visibility.Hidden;
                    LoginRegistrationWindow_Visibility = Visibility.Visible;
                    Min_MaxWindowHeight = 500;
                    Min_MaxWindowWidth = 500;
                    break;
                case RendererWindow.MainWindow:
                    MainWindow_Visibility = Visibility.Visible;
                    LoginRegistrationWindow_Visibility = Visibility.Hidden;
                    Min_MaxWindowHeight = 800;
                    Min_MaxWindowWidth = 1248;
                    break;
                default:
                    break;
            }
        }

        private int _min_maxWidth;
        private int _min_maxHeight;
        public int Min_MaxWindowWidth
        {
            get => _min_maxWidth;
            set
            {
                _min_maxWidth = value;
                OnPropertyChanged(nameof(Min_MaxWindowWidth));
            }
        }
        public int Min_MaxWindowHeight
        {
            get => _min_maxHeight;
            set
            {
                _min_maxHeight = value + 25;
                OnPropertyChanged(nameof(Min_MaxWindowHeight));
            }
        }

        private Visibility _mainWindow_Visibility;
        private Visibility _loginRegistrationWindow_Visibility;

        public Visibility MainWindow_Visibility
        {
            get => _mainWindow_Visibility;
            set
            {
                _mainWindow_Visibility = value;
                OnPropertyChanged(nameof(MainWindow_Visibility));
            }
        }
        public Visibility LoginRegistrationWindow_Visibility
        {
            get => _loginRegistrationWindow_Visibility;
            set
            {
                _loginRegistrationWindow_Visibility = value;
                OnPropertyChanged(nameof(LoginRegistrationWindow_Visibility));
            }
        }

    }
}
