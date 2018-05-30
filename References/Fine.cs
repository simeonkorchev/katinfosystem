using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fines
{
    public class Fine
    {
        private double dueAmount { get; set; }
        private String vehicleVIN { get; set; }
        private String debtorFirstName { get; set; }
        private String debtorMidName { get; set; }
        private String debtorLastName { get; set; }
        private String debtorEGN { get; set; }
        private FineResource resource { get; set; }
        private String employeeID { get; set; }

        public Fine(double dueAmount, string vehicleVIN, string debtorFirstName, string debtorMidName, string debtorLastName, string debtorEGN, FineResource resource, string employeeID)
        {
            this.dueAmount = dueAmount;
            this.vehicleVIN = vehicleVIN;
            this.debtorFirstName = debtorFirstName;
            this.debtorMidName = debtorMidName;
            this.debtorLastName = debtorLastName;
            this.debtorEGN = debtorEGN;
            this.resource = resource;
            this.employeeID = employeeID;
        }
    }
}
