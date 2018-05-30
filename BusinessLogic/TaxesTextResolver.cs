using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TaxesTextResolver : ITextResolver
    {
        public double TaxAmount { get; }
        public string ResultText { get; set; }

        public TaxesTextResolver(double Amount)
        {
            TaxAmount = Amount;
        }

        public TaxesTextResolver()
        {
        }

        public string Resolve()
        {
            if(TaxAmount <= 0)
            {
                ResultText = "Гражданинът няма данък за плащане";
                return ResultText;
            }

            ResultText = "Гражданинът има да плаща данък в размер на: " + TaxAmount + " лв.";
            return ResultText;
        }
    }
}
