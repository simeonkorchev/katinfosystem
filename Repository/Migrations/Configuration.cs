namespace Repository.Migrations
{
    using Persistence;
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.SqlServer;

    internal sealed class Configuration : DbMigrationsConfiguration<KatSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ForceAddingOfProviderAsDependency();
        }

        static Type ForceAddingOfProviderAsDependency() => typeof(SqlProviderServices);
    }
}
