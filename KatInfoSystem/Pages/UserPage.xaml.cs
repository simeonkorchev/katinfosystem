using BusinessLogic;
using Presentation.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.Pages
{

    public partial class UserPage : Page
    {
        public User user { get; }
        public ICommand OpenVehicleRegistrationWindowCommand { get; }
        public ICommand OpenFinesInformationWindowCommand { get; }
        public ICommand OpenTaxInformationWindowCommand { get; }
        public ICommand OpenTransferOwnershipWindowCommand { get; }
        public ICommand OpenAddFinesWindowCommand { get; }
        public ICommand OpenAddTaxWindowCommand { get; }

        public UserPage()
        { }

        public UserPage(User user)
        {
            this.user = user;
            OpenVehicleRegistrationWindowCommand = new DelegateCommand(OpenVehicleRegistrationWindow);
            OpenFinesInformationWindowCommand = new DelegateCommand(OpenFinesInformationWindow);
            OpenTaxInformationWindowCommand = new DelegateCommand(OpenTaxInformationWindow);
            OpenAddFinesWindowCommand = new DelegateCommand(OpenAddFinesWindow);
            OpenAddTaxWindowCommand = new DelegateCommand(OpenAddTaxWindow);
            OpenTransferOwnershipWindowCommand = new DelegateCommand(TransferOwnership);
        }

        private void TransferOwnership()
        {
            if (user.Scopes.Contains(TokenScope.TRANSFER))
            {
                TransferOwnershipWindow window = new TransferOwnershipWindow();
                window.ShowDialog();
                return;
            }
            GetResolutionWindow AuthWindow = new GetResolutionWindow(user, TokenScope.TRANSFER);
            AuthWindow.ShowDialog();
        }

        private void OpenAddTaxWindow()
        {
            if (this.user.Scopes.Contains(TokenScope.TAX))
            {
                AddTaxWindow window = new AddTaxWindow();
                window.ShowDialog();
                return;
            }

            GetResolutionWindow AuthWindow = new GetResolutionWindow(user, TokenScope.TAX);
            AuthWindow.ShowDialog();
        }
        private void OpenAddFinesWindow()
        {
            if (user.Scopes.Contains(TokenScope.FINE))
            {
                AddFinesWindow window = new AddFinesWindow(user);
                window.ShowDialog();
                return;
            }

            GetResolutionWindow AuthWindow = new GetResolutionWindow(user, TokenScope.FINE);
            AuthWindow.ShowDialog();
        }

        private void OpenTaxInformationWindow()
        {
            if (user.Scopes.Contains(TokenScope.TAX))
            {
                TaxInformationWindow window = new TaxInformationWindow();
                window.ShowDialog();
                return;
            }

            GetResolutionWindow AuthWindow = new GetResolutionWindow(user, TokenScope.TAX);
            AuthWindow.ShowDialog();
        }

        private void OpenFinesInformationWindow()
        {
            if (user.Scopes.Contains(TokenScope.FINE))
            { 
                FinesInformationWindow window = new FinesInformationWindow();
                window.ShowDialog();
                return;
            }

            GetResolutionWindow AuthWindow = new GetResolutionWindow(user, TokenScope.FINE);
            AuthWindow.ShowDialog();
        }

        private void OpenVehicleRegistrationWindow()
        {
            if (user.Scopes.Contains(TokenScope.VEHICLE_REGISTRATION))
            { 
                RegisterVehicleWindow window = new RegisterVehicleWindow();
                window.ShowDialog();
                return;
            }

            GetResolutionWindow AuthWindow = new GetResolutionWindow(user, TokenScope.VEHICLE_REGISTRATION);
            AuthWindow.ShowDialog();
        }
    }
}
