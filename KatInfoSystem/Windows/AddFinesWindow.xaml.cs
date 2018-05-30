using BusinessLogic;
using Prism.Commands;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.Windows
{

    public partial class AddFinesWindow : Window
    {
        public string Vin { get; set; }
        public string Amount { get; set; } 
        public ICommand AddCommand { get; } 
        private User User { get; }

        public AddFinesWindow(User user)
        {
            this.User = user;
            AddCommand = new DelegateCommand(Add);
        }

        private void Add()
        {
            double amount;
            if (String.IsNullOrEmpty(Vin) || String.IsNullOrEmpty(Amount))
            {
                ErrorMessage = "Всички полета са задължителни. Моля въведете правилни данни";
                return;
            }

            try {
                amount = Double.Parse(Amount);
            } catch (FormatException)
            {
                ErrorMessage = "Моля, въведете коректна сума.";
                return;
            }

            if(amount <= 0)
            {
                ErrorMessage = "Посочената сума трябва да бъде по-голяма от 0";
                return;
            }

            Vehicle Vehicle = EntityManagerFactory.VehiclesManager.GetVehicleByVin(Vin);
            if(Vehicle == null)
            {
                ErrorMessage = "Моля, въведете правилен номер на автомобил";
                return;
            }

            string SelectedType = ((ListBoxItem)FineResourceLB.SelectedValue).Content.ToString();

            Fine Fine = EntityManagerFactory.FinesManager.Add(amount, Vin, User.Id, Vehicle.Owner.Id, Vehicle.Id, SelectedType);

            if(Fine == null)
            {
                ErrorMessage = "Възникна проблем с добавянето на глоба";
                return;
            }
            MessageBox.Show("Добавянето на глоба е успешно!");
        }
    }
}
