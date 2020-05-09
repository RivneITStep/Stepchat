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
using System.Linq;
using StepChat.StepChatUI.CustomUIElement.AttachControl;
using System.Collections.Generic;

namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    partial class MainWindowUIViewModel : BaseViewModel.BaseViewModelUI
    {
        private void ResetUser(User user, ServiceClient service)
        {
            User = user;
            Service = service;
            LoadPrivateChats();
            SearchWindowContactsList = new ObservableCollection<SearchPersonControl>();

        }
        private void LoadPrivateChats()
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke((Action)delegate
            {
                MainWindowContactListListView.Clear();
                var res = Service.GetChats();
                foreach (var item in res.Data)
                {
                    Message m = Service.GetMessages(item.Id).Data.LastOrDefault();
                    if (m != null)
                    {
                        MainWindowContactListListView.Add(new PersonControl(item.Id, m.Text, "NULL", m.SendDate));
                    }
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
                    List<AttachControl> attaches = new List<AttachControl>();
                    var res = Service.GetMessageAttachments(item.Id);
                    foreach (var item2 in res.Data)
                    {
                        AttachControl ac = new AttachControl(item2.FileName, item2.FileType, item2.Id);
                        ac.Button_MouseClick_Handler += AttachmentHandlerButtonClick;
                        attaches.Add(ac);
                    }
                    if (item.SenderId == User.Id)
                    {
                        MainWindowMessageControlListView.Add(new MessageControl(item, HorizontalAlignment.Right, attaches));
                    }
                    else
                    {
                        MainWindowMessageControlListView.Add(new MessageControl(item, HorizontalAlignment.Left, attaches));
                    }
                }
            });
            });
        }
        private void AttachmentHandlerButtonClick(object sender, RoutedEventArgs e,int id)
        {
            ApiStream.ApiStream.GetFile(Service,id);
        }
        private void OnSearchWindowTextBoxTextChanged()
        {
            if (SearchWindowTextBoxText.Length != 0 && SearchWindowTextBoxText != null && SearchWindowTextBoxText != "")
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
    }
}

