

namespace Persistence.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Fines")]
    public class FineEntity : Entity
    {
        [Required]
        public double dueAmount { get; set; }
        [Required]
        public String vehicleVin { get; set; }
        [Required]
        public UserEntity user { get; set; }
        [Required]
        public PersonEntity debtor { get; set; }
        public VehicleEntity finedVehicle { get; set; }
        public FineResource fineResource { get; set; }
        
        
    }
}
