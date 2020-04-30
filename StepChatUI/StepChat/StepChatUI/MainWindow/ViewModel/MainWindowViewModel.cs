using System;
using System.Collections.Generic;
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

namespace StepChat.StepChatUI.MainWindow.ViewModel
{
    class MainWindowViewModel : BaseViewModelUI
    {
        User user;
        public void ResetUser(object obj)
        {
            user = (obj as User);

        }
        private string _message;//приватне поле обов'язкове без нього буде рекурсія
        public string Message//пропертя до якої біндимось
        {
            get => _message;
            set
            {
                _message = value;//встановлення значення
                OnPropertyChanged(nameof(Message));//після встановлення значення обов'язково сповіщаємо нашій в'юшці що пропертя змінилась, типа перепиши її в себе
            }
        }
        private string _messageOut;//приватне поле обов'язкове без нього буде рекурсія
        public string MessageOut//пропертя до якої біндимось
        {
            get => _messageOut;
            set
            {
                _messageOut = value;//встановлення значення
                OnPropertyChanged(nameof(MessageOut));//після встановлення значення обов'язково сповіщаємо нашій в'юшці що пропертя змінилась, типа перепиши її в себе
            }
        }

        //У кнопки є пропертя Command забіндивши її на нашу пропертю ICommand можна відслідковувати кліки
        public ICommand MainWindow_SendMessageButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    //ось тут буде виконуватись код на клік кнопки
                    MessageBox.Show("Ти на кнопку нажал ☺");
                    MessageOut += Message + "\n";
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
