using BusinessLogic;
using Prism.Commands;
using System;
using System.Windows;
using System.Windows.Input;
using Utils;

namespace Presentation.Windows
{

    public partial class AddTaxWindow : Window
    {
        public string Vin { get; set; }
        public string Amount { get; set; }
        public ICommand AddCommand { get; }
        private User User { get; }

        public AddTaxWindow()
        {
            InitializeComponent();
        }

        public AddTaxWindow(User user)
        {
            this.User = user;
            AddCommand = new DelegateCommand(Add);
        }

        private void Add()
        {
            double amount;
            if (!InputValidatorUtils.validateVIN(Vin))
            {
                ErrorMessage = "Моля, въведете коректен ВИН";
                return;
            }
            if (String.IsNullOrEmpty(Amount))
            {
                ErrorMessage = "Моля, въведете коректна сума";
                return;
            }
            try
            {
                amount = Double.Parse(Amount);
            }
            catch (FormatException)
            {
                ErrorMessage = "Моля въведете коректна сума";
                return;
            }

            Vehicle Vehicle = EntityManagerFactory.VehiclesManager.GetVehicleByVin(Vin);
            Vehicle.Tax += Double.Parse(Amount);
            EntityManagerFactory.VehiclesManager.Delete(Vehicle.Id);
            Vehicle = EntityManagerFactory.VehiclesManager.Create(Vehicle.Vin, Vehicle.RegistrationNumber, Vehicle.Manufacturer, Vehicle.Model, Vehicle.YearOfProduction, Vehicle.GetVehicleTypeAsString(),
                Vehicle.Description, Vehicle.Owner.Id, Vehicle.Tax);

            if (Vehicle == null)
            {
                ErrorMessage = "Проблем със добавянето на глоба. Моля опитайте пак";
            }
            MessageBox.Show("Добавянето на данък е успешно!");
        }
    }
}
