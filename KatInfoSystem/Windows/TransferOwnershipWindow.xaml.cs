using BusinessLogic;
using Prism.Commands;
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
            Vehicle vehicle = EntityManagerFactory.VehiclesManager.GetVehicleByVin(Vin);

            if (currentOwner == null || newOwner == null )
            {
                ErrorMessage = "Моля, въведете коректни ЕГН-та";
                return;
            }
            if(vehicle == null)
            {
                ErrorMessage = "Моля, въведете коректен ВИН";
                return;
            }

            EntityManagerFactory.PersonsManager.TransferOwnership(vehicle.Id, currentOwner.Id, newOwner.Id);
        }
    }
}
