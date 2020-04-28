using StepChat.Login_Registration.Comands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LoginRegistration.Login_Registration.ViewModel
{
    class LoginRegistration_ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public LoginRegistration_ViewModel()
        {
            _visibility = Visibility.Hidden;
        }
        private string _login;
        private Visibility _visibility;
        private string _Password;
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
                return _visibility;
            }
            set
            {
                _visibility = value;
                OnPropertyChanged(nameof(ProgressBarVisibility));
            }
        }
        public string PasswordText
        {
            get
            {
                return _Password;
            }
            set
            {
                this._Password = value;
            }
        }
        public ICommand LoginButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {

                    CheckAndChangeProgressBarVisibility();
                });
            }
        }
        public ICommand CreateNewAccountButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {

                    CheckAndChangeProgressBarVisibility();
                });
            }
        }
        private void CheckAndChangeProgressBarVisibility()
        {
            if (ProgressBarVisibility == Visibility.Hidden)
            {
                ProgressBarVisibility = Visibility.Visible;
            }
            else
            {
                ProgressBarVisibility = Visibility.Hidden;
            }
        }
    }
}
