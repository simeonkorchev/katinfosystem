using BusinessLogic;
using Prism.Commands;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.Pages
{
    public partial class LoginPage : Page
    {
        public string Username { private get; set; }
        string Password => PasswordBox.Password;
        public ICommand LoginCommand { get; }

        public LoginPage()
        {
            LoginCommand = new DelegateCommand(() =>
            {
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    ErrorMessage = "Моля, въведете потребителско име и парола!";
                    return;
                }

                User user = EntityManagerFactory.UsersManager.Login(Username.Trim(), Password);
                if (user == null)
                {
                    ErrorMessage = "Невалидно потр. име или парола";
                    return;
                }

                NavigateToPage(new UserPage(user));

            });
        }
    }
}
