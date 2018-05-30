using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    [Table("Vehicles")]
    public class VehicleEntity : Entity
    {
        [StringLength(10)]
        [Required, Index(IsUnique = true)]
        public string vin { get; set; }
        [StringLength(8)]
        [Required, Index(IsUnique = true)]
        public string registrationNumber { get; set; }
        [Required]
        public int yearOfProduction { get; set; }
        [Required]
        public string manufacturer { get; set; }
        [Required]
        public string model { get; set; }
        [Required]
        public VehicleType vehicleType { get; set; }
        [Required]
        public PersonEntity owner { get; set; }
        public double tax { get; set; }
        public string description { get; set; }
    }
}