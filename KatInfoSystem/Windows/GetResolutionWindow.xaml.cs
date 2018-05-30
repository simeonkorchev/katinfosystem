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
using System.Windows.Shapes;

namespace Presentation.Windows
{

    public partial class GetResolutionWindow : Window
    {
        public string Token => SecretKeyPB.Password;
        public ICommand VerifySecretKeyCommand { get; }
        private TokenScope Scope { get; }
        private User User { get; }

        public GetResolutionWindow()
        {
            InitializeComponent();
            VerifySecretKeyCommand = new DelegateCommand(VerifySecretKey);
        }

        public GetResolutionWindow(User User, TokenScope Scope)
        {
            this.User = User;
            this.Scope = Scope;
            InitializeComponent();
            VerifySecretKeyCommand = new DelegateCommand(VerifySecretKey);
        }

        private void VerifySecretKey()
        {
            if(!new AuthorizationTokenVerifier().VerifyToken(Scope, Token))
            {
                ErrorMessage = "Моля, въведете правилен ключ";
                return;
            }

            User.Scopes.Add(Scope);
            this.Close();
        }
    }
}
