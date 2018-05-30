using BusinessLogic;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;
namespace Presentation.Windows
{
    public partial class TransferOwnershipWindow : Window
    {
        public ICommand TransferOwnershipCommand { get; }
        public string CurrentOwnerEgn { get; set; }
        public string NewOwnerEgn { get; set; }
        public string Vin { get; set; }
        public TransferOwnershipWindow()
        {
            TransferOwnershipCommand = new DelegateCommand(TransferOwnership);
        }

        private void TransferOwnership()
        {
            ErrorMessage = null;
     
            if (CurrentOwnerEgn == null || NewOwnerEgn == null)
            {
                ErrorMessage = "Моля, въведете стойност и за двете ЕГН-та.";
                return;
            }
            if (Vin == null)
            {
                ErrorMessage = "Моля, въведете стойност за ВИН";
            }

            Person currentOwner = EntityManagerFactory.PersonsManager.GetPersonByEgn(CurrentOwnerEgn);
            Person newOwner = EntityManagerFactory.PersonsManager.GetPersonByEgn(NewOwnerEgn);
            if(currentOwner == null)
            {
                ErrorMessage = "Не е намерен гражданин с ЕГН: " + CurrentOwnerEgn;
                return;
            }

            if(newOwner == null)
            {
                ErrorMessage = "Не е намерен гражданин с ЕГН: " + NewOwnerEgn;
                return;
            }

            Vehicle vehicle = EntityManagerFactory.VehiclesManager.GetVehicleByVin(Vin);

            if(vehicle == null) 
            {
                ErrorMessage = "Не е намерена информация за МПС с ВИН: " + Vin;
                return;
            }

            if (!CurrentOwnerPossessTheVehicle(currentOwner, vehicle.Id))
            {
                ErrorMessage = "Гражданинът с ЕГН: " + CurrentOwnerEgn + " не притежава такова превозно средство";
                return;
            }

            EntityManagerFactory.PersonsManager.TransferOwnership(vehicle.Id, currentOwner.Id, newOwner.Id);
        }

        private bool CurrentOwnerPossessTheVehicle(Person currentOwner, Guid id)
        {
            foreach(Vehicle Vehicle in currentOwner.Vehicles)
            {
                if (Vehicle.Id.Equals(id)) return true;
            }

            return false;
        }
    }
}
