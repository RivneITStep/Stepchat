using StepChat.StepChatUI.BaseViewModel;
using StepChat.StepChatUI.LoginRegistration.ViewModel;
using StepChat.StepChatUI.MainWindow.View;
using StepChat.StepChatUI.MainWindow.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StepChat.RendererWindow.ViewModel
{
    public enum RendererWindowState
    {
        LoginRegistrationWindow,
        MainWindow
    }
    class RendererWindowViewModel : BaseViewModelUI
    {
        public static RendererWindowViewModel RWVM;
        public RendererWindowViewModel()
        {
        }
        public void SetDefaulth()
        {
            RWVM = new RendererWindowViewModel();
            RWVM.LoginRegistrationViewModel = new LoginRegistrationViewModel();
            RWVM.MainWindowViewModel = new MainWindowViewModel();
            RWVM.currentViewModel = RWVM.LoginRegistrationViewModel;
            RWVM.Min_MaxWindowHeight = 500;
            RWVM.Min_MaxWindowWidth = 500;
        }
        //private LoginRegistrationViewModel registration_ViewModel = new LoginRegistrationViewModel();
        //private MainWindowViewModel mainWindow_ViewModel = new MainWindowViewModel();
        MainWindowViewModel MainWindowViewModel;
        LoginRegistrationViewModel LoginRegistrationViewModel;
        public BaseViewModelUI currentViewModel;
        public BaseViewModelUI CurrentViewModel
        {
            get => RWVM.currentViewModel;
            set
            {
                RWVM.currentViewModel = value;
                RWVM.OnPropertyChanged(nameof(CurrentViewModel));
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
        public void Swich(RendererWindowState state, object obj = null)
        {
            switch (state)
            {
                case RendererWindowState.LoginRegistrationWindow:
                    CurrentViewModel = new LoginRegistrationViewModel();
                    Min_MaxWindowHeight = 500;
                    Min_MaxWindowWidth = 500;
                    break;
                case RendererWindowState.MainWindow:
                    if(obj==null)
                    {
                        return;
                    }
                    CurrentViewModel = MainWindowViewModel;
                    MainWindowViewModel.ResetUser(obj);
                    Min_MaxWindowHeight = 800;
                    Min_MaxWindowWidth = 1248;
                    break;
                default:
                    break;
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
