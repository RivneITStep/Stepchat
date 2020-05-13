using System.Windows;
namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    partial class MainWindowUIViewModel
    {
        public string LoginText
        {
            get
            {
                return _login;
            }
            set
            {
                this._login = value;
                OnPropertyChanged(nameof(LoginText));
            }
        }
        public Visibility ProgressBarVisibility
        {
            get
            {
                return _progressBarVisibility;
            }
            set
            {
                _progressBarVisibility = value;
                OnPropertyChanged(nameof(ProgressBarVisibility));
            }
        }
        public Visibility LoginWindowVisibility
        {
            get
            {
                return _loginWindowVisibility;
            }
            set
            {
                _loginWindowVisibility = value;
                OnPropertyChanged(nameof(LoginWindowVisibility));
            }
        }
        public Visibility RegistrationWindowVisibility
        {
            get
            {
                return _registrationWindowVisibility;
            }
            set
            {
                _registrationWindowVisibility = value;
                OnPropertyChanged(nameof(RegistrationWindowVisibility));
            }
        }
        public string LoginWindow_ErrorTextBox
        {
            get => _loginWindow_ErrorTextBox;
            set
            {
                _loginWindow_ErrorTextBox = value;
                OnPropertyChanged(nameof(LoginWindow_ErrorTextBox));
            }
        }
        public string RegistrationWindow_ErrorTextBox
        {
            get => _registrationWindow_ErrorTextBox;
            set
            {
                _registrationWindow_ErrorTextBox = value;
                OnPropertyChanged(nameof(RegistrationWindow_ErrorTextBox));
            }
        }
        public string RegistrationWindow_FirstNameTextBox
        {
            get => _registrationWindow_FirstNameTextBox;
            set
            {
                _registrationWindow_FirstNameTextBox = value;
                OnPropertyChanged(nameof(RegistrationWindow_FirstNameTextBox));
            }
        }
        public string RegistrationWindow_LastNameTextBox
        {
            get => _registrationWindow_LastNameTextBox;
            set
            {
                _registrationWindow_LastNameTextBox = value;
                OnPropertyChanged(nameof(RegistrationWindow_LastNameTextBox));
            }
        }
        public string RegistrationWindow_EmailTextBox
        {
            get => _registrationWindow_EmailTextBox;
            set
            {
                _registrationWindow_EmailTextBox = value;
                OnPropertyChanged(nameof(RegistrationWindow_EmailTextBox));
            }
        }
        public string RegistrationWindow_LoginTextBox
        {
            get => _registrationWindow_LoginTextBox;
            set
            {
                _registrationWindow_LoginTextBox = value;
                OnPropertyChanged(nameof(RegistrationWindow_LoginTextBox));
            }
        }
    }
}
