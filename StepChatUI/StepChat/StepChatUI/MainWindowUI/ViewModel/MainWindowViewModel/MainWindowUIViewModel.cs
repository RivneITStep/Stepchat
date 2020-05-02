using StepChat.ServiceReference1;
using StepChat.StepChatUI.Commands;
using StepChat.StepChatUI.CustomUIElement.MessageControl;
using StepChat.StepChatUI.CustomUIElement.PersonControl;
using StepChat.StepChatUI.CustomUIElement.SearchPersonControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    partial class MainWindowUIViewModel : BaseViewModel.BaseViewModelUI
    {
        private void ResetUser(User user, ServiceClient service)
        {
            User = user;
            Service = service;
            LoadChats();
            SearchWindowContactsList = new ObservableCollection<SearchPersonControl>();
        }
        private string _searchWindowTextBoxText;

        private delegate void textChancgedDelegate();
        private event textChancgedDelegate OnTextChanged;
        private void LoadChats()
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate
            {
                MainWindowContactListListView.Clear();
                var res = Service.GetChats();
                foreach (var item in Service.GetChats().Data)
                {
                    MainWindowContactListListView.Add(new PersonControl(item.Id, "A binary tree is made of nodes, where each node contains ", "Osass Bibla", DateTime.Now));
                }
            });
            });
        }
        public string SearchWindowTextBoxText
        {
            get { return _searchWindowTextBoxText; }
            set { _searchWindowTextBoxText = value; OnPropertyChanged(nameof(SearchWindowTextBoxText)); OnTextChanged.Invoke(); }
        }
        private static ObservableCollection<SearchPersonControl> _searchWindowContactsList;
        public ObservableCollection<SearchPersonControl> SearchWindowContactsList
        {
            get { return _searchWindowContactsList; }
            set { _searchWindowContactsList = value; }
        }
        private void LoadMessages(int ChatId)
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate
            {
                MainWindowMessageControlListView.Clear();
                var r = Service.GetMessages(ChatId, 0, 100);
                if (r.Data == null)
                {
                    return;
                }
                foreach (var item in r.Data)
                {
                    if (item.SenderId == User.Id)
                    {
                        MainWindowMessageControlListView.Add(new MessageControl(item) { HorizontalAlignment = System.Windows.HorizontalAlignment.Right });
                    }
                    else
                    {
                        MainWindowMessageControlListView.Add(new MessageControl(item) { HorizontalAlignment = System.Windows.HorizontalAlignment.Left });
                    }
                }
            });
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
                LoadMessages(_mainWindowContactListListViewSelectedItem.ChatId);
            }
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
        private void OnSearchWindowTextBoxTextChanged()
        {
            SearchWindowContactsList.Clear();
            var res = Service.SearchUsers($"Select * from Users as U where U.Login like '[{SearchWindowTextBoxText}]%' or U.FirstName like '[{SearchWindowTextBoxText}]%' or U.LastName like '[{SearchWindowTextBoxText}]%'");
            if (res.IsSuccess)
            {
                foreach (var it in res.Data)
                {
                    SearchWindowContactsList.Add(new SearchPersonControl(it.FirstName, it.LastName));
                }
            }
            else
            {

            }
        }
        bool s = false;
        public ICommand MainWindow_SendMessageButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    if (MainWindowContactListListViewSelectedItem == null)
                    {
                        return;
                    }
                    if (s)
                    {
                        MainWindowMessageControlListView.Add(new MessageControl(MainWindowEnterYourMessageTextBox) { HorizontalAlignment = System.Windows.HorizontalAlignment.Right });
                    }
                    else
                    {
                        MainWindowMessageControlListView.Add(new MessageControl(MainWindowEnterYourMessageTextBox) { HorizontalAlignment = System.Windows.HorizontalAlignment.Left });
                    }
                    s = !s;
                    //Service.SendMessage(MainWindowContactListListViewSelectedItem.ChatId, MainWindowEnterYourMessageTextBox);
                });
            }
        }
    }
}

