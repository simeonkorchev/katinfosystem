


namespace Persistence
{
    using Persistence.Entities;
    using System;
    using System.Data.Entity;

    public class KatSystemDbContext : DbContext
    {
        public KatSystemDbContext() : base("KatInfoSystem")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.Log = Console.Write;
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<VehicleEntity> Vehicles { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<FineEntity> Fines { get; set; }
    }
}
