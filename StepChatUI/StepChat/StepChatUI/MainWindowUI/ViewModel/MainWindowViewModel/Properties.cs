using System.Windows;
using System.Collections.ObjectModel;
using StepChat.StepChatUI.CustomUIElement.PersonControl;
using StepChat.StepChatUI.CustomUIElement.MessageControl;
using StepChat.StepChatUI.CustomUIElement.PersonalInfoControl;
using StepChat.StepChatUI.CustomUIElement.SearchPersonControl;
using StepChat.StepChatUI.CustomUIElement.ContactControl;

namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    partial class MainWindowUIViewModel
    {
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
        public SearchPersonControl SearchSelectedItem
        {
            get { return _searchSelectedItem; }
            set
            {
                if (value != null && value != _searchSelectedItem)
                {
                    SearchWindowAddButtonIsEnabled = true;
                    _searchSelectedItem = value; OnSelectionChanged.Invoke();
                }
                else
                {
                    OnSelectionChanged.Invoke();
                    SearchWindowAddButtonIsEnabled = false;
                }
            }
        }
        public ObservableCollection<SearchPersonControl> SearchWindowContactsList
        {
            get => _searchWindowContactsList;
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
                if(_mainWindowContactListListViewSelectedItem!=null)
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
        public string SearchWindowTextBoxText
        {
            get { return _searchWindowTextBoxText; }
            set { _searchWindowTextBoxText = value; OnPropertyChanged(nameof(SearchWindowTextBoxText)); OnTextChanged.Invoke(); }
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
        public ContactControl ContactWindowSelectedContact
        {
            get { return _contactWindowSelectedContact; }
            set
            {
                if (value != null && value != _contactWindowSelectedContact)
                {
                    ContactWindowIsDeleteButtonEnabled = true;
                    _contactWindowSelectedContact = value;
                    OnPropertyChanged(nameof(ContactWindowSelectedContact));
                }
                else
                {
                    ContactWindowIsDeleteButtonEnabled = false;
                }
            }
        }

        public ObservableCollection<ContactControl> ContactWindowContactsList
        {
            get { return _contactWindowContactsList; }
            set { _contactWindowContactsList = value; OnPropertyChanged(nameof(ContactWindowContactsList)); }
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



        public string PersonalInfoFirstName { get { return _personalInfoFirstName; } set { if (value != null) _personalInfoFirstName = value; OnPropertyChanged(nameof(PersonalInfoFirstName)); } }
        public string PersonalInfoSecondName { get { return _personalInfoSecondName; } set { if (value != null) _personalInfoSecondName = value; OnPropertyChanged(nameof(PersonalInfoSecondName)); } }
        public string PersonalInfoEmail { get { return _personalInfoEmail; } set { if (value != null) _personalInfoEmail = value; OnPropertyChanged(nameof(PersonalInfoEmail)); } }
        public string PersonalInfoPassword { get { return _personalInfoPassword; } set { if (value != null) _personalInfoPassword = value; OnPropertyChanged(nameof(PersonalInfoPassword)); } }
        public string PersonalInfoLogin { get { return _personalInfoLogin; } set { if (value != null) _personalInfoLogin = value; OnPropertyChanged(nameof(PersonalInfoLogin)); } }
    }
}
