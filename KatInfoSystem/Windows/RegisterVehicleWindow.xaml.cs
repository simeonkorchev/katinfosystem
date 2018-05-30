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
using Utils;

namespace Presentation.Windows
{
    partial class RegisterVehicleWindow : Window
    {
        public string Manufacturer { private get; set; }
        public string Model { private get; set; }
        public int YearOfProduction { private get; set; }
        public string Vin{ private get; set; }
        public string RegistrationNumber{ private get; set; }
        public string Description{ private get; set; }
        public string FirstName{ private get; set; }
        public string MidName{ private get; set; }
        public string LastName{ private get; set; }
        public string Egn{ private get; set; }
        public string Address{ private get; set; }
        public string VehicleType { private get; set; }
        public double Tax { get; set; } = 0.0;

        public ICommand RegisterVehicleCommand { get; }

        internal RegisterVehicleWindow()
        {
            RegisterVehicleCommand = new DelegateCommand(RegisterVehicle);
        }

        private void RegisterVehicle()
        {

            if (!InputValidatorUtils.validateVIN(Vin))
            {
                ErrorMessage = "Вин-а трябва да бъде поне 10 символа";
                return;
            }
            if (!InputValidatorUtils.validateYear(YearOfProduction))
            {
                ErrorMessage = "Моля, въведете година след 1895";
                return;
            }

            if (!InputValidatorUtils.ValidatePersonDetails(FirstName, MidName, LastName, Egn, Address))
            {
                ErrorMessage = "Всички полета за собственик са задължителни";
                return;
            }
            Person Person = EntityManagerFactory.PersonsManager.GetPersonByEgn(Egn);
            if ( Person == null)
            {
                Person = EntityManagerFactory.PersonsManager.Add(Egn, FirstName, MidName, LastName, Address);
            }
            string SelectedType = ((ListBoxItem) VehicleTypeLB.SelectedValue).Content.ToString();
            EntityManagerFactory.VehiclesManager.Create(Vin, RegistrationNumber, Manufacturer, Model, YearOfProduction, SelectedType, Description, Person.Id, Tax);
            MessageBox.Show("Успешна регистрация!");
        }
    }
}
