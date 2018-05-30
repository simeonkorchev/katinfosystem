using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class FinesTextResolver : ITextResolver
    {
        public List<Fine> Fines { get; }
        public string ResultText { get; set; }

        public FinesTextResolver(List<Fine> fines)
        {
            Fines = fines;
        }

        public String Resolve()
        {
            if(Fines == null || Fines.Count() == 0)
            {
                return "Гражданинът няма никакви глоби за плащане.";
            }

            ResultText = "Гражданина има за плащане следните глоби:\n";
            double Amount = 0.0;
            foreach(Fine f in Fines)
            {
                ResultText += "Глоба с номер: " + f.Id + "\n";
                ResultText += "За автомобил: " + f.Vehicle.Model + " на стойност: " + f.DueAmount + "\n";
                Amount += f.DueAmount;
            }

            return ResultText += "Обща сума за плащане: " + Amount;
        }
    }
}
