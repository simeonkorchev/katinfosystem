using BusinessLogic;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Utils;

namespace Presentation.Pages
{
    public partial class RegisterPage : Page
    {
        public string Username { private get; set; }
        string Password => PasswordBox.Password;
        public ICommand RegisterCommand { get; }

        internal RegisterPage()
        {
            RegisterCommand = new DelegateCommand(() =>
            {
                if (!InputValidatorUtils.validateUsernameAndPassword(Username.Trim(), Password))
                {
                    ErrorMessage = "Полетата са задължителни и с дължина от поне 5 символа!";
                    return;
                }

                try
                {
                    User user = EntityManagerFactory.UsersManager.Create(Username, Password);
                    NavigateToPage(new UserPage(user));
                } catch (Exception)
                {
                    ErrorMessage = "Вече съществува потребител с такова име.";
                    return;
                }
            });
        }
    }
}
