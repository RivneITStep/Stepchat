using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StepChat.ServiceReference1;
using StepChat.StepChatUI.BaseViewModel;
using StepChat.StepChatUI.Commands;
using StepChat.StepChatUI.CustomUIElement.MessageControl;
using StepChat.StepChatUI.CustomUIElement.PersonControl;

namespace StepChat.StepChatUI.MainWindow.ViewModel
{
    class MainWindowViewModel : BaseViewModelUI
    {
        User user;
        ServiceClient service;
        public void ResetUser(User user, ServiceClient service)
        {
            this.user = user;
            this.service = service;
            service.CreateChat("Chat1");   
            service.CreateChat("Chat2");   
            service.CreateChat("Chat3");
            service.CreatePrivateChat(2);
            service.CreatePrivateChat(3);
            LoadChats();
        }
        private void LoadChats()
        {
            Task.Run(() =>
            {
                MainWindowContactListListView.Clear();
                var res = service.GetChats();
                foreach (var item in service.GetChats().Data.OrderByDescending(q => q.Id))
                {
                    MainWindowContactListListView.Add(new PersonControl(new Contact(item.Id, item.Name, "last name", item.Description)));
                }
            });
        }
        private void LoadMessage(int ChatId)
        {
            Task.Run(() =>
            {
                MainWindowMessageControlListView.Clear();
                foreach (var item in service.GetMessages(ChatId, 0, 100).Data)
                {
                    MainWindowMessageControlListView.Add(new MessageControl(item));
                }
            });
        }
        private PersonControl _mainWindowContactListListViewSelectedItem;
        public PersonControl MainWindowContactListListViewSelectedItem
        {
            get
            {
                return _mainWindowContactListListViewSelectedItem;
            }
            set
            {
                _mainWindowContactListListViewSelectedItem = value;
                OnPropertyChanged(nameof(MainWindowContactListListViewSelectedItem));
                LoadMessage(_mainWindowContactListListViewSelectedItem.contact.ID);
            }
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
        private ObservableCollection<PersonControl> _mainWindowContactListListView { get; set; }
        public ObservableCollection<PersonControl> MainWindowContactListListView
        {
            get { return _mainWindowContactListListView; }
            set
            {
                _mainWindowContactListListView = value;
                OnPropertyChanged(nameof(MainWindowContactListListView));
            }
        }

        public ICommand MainWindow_SendMessageButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    
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
