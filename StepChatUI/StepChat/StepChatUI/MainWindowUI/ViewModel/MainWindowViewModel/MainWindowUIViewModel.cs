using StepChat.ServiceReference1;
using StepChat.StepChatUI.Commands;
using StepChat.StepChatUI.CustomUIElement.MessageControl;
using StepChat.StepChatUI.CustomUIElement.PersonControl;
using StepChat.StepChatUI.CustomUIElement.SearchPersonControl;
using StepChat.StepChatUI.CustomUIElement.PersonalInfoControl;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

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

        private delegate void emptyDelegate();
        private event emptyDelegate OnTextChanged;
        private event emptyDelegate OnSelectionChanged;
        private void LoadChats()
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate
            {
                MainWindowContactListListView.Clear();
                var res = Service.GetChats();
                foreach (var item in res.Data)
                {
                    MainWindowContactListListView.Add(new PersonControl(item.Id, "A binary tree is made of nodes, where each node contains ", item.Name, DateTime.Now));
                }
            });
            });
        }
        public string SearchWindowTextBoxText
        {
            get { return _searchWindowTextBoxText; }
            set { _searchWindowTextBoxText = value; OnPropertyChanged(nameof(SearchWindowTextBoxText)); OnTextChanged.Invoke(); }
        }

        #region Properties
        private static ObservableCollection<SearchPersonControl> _searchWindowContactsList { get; set; }
        private void LoadMessages(int ChatId)
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate
            {
                MainWindowMessageControlListView.Clear();
                var g = User.Id;
                var r = Service.GetMessages(ChatId);
                if (r.Data == null)
                {
                    return;
                }
                foreach (var item in r.Data)
                {
                    if (item.SenderId == User.Id)
                    {
                        MainWindowMessageControlListView.Add(new MessageControl(item,HorizontalAlignment.Right));
                    }
                    else
                    {
                        MainWindowMessageControlListView.Add(new MessageControl(item,HorizontalAlignment.Left));
                    }
                }
            });
            });
        }
        private PersonControl _mainWindowContactListListViewSelectedItem;
        private string _mainWindowEnterYourMessageTextBox;
        private ObservableCollection<MessageControl> _mainWindowMessageControlListView { get; set; }
        private ObservableCollection<PersonControl> _mainWindowContactListListView { get; set; }
        private SearchPersonControl _searchSelectedItem { get; set; }
        private ObservableCollection<PersonalInfoControl> _personalUserInfoItem { get; set; }
        private bool _searchWindowAddButtonIsEnabled { get; set; }
        private Visibility _personalUserInfoItemVisability { get; set; }

        public Visibility PersonalUserInfoItemVisability { get { return _personalUserInfoItemVisability; } set { _personalUserInfoItemVisability = value; OnPropertyChanged(nameof(PersonalUserInfoItemVisability)); } }
        public bool SearchWindowAddButtonIsEnabled
        {
            get => _searchWindowAddButtonIsEnabled;
            set
            {
                _searchWindowAddButtonIsEnabled = value;
                OnPropertyChanged(nameof(SearchWindowAddButtonIsEnabled));
            }
        }
        public ObservableCollection<PersonalInfoControl> PersonalUserInfoItem { get { return _personalUserInfoItem; } set { _personalUserInfoItem = value; OnPropertyChanged(nameof(PersonalUserInfoItem)); } }
        public SearchPersonControl SearchSelectedItem { get { return _searchSelectedItem; }
            set {
               if (value != null && value != _searchSelectedItem)
                {
                    SearchWindowAddButtonIsEnabled = true;
                    _searchSelectedItem = value; OnSelectionChanged.Invoke();
                }
                else
                { OnSelectionChanged.Invoke();
                    SearchWindowAddButtonIsEnabled = false; } } }
        public ObservableCollection<SearchPersonControl> SearchWindowContactsList
        {
            get { return _searchWindowContactsList; }
            set { _searchWindowContactsList = value; OnPropertyChanged(nameof(SearchWindowContactsList)); }
        }
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
        public string MainWindowEnterYourMessageTextBox
        {
            get => _mainWindowEnterYourMessageTextBox;
            set
            {
                _mainWindowEnterYourMessageTextBox = value;
                OnPropertyChanged(nameof(MainWindowEnterYourMessageTextBox));
            }
        }
        public ObservableCollection<MessageControl> MainWindowMessageControlListView
        {
            get { return _mainWindowMessageControlListView; }
            set
            {
                _mainWindowMessageControlListView = value;
                OnPropertyChanged(nameof(MainWindowMessageControlListView));
            }
        }
        public ObservableCollection<PersonControl> MainWindowContactListListView
        {
            get { return _mainWindowContactListListView; }
            set
            {
                _mainWindowContactListListView = value;
                OnPropertyChanged(nameof(MainWindowContactListListView));
            }
        }
        #endregion

        private void OnSearchWindowTextBoxTextChanged()
       {
            if (SearchWindowTextBoxText.Length!=0 && SearchWindowTextBoxText != null && SearchWindowTextBoxText !="")
            {
                SearchWindowContactsList.Clear();
                var res = Service.SearchUsers(SearchWindowTextBoxText);
                if (res.IsSuccess)
                {
                    foreach (var it in res.Data)
                    {
                        
                        SearchWindowContactsList.Add(new SearchPersonControl(it));
                    }
                }
                else
                {
                    SearchWindowContactsList.Clear();
                }
            }
        }
        private void OnSearchWindowSelectionChanged()
        {

        }
        public ICommand MainWindow_SendMessageButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    if(MainWindowContactListListViewSelectedItem==null)
                    {
                        return;
                    }
                    Service.SendMessage(MainWindowContactListListViewSelectedItem.ChatId, MainWindowEnterYourMessageTextBox);
                });
            }
        }
        public ICommand MainWindowAddNewContactClick 
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    PersonControl contactToAdd = new PersonControl(SearchSelectedItem.User.Id, "A binary tree is made of nodes, where each node contains ", SearchSelectedItem.User.FirstName, DateTime.Now,null);
               if (!MainWindowContactListListView.Contains(contactToAdd))
                    {
                        MainWindowContactListListView.Add(contactToAdd);
                        Service.AddContact(SearchSelectedItem.User.Id);
                        Service.CreatePrivateChat(SearchSelectedItem.User.Id);
                    }
                });
            }
        }
        public ICommand OpenPersonalInfoButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    PersonalUserInfoItemVisability = Visibility.Visible;
                });
            }
        }
        public ICommand PersonalInfoDeleteButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {

                });
            }
        }
        public ICommand MainWindowSaveChanges
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {

                });
            }
        }
        

    }
}

