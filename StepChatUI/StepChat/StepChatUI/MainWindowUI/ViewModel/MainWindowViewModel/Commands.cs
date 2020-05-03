using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StepChat.StepChatUI.Commands;
using StepChat.StepChatUI.CustomUIElement.PersonControl;
namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    partial class MainWindowUIViewModel
    {
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
                    Task.Run(() =>
                    {
                        Service.SendMessage(MainWindowContactListListViewSelectedItem.ChatId, MainWindowEnterYourMessageTextBox);
                        MainWindowEnterYourMessageTextBox = "";
                    });
                });
            }
        }
        public ICommand MainWindowAddNewContactClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    PersonControl contactToAdd = new PersonControl(SearchSelectedItem.User.Id, "A binary tree is made of nodes, where each node contains ", SearchSelectedItem.User.FirstName, DateTime.Now, null);
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
