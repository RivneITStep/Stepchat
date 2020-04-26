using LoginRegistration.Login_Registration.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoginRegistration.Login_Registration.Model
{
    class LoginRegistration_Model : INotifyPropertyChanged
    {
        LoginRegistration_ViewModel LRVM = new LoginRegistration_ViewModel();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
