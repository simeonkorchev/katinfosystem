using Persistence.Entities;
using System;

namespace BusinessLogic
{
    public class Fine
    {
        public Guid Id { get; }
        public double DueAmount { get; }
        public String VehicleVin { get; }
        public FineResource FineResource { get; }
        public Vehicle Vehicle;
        public Person Debtor;

        public Fine(FineEntity Fine)
        {
            Id = Fine.Id;
            DueAmount = Fine.dueAmount;
            VehicleVin = Fine.vehicleVin;
            FineResource = Fine.fineResource;
            Vehicle = new Vehicle(Fine.finedVehicle);
            Debtor = new Person(Fine.debtor);
        }
    }
}
