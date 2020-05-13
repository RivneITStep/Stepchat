using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using StepChat.ServiceReference1;
using StepChat.StepChatUI.ApiStream;
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
                    if (MainWindowContactListListViewSelectedItem == null||MainWindowEnterYourMessageTextBox==null|| MainWindowEnterYourMessageTextBox=="")
                    {
                        return;
                    }
                    Task.Run(() =>
                    {
                        var res = Service.SendMessage(MainWindowContactListListViewSelectedItem.ChatId, MainWindowEnterYourMessageTextBox);
                        foreach (var item in Attacments)
                        {
                            ApiStream.ApiStream.AttachFile(Service, res.Data.Id, item);
                        }
                        MainWindowEnterYourMessageTextBox = "";
                        Attacments.Clear();
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
                    foreach (var it in ContactWindowContactsList)
                    {
                        if (it.User.Id == SearchSelectedItem.User.Id)
                            return;
                    }

                    PersonControl contactToAdd = new PersonControl(SearchSelectedItem.User.Id, "A binary tree is made of nodes, where each node contains ", SearchSelectedItem.User.FirstName, DateTime.Now, null);

                    Service.AddContact(SearchSelectedItem.User.Id);
                    Service.CreatePrivateChat(SearchSelectedItem.User.Id);

                    LoadContacts();
                    LoadPrivateChats();
                });
            }
        }
        public ICommand MainWindowAttachFileButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == true)
                    {
                        Attacments = openFileDialog.FileNames.ToList();
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



        public ICommand PersonalWindowSaveChangesButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    User newUserInfo = new User()
                    {
                        Id = User.Id,
                        FirstName = PersonalInfoFirstName,
                        LastName = PersonalInfoSecondName,
                        Email = PersonalInfoEmail,
                        Password = PersonalInfoPassword,
                        Login = PersonalInfoLogin,
                        PhotoPath = "Not Done",
                        Bio = PersonalInfoFirstName + " " + PersonalInfoSecondName,
                        LastOnlineDate = DateTime.Now
                    };

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


                    LoadContacts();
                    LoadPrivateChats();
                });
            }
        }
    }
}
