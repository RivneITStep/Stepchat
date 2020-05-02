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
        private void SetRengerState(RendererWindow window)
        {
            switch (window)
            {
                case RendererWindow.LoginRegistrationWindow:
                    MainWindow_Visibility = Visibility.Hidden;
                    LoginRegistrationWindow_Visibility = Visibility.Visible;
                    ProgressBarVisibility = Visibility.Hidden;
                    LoginWindowVisibility = Visibility.Visible;
                    RegistrationWindowVisibility = Visibility.Hidden;
                    MinWindowHeight = 500;
                    MinWindowWidth = 500;
                    MaxWindowWidth = 500;
                    MaxWindowHeight = 500;
                    WindowHeight = 500;
                    WindowWidth = 500;
                    break;
                case RendererWindow.MainWindow:
                    MainWindow_Visibility = Visibility.Visible;
                    LoginRegistrationWindow_Visibility = Visibility.Hidden;
                    MinWindowWidth = 1248;
                    MinWindowHeight = 800;
                    MaxWindowHeight = 1080;
                    MaxWindowWidth = 1920;
                    WindowHeight = 800;
                    WindowWidth = 1248;
                    break;
                default:
                    break;
            }
        }

        private int _minWindowWidth ;
        private int _minWindowHeight; 
        private int _windowWidth;
        private int _windowHeight;
        private int _maxWindowWidth;
        private int _maxWindowHeight;
        public int WindowWidth
        {
            get => _windowWidth;
            set
            {
                _windowWidth = value;
                OnPropertyChanged(nameof(WindowWidth));
            }
        }
        public int WindowHeight
        {
            get => _windowHeight;
            set
            {
                _windowHeight = value + 25;
                OnPropertyChanged(nameof(WindowHeight));
            }
        }
        public int MaxWindowWidth
        {
            get => _maxWindowWidth;
            set
            {
                _maxWindowWidth = value;
                OnPropertyChanged(nameof(MaxWindowWidth));
            }
        }
        public int MaxWindowHeight
        {
            get => _maxWindowHeight;
            set
            {
                _maxWindowHeight = value + 25;
                OnPropertyChanged(nameof(MaxWindowHeight));
            }
        }
        public int MinWindowWidth
        {
            get => _minWindowWidth;
            set
            {
                _minWindowWidth = value;
                OnPropertyChanged(nameof(MinWindowWidth));
            }
        }
        public int MinWindowHeight
        {
            get => _minWindowHeight;
            set
            {
                _minWindowHeight = value + 25;
                OnPropertyChanged(nameof(MinWindowHeight));
            }
        }

        private bool _searchWindowAddButtonIsEnabled { get; set; }
        private Visibility _mainWindow_Visibility;
        private Visibility _loginRegistrationWindow_Visibility;

        public bool SearchWindowAddButtonIsEnabled
        {
            get => _searchWindowAddButtonIsEnabled;
            set
            {
                _searchWindowAddButtonIsEnabled = value;
                OnPropertyChanged(nameof(_searchWindowAddButtonIsEnabled));
            }
        }
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
