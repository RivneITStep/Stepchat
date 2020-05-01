using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Service.DTO;
using StepChat.StepChatService;
using StepChat.StepChatUI.BaseViewModel;
using StepChat.StepChatUI.Commands;//нейм спейс з описаним класом DelegateClickCommand
using StepChat.StepChatUI.CustomUIElement.MessageControl;

namespace StepChat.StepChatUI.MainWindow.ViewModel
{
    class MainWindowViewModel : BaseViewModelUI
    {
        User user;
        public void ResetUser(object obj)
        {
            user = (obj as User);
        }
        public MainWindowViewModel()
        {
            MainWindowMessageControlListView = new ObservableCollection<MessageControl>();
        }
        private string _mainWindowEnterYourMessageTextBox;
        public string MainWindowEnterYourMessageTextBox
        {
            get => _mainWindowEnterYourMessageTextBox;
            set
            {
                _mainWindowEnterYourMessageTextBox = value;
                OnPropertyChanged(nameof(MainWindowEnterYourMessageTextBox));
            }
        }
        private ObservableCollection<MessageControl> _mainWindowMessageControlListView { get; set; }
        public ObservableCollection<MessageControl> MainWindowMessageControlListView
        {
            get { return _mainWindowMessageControlListView; }
            set
            {
                _mainWindowMessageControlListView = value;
                OnPropertyChanged(nameof(MainWindowMessageControlListView));
            }
        }

        public ICommand MainWindow_SendMessageButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    var res = new MessageControl(MainWindowEnterYourMessageTextBox, DateTime.Now);
                    res.HorizontalAlignment = HorizontalAlignment.Right;
                    MainWindowMessageControlListView.Add(res);
                });
            }
        }
        public ICommand buttonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    //ось тут буде виконуватись код на клік кнопки
                    MessageBox.Show("Ти на кнопку нажал ☻");
                });
            }
        }
    }
}
