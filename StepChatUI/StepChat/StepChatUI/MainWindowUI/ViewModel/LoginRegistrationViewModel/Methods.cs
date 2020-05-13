using System;
using System.Windows;
using System.Windows.Controls;
using StepChat.ServiceReference1;
namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    partial class MainWindowUIViewModel
    {
    private User ConfigurateUserDTO(PasswordBox password)
    {
        User user = null;
        using (ServiceClient proxy = new ServiceClient())
        {
            user = new User()
            {
                Email = RegistrationWindow_EmailTextBox,
                Login = RegistrationWindow_LoginTextBox,
                FirstName = RegistrationWindow_FirstNameTextBox,
                LastName = RegistrationWindow_LastNameTextBox,
                Password = password.Password,
                LastOnlineDate = DateTime.Now
            };
        }
        return user;
    }
    private void SetProgressBarVisibility(Visibility visibility)
    {
        ProgressBarVisibility = visibility;
    }
}
}