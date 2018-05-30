namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "password", c => c.Binary(nullable: false, maxLength: 32, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "password", c => c.Binary(nullable: false, maxLength: 8000, fixedLength: true));
        }
    }
}
