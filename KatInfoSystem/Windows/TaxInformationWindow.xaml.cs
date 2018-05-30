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
            if(TaxesText != null)
            {
                PrinterUtils.Print(TaxesText);
            }
        }

        private void PayTaxes()
        {
            Vehicle Vehicle = EntityManagerFactory.VehiclesManager.GetVehicleByVin(Vin);
            if (Vehicle == null)
            {
                ErrorMessage = "МПС с такъв ВИН не е намерено";
                return;
            }
            if(Vehicle.Tax <=0)
            {
                ErrorMessage = "Няма дължим данък";
                return;
            }

            EntityManagerFactory.VehiclesManager.PayTax(Vin, Vehicle.Tax);
            MessageBox.Show("Плащането е извършено успешно!");
        }

        private void CheckTaxes()
        {
            if (!InputValidatorUtils.validateVIN(Vin))
            {
                ErrorMessage = "Моля, въвeдете правилен 10 цифрен ВИН!";
                return;
            }

            Vehicle Vehicle = EntityManagerFactory.VehiclesManager.GetVehicleByVin(Vin);
            if(Vehicle == null)
            {
                ErrorMessage = "Не е намерен автомобил по това ЕГН.";
                return;
            }

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