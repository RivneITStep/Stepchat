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
        private delegate void emptyDelegate();
        private event emptyDelegate OnTextChanged;
        private event emptyDelegate OnSelectionChanged;
        private string _searchWindowTextBoxText;
        private static ObservableCollection<SearchPersonControl> _searchWindowContactsList { get; set; }
        private PersonControl _mainWindowContactListListViewSelectedItem;
        private string _mainWindowEnterYourMessageTextBox;
        private ObservableCollection<MessageControl> _mainWindowMessageControlListView { get; set; }
        private ObservableCollection<PersonControl> _mainWindowContactListListView { get; set; }
        private SearchPersonControl _searchSelectedItem { get; set; }
        private ObservableCollection<PersonalInfoControl> _personalUserInfoItem { get; set; }
        private bool _searchWindowAddButtonIsEnabled { get; set; }
        private Visibility _personalUserInfoItemVisability { get; set; }

        private ObservableCollection<ContactControl> _contactWindowContactsList { get; set; }
        private ObservableCollection<PersonControl> _mainWindowChatsListView { get; set; }

        private ContactControl _contactWindowSelectedContact { get; set; }

        private bool _contactWindowIsDeleteButtonEnabled { get; set; }
        private string _personalInfoFirstName { get; set; }
        private string _personalInfoSecondName { get; set; }
        private string _personalInfoEmail { get; set; }
        private string _personalInfoPassword { get; set; }
        private string _personalInfoLogin { get; set; }
    }
}
