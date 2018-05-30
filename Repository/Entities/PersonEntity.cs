namespace Persistence.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Persons")]
    public class PersonEntity : Entity
    {
        [StringLength(10)]
        [Required, Index(IsUnique = true)]
        public String egn { get; set; }
        [Required]
        public String firstName { get; set; }
        [Required]
        public String midName { get; set; }
        [Required]
        public String lastName { get; set; }
        [Required]
        public String address { get; set; }
        public ICollection<FineEntity> fines { get; set; }
        public ICollection<VehicleEntity> vehicles { get; set; }
    }
}
