
namespace Presentation.Windows
{
    using BusinessLogic;
    using Prism.Commands;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using Utils;

    public partial class FinesInformationWindow : Window
    {
        public ICommand PrintCommand { get; }
        public ICommand PayCommand { get; }
        public ICommand CheckFinesCommand { get; }
        public string Egn { get; set; }
        public string FinesText { get; set; }
        public ObservableCollection<string> FinesList { get; set; }

        public FinesInformationWindow() : base()
        {
            CheckFinesCommand = new DelegateCommand(CheckFines);
            PayCommand = new DelegateCommand(Pay);
            PrintCommand = new DelegateCommand(Print);
            FinesList = new ObservableCollection<string>();
        }

        private void Print()
        {
            PrinterUtils.Print(FinesText);
        }

        private void CheckFines()
        {
            if (!InputValidatorUtils.validateVIN(Egn))
            {
                ErrorMessage = "ЕГН-то трябва да бъде поне 10 символа";
                return;
            }

            Person person = EntityManagerFactory.PersonsManager.GetPersonByEgn(Egn);
            List<Fine> fines = person.Fines.ToList();
            AddFinesToListView(fines);
            FinesTextResolver FinesTextResolver = new FinesTextResolver(fines);
            FinesText = FinesTextResolver.Resolve();
            this.OnPropertyChanged(nameof(FinesText));
        }

        private void AddFinesToListView(List<Fine> fines)
        {
            foreach(Fine Fine in fines)
            {
                FinesList.Add(Fine.Id.ToString());
            }
        }

        private void Pay()
        {
            Person Person = EntityManagerFactory.PersonsManager.GetPersonByEgn(Egn);
            List<Fine> Fines = Person.Fines.ToList();

            if(FinesLV.SelectedItems.Count > 0)
            {
                string FineId = FinesLV.SelectedItems[0].ToString();
                Fine FineToPay = ResolveFineForId(Fines, FineId);

                if(FineToPay == null)
                {
                    ErrorMessage = "Желаната глоба за плащане не е намерена";
                    return;
                }

                EntityManagerFactory.FinesManager.Delete(FineToPay.Id);
                MessageBox.Show("Плащането е успешно!");
            }
            
        }

        private Fine ResolveFineForId(List<Fine> Fines, string FineId)
        {
            foreach(Fine Fine in Fines)
            {
                if(FineId.Equals(Fine.Id.ToString()))
                {
                    return Fine;
                }
            }

            return null;
        }
    }
}
