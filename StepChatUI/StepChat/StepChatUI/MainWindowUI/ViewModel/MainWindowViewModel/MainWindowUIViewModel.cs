using StepChat.ServiceReference1;
using StepChat.StepChatUI.Commands;
using StepChat.StepChatUI.CustomUIElement.MessageControl;
using StepChat.StepChatUI.CustomUIElement.PersonControl;
using StepChat.StepChatUI.CustomUIElement.SearchPersonControl;
using StepChat.StepChatUI.CustomUIElement.PersonalInfoControl;
using StepChat.StepChatUI.CustomUIElement.ContactControl;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    partial class MainWindowUIViewModel : BaseViewModel.BaseViewModelUI
    {
        private delegate void emptyDelegate();


        #region Properties
        private ObservableCollection<PersonalInfoControl> _personalUserInfoItem { get; set; }
        private ObservableCollection<ContactControl> _contactWindowContactsList { get; set; }
        private static ObservableCollection<SearchPersonControl> _searchWindowContactsList { get; set; }
        private ObservableCollection<MessageControl> _mainWindowMessageControlListView { get; set; }
        private ObservableCollection<PersonControl> _mainWindowChatsListView { get; set; }

        private PersonControl _mainWindowContactListListViewSelectedItem;
        private SearchPersonControl _searchSelectedItem { get; set; }
        private ContactControl _contactWindowSelectedContact { get; set; }

        private event emptyDelegate OnTextChanged;

        private string _mainWindowEnterYourMessageTextBox;
        private string _searchWindowTextBoxText;
        private bool _searchWindowAddButtonIsEnabled { get; set; }
        private bool _contactWindowIsDeleteButtonEnabled { get; set; }
        private Visibility _personalUserInfoItemVisability { get; set; }

        private string _personalInfoFirstName { get; set; }
        private string _personalInfoSecondName { get; set; }
        private string _personalInfoEmail { get; set; }
        private string _personalInfoPassword { get; set; }
        private string _personalInfoLogin { get; set; }

        #region PublicProps
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
        public bool ContactWindowIsDeleteButtonEnabled
        {
            get => _contactWindowIsDeleteButtonEnabled;
            set
            {
                _contactWindowIsDeleteButtonEnabled = value;
                OnPropertyChanged(nameof(ContactWindowIsDeleteButtonEnabled));
            }
        }
        public ObservableCollection<PersonalInfoControl> PersonalUserInfoItem { get { return _personalUserInfoItem; } set { _personalUserInfoItem = value; OnPropertyChanged(nameof(PersonalUserInfoItem)); } }
        public SearchPersonControl SearchSelectedItem
        {
            get { return _searchSelectedItem; }
            set
            {
                if (value != null && value != _searchSelectedItem)
                {
                    SearchWindowAddButtonIsEnabled = true;
                    _searchSelectedItem = value; ;
                }
                else
                {
                    SearchWindowAddButtonIsEnabled = false;
                }
            }
        }
        public ContactControl ContactWindowSelectedContact
        {
            get { return _contactWindowSelectedContact; }
            set
            {
                if (value != null && value != _contactWindowSelectedContact)
                {
                    ContactWindowIsDeleteButtonEnabled = true;
                    _contactWindowSelectedContact = value;
                    OnPropertyChanged(nameof( ContactWindowSelectedContact));
                }
                else
                {
                    ContactWindowIsDeleteButtonEnabled = false;
                }
            }
        }

        public ObservableCollection<SearchPersonControl> SearchWindowContactsList
        {
            get { return _searchWindowContactsList; }
            set { _searchWindowContactsList = value; OnPropertyChanged(nameof(SearchWindowContactsList)); }
        }
        public ObservableCollection<ContactControl> ContactWindowContactsList
        {
            get { return _contactWindowContactsList; }
            set { _contactWindowContactsList = value; OnPropertyChanged(nameof(ContactWindowContactsList)); }
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
        public ObservableCollection<PersonControl> MainWindowChatsList
        {
            get { return _mainWindowChatsListView; }
            set
            {
                _mainWindowChatsListView = value;
                OnPropertyChanged(nameof(MainWindowChatsList));
            }
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

        public string SearchWindowTextBoxText
        {
            get { return _searchWindowTextBoxText; }
            set { _searchWindowTextBoxText = value; OnPropertyChanged(nameof(SearchWindowTextBoxText)); OnTextChanged.Invoke(); }
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

        public string PersonalInfoFirstName { get { return _personalInfoFirstName; } set { if (value != null) _personalInfoFirstName = value; OnPropertyChanged(nameof(PersonalInfoFirstName)); } }
        public string PersonalInfoSecondName { get { return _personalInfoSecondName; } set { if (value != null) _personalInfoSecondName = value; OnPropertyChanged(nameof(PersonalInfoSecondName)); } }
        public string PersonalInfoEmail { get { return _personalInfoEmail; } set { if (value != null) _personalInfoEmail = value; OnPropertyChanged(nameof(PersonalInfoEmail)); } }
        public string PersonalInfoPassword { get { return _personalInfoPassword; } set { if (value != null) _personalInfoPassword = value; OnPropertyChanged(nameof(PersonalInfoPassword)); } }
        public string PersonalInfoLogin { get { return _personalInfoLogin; } set { if (value != null) _personalInfoLogin = value; OnPropertyChanged(nameof(PersonalInfoLogin)); } }


        #endregion


        #endregion

        #region Methods & Commands

        private void LoadChats()
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    MainWindowChatsList.Clear();
                    var res = Service.GetChats();
                    foreach (var item in res.Data)
                    {
                        MainWindowChatsList.Add(new PersonControl(item.Id, "A binary tree is made of nodes, where each node contains ", item.Name, DateTime.Now));
                    }
                });
            });
        }
        private void LoadContacts()
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    ContactWindowContactsList.Clear();
                    var res = Service.GetContacts();
                    foreach (var item in res.Data)
                    {
                        ContactWindowContactsList.Add(new ContactControl(item));
                    }
                });
            });
        }
        private void LoadMessages(int ChatId)
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    MainWindowMessageControlListView.Clear();
                    var r = Service.GetMessages(ChatId);
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
                        if(it.Id != User.Id)
                        SearchWindowContactsList.Add(new SearchPersonControl(it));
                    }
                }
                else
                {
                    SearchWindowContactsList.Clear();
                }
            }
        }
        private void ResetUser(User user, ServiceClient service)
        {
            User = user;
            Service = service;
            LoadChats();
            LoadContacts();
            SearchWindowContactsList = new ObservableCollection<SearchPersonControl>();

            PersonalInfoEmail = User.Email;
            PersonalInfoFirstName = User.FirstName;
            PersonalInfoSecondName = User.LastName;
            PersonalInfoPassword = User.Password;
            PersonalInfoLogin = User.Login;

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
        public ICommand buttonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    //ось тут буде виконуватись код на клік кнопки
                });
            }
        }
        public ICommand MainWindowAddNewContactClick 
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    foreach(var it in ContactWindowContactsList)
                    {
                        if (it.User.Id == SearchSelectedItem.User.Id)
                            return;
                    }

                    PersonControl contactToAdd = new PersonControl(SearchSelectedItem.User.Id, "A binary tree is made of nodes, where each node contains ", SearchSelectedItem.User.FirstName, DateTime.Now, null);

                    Service.AddContact(SearchSelectedItem.User.Id);
                        Service.CreatePrivateChat(SearchSelectedItem.User.Id);

                        LoadContacts();
                        LoadChats();
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
        public ICommand PersonalWindowSaveChangesButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    User newUserInfo = new User() { Id = User.Id, FirstName = PersonalInfoFirstName, LastName = PersonalInfoSecondName, Email = PersonalInfoEmail, Password = PersonalInfoPassword,
                        Login = PersonalInfoLogin, PhotoPath = "Not Done", Bio = PersonalInfoFirstName + " " + PersonalInfoSecondName,LastOnlineDate=DateTime.Now };

                    Service.EditUserInfo(newUserInfo);
                    ResetUser(newUserInfo, Service);
                });
            }
        }
        public ICommand ContactWindowDeleteButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    Service.DeleteContact(ContactWindowSelectedContact.User.Id);
                    foreach(var it in Service.GetChats().Data)
                    {

                    }

                    LoadContacts();
                    LoadChats();
                });
            }
        }
        #endregion


    }
}

