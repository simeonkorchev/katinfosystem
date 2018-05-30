namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "PersonEntity_Id", "dbo.Persons");
            DropIndex("dbo.Vehicles", new[] { "PersonEntity_Id" });
            RenameColumn(table: "dbo.Vehicles", name: "PersonEntity_Id", newName: "owner_Id");
            AlterColumn("dbo.Vehicles", "owner_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Vehicles", "owner_Id");
            AddForeignKey("dbo.Vehicles", "owner_Id", "dbo.Persons", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "owner_Id", "dbo.Persons");
            DropIndex("dbo.Vehicles", new[] { "owner_Id" });
            AlterColumn("dbo.Vehicles", "owner_Id", c => c.Guid());
            RenameColumn(table: "dbo.Vehicles", name: "owner_Id", newName: "PersonEntity_Id");
            CreateIndex("dbo.Vehicles", "PersonEntity_Id");
            AddForeignKey("dbo.Vehicles", "PersonEntity_Id", "dbo.Persons", "Id");
        }
    }
}
