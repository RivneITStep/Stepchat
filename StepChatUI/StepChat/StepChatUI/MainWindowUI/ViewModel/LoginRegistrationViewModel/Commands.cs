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
        public ICommand LoginButtonClick
        {
            get
            {
                return new DelegateClickCommand((obj) =>
                {
                    Thread t = new Thread(new ThreadStart(() =>
                    {
                        SetProgressBarVisibility(Visibility.Visible);
                        ServiceClient proxy = new ServiceClient();
                        var res = proxy.Login(LoginText, (obj as PasswordBox).Password);
                        if (!res.IsSuccess)
                        {
                            LoginWindow_ErrorTextBox = res.Error.ToString();

                        }
                        else
                        {
                            SetRengerState(RendererWindow.MainWindow);
                            ResetUser(res.Data, proxy);
                        }
                        try
                        {
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
    }
}
