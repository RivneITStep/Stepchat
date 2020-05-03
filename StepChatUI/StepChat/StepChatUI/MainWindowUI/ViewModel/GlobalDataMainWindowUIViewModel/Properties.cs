using System.Windows;
namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    partial class MainWindowUIViewModel
    {
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
