using StepChat.StepChatUI.LoginRegistration.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StepChat.StepChatUI.LoginRegistration.Model
{
    class LoginRegistrationModel
    {
        LoginRegistrationViewModel LRVM = new LoginRegistrationViewModel();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
