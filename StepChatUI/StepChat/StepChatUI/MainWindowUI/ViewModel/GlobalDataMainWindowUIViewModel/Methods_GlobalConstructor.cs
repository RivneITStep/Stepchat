using StepChat.ServiceReference1;
using StepChat.StepChatUI.CustomUIElement.MessageControl;
using StepChat.StepChatUI.CustomUIElement.PersonControl;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private List<string> Attacments { get; set; } = new List<string>();
        public MainWindowUIViewModel()
        {
            SetRengerState(RendererWindow.LoginRegistrationWindow);
            Attacments = new List<string>();
            PersonalUserInfoItemVisability = Visibility.Collapsed;
            MainWindowMessageControlListView = new ObservableCollection<MessageControl>();
            MainWindowContactListListView = new ObservableCollection<PersonControl>();



            ////#############################################################################
            SearchWindowAddButtonIsEnabled = false;
            OnTextChanged += OnSearchWindowTextBoxTextChanged;
            OnSelectionChanged += OnSearchWindowSelectionChanged;
            //#############################################################################
        }
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
    }
}
