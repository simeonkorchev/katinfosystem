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
        public User User { get; }

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
            double amount=0.0;

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
            if (Vehicle == null)
            {
                ErrorMessage = "МПС с този ВИН не е намерен";
                return;
            }

            Vehicle = EntityManagerFactory.VehiclesManager.AddTax(Vin, Double.Parse(Amount));

            if (Vehicle == null)
            {
                ErrorMessage = "Проблем със добавянето на глоба. Моля опитайте пак";
            }
            MessageBox.Show("Добавянето на данък е успешно!");
        }
    }
}
