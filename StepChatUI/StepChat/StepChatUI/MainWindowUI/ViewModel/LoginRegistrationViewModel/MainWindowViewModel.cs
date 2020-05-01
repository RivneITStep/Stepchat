using StepChat.ServiceReference1;
using StepChat.StepChatUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StepChat.StepChatUI.MainWindowUI.ViewModel
{
    partial class MainWindowUIViewModel
    {
    private string _login;
    private string _registrationWindow_FirstNameTextBox;
    private string _registrationWindow_LastNameTextBox;
    private string _registrationWindow_EmailTextBox;
    private string _registrationWindow_LoginTextBox;
    private string _loginWindow_ErrorTextBox;
    private string _registrationWindow_ErrorTextBox;
    private Visibility _progressBarVisibility;
    private Visibility _loginWindowVisibility;
    private Visibility _registrationWindowVisibility;
    public string LoginText
    {
        get
        {
            return _login;
        }
        set
        {
            this._login = value;
            OnPropertyChanged(nameof(LoginText));
        }
    }
    public Visibility ProgressBarVisibility
    {
        get
        {
            return _progressBarVisibility;
        }
        set
        {
            _progressBarVisibility = value;
            OnPropertyChanged(nameof(ProgressBarVisibility));
        }
    }
    public Visibility LoginWindowVisibility
    {
        get
        {
            return _loginWindowVisibility;
        }
        set
        {
            _loginWindowVisibility = value;
            OnPropertyChanged(nameof(LoginWindowVisibility));
        }
    }
    public Visibility RegistrationWindowVisibility
    {
        get
        {
            return _registrationWindowVisibility;
        }
        set
        {
            _registrationWindowVisibility = value;
            OnPropertyChanged(nameof(RegistrationWindowVisibility));
        }
    }
    public string LoginWindow_ErrorTextBox
    {
        get => _loginWindow_ErrorTextBox;
        set
        {
            _loginWindow_ErrorTextBox = value;
            OnPropertyChanged(nameof(LoginWindow_ErrorTextBox));
        }
    }
    public string RegistrationWindow_ErrorTextBox
    {
        get => _registrationWindow_ErrorTextBox;
        set
        {
            _registrationWindow_ErrorTextBox = value;
            OnPropertyChanged(nameof(RegistrationWindow_ErrorTextBox));
        }
    }
    public string RegistrationWindow_FirstNameTextBox
    {
        get => _registrationWindow_FirstNameTextBox;
        set
        {
            _registrationWindow_FirstNameTextBox = value;
            OnPropertyChanged(nameof(RegistrationWindow_FirstNameTextBox));
        }
    }
    public string RegistrationWindow_LastNameTextBox
    {
        get => _registrationWindow_LastNameTextBox;
        set
        {
            _registrationWindow_LastNameTextBox = value;
            OnPropertyChanged(nameof(RegistrationWindow_LastNameTextBox));
        }
    }
    public string RegistrationWindow_EmailTextBox
    {
        get => _registrationWindow_EmailTextBox;
        set
        {
            _registrationWindow_EmailTextBox = value;
            OnPropertyChanged(nameof(RegistrationWindow_EmailTextBox));
        }
    }
    public string RegistrationWindow_LoginTextBox
    {
        get => _registrationWindow_LoginTextBox;
        set
        {
            _registrationWindow_LoginTextBox = value;
            OnPropertyChanged(nameof(RegistrationWindow_LoginTextBox));
        }
    }

    //######################################################################
    public ICommand LoginButtonClick
    {
        get
        {
            return new DelegateClickCommand((obj) =>
            {
                Thread t = new Thread(new ThreadStart(() =>
                {
                    SetProgressBarVisibility(Visibility.Visible);
                    try
                    {
                        ServiceClient proxy = new ServiceClient();
                        var res = proxy.Login(LoginText, (obj as PasswordBox).Password);
                        if (!res.IsSuccess)
                        {
                            LoginWindow_ErrorTextBox = res.Error.ToString();

                        }
                        else
                        {
                            SetRengerState(RendererWindow.MainWindow);
                            Service = proxy;
                            User = res.Data;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        SetProgressBarVisibility(Visibility.Hidden);
                    }
                }));
                t.SetApartmentState(ApartmentState.STA);
                t.IsBackground = true;
                t.Start();
            });
        }
    }
    public ICommand RegistrationButtonClick
    {
        get
        {
            return new DelegateClickCommand((obj) =>
            {
                Task.Factory.StartNew(() =>
                {
                    SetProgressBarVisibility(Visibility.Visible);
                    try
                    {
                        using (ServiceClient proxy = new ServiceClient())
                        {
                            var res = proxy.Register(ConfigurateUserDTO(obj as PasswordBox));
                            if (!res.IsSuccess)
                            {
                                RegistrationWindow_ErrorTextBox = res.Error.ToString();
                            }
                            else
                            {
                                LoginWindowVisibility = Visibility.Visible;
                                RegistrationWindowVisibility = Visibility.Hidden;
                                RegistrationWindow_ErrorTextBox = "";
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        SetProgressBarVisibility(Visibility.Hidden);
                    }
                });
            });
        }
    }
    public ICommand CreateNewAccountButtonClick
    {
        get
        {
            return new DelegateClickCommand((obj) =>
            {

                ProgressBarVisibility = Visibility.Hidden;
            });
        }
    }
    public ICommand RegistrationWindow_BackToLoginButton
    {
        get
        {
            return new DelegateClickCommand((obj) =>
            {
                LoginWindowVisibility = Visibility.Visible;
                RegistrationWindowVisibility = Visibility.Hidden;
            });
        }
    }
    public ICommand LoginWindow_CreateNewAccountButton
    {
        get
        {
            return new DelegateClickCommand((obj) =>
            {
                LoginWindowVisibility = Visibility.Hidden;
                RegistrationWindowVisibility = Visibility.Visible;
            });
        }
    }

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