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
using System.Windows.Input;
using Utils;

namespace Presentation.Windows
{
    public partial class TaxInformationWindow : Window
    {
        public ICommand PrintCommand { get; }
        public ICommand PayCommand { get; }
        public ICommand CheckTaxesCommand { get; }
        public string Vin { get; set; }
        public string TaxesText { get; set; }

        public TaxInformationWindow()
        {
            CheckTaxesCommand = new DelegateCommand(CheckTaxes);
            PayCommand = new DelegateCommand(PayTaxes);
            PrintCommand = new DelegateCommand(Print);
        }

        private void Print()
        {
            
        }

        private void PayTaxes()
        {
            Vehicle Vehicle = EntityManagerFactory.VehiclesManager.GetVehicleByVin(Vin);
            EntityManagerFactory.VehiclesManager.Delete(Vehicle.Id);
            EntityManagerFactory.VehiclesManager.Create(Vehicle.Vin, Vehicle.RegistrationNumber, Vehicle.Manufacturer,Vehicle.Model, Vehicle.YearOfProduction, Vehicle.GetVehicleTypeAsString(), Vehicle.Description, Vehicle.Owner.Id, 0);
        }

        private void CheckTaxes()
        {
            if (!InputValidatorUtils.validateVIN(Vin))
            {
                ErrorMessage = "Моля, въвeдете правилен 10 цифрен ВИН!";
                return;
            }

            Vehicle Vehicle = EntityManagerFactory.VehiclesManager.GetVehicleByVin(Vin);
            TaxesTextResolver TaxesTextResolver = new TaxesTextResolver(Vehicle.Tax);
            TaxesText = TaxesTextResolver.Resolve();
            this.OnPropertyChanged(nameof(TaxesText));
        }

        internal class TaxesResolvedEventArgs
        {
            internal string ResultText { get; set; }
        }
    }
}