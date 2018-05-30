namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fines",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        dueAmount = c.Double(nullable: false),
                        vehicleVin = c.String(nullable: false),
                        fineResource = c.Int(nullable: false),
                        debtor_Id = c.Guid(nullable: false),
                        finedVehicle_Id = c.Guid(),
                        user_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.debtor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.finedVehicle_Id)
                .ForeignKey("dbo.Users", t => t.user_Id, cascadeDelete: true)
                .Index(t => t.debtor_Id)
                .Index(t => t.finedVehicle_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        egn = c.String(nullable: false, maxLength: 10),
                        firstName = c.String(nullable: false),
                        midName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.egn, unique: true);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        vin = c.String(nullable: false, maxLength: 10),
                        registrationNumber = c.String(nullable: false, maxLength: 8),
                        yearOfProduction = c.Int(nullable: false),
                        manufacturer = c.String(nullable: false),
                        model = c.String(nullable: false),
                        vehicleType = c.Int(nullable: false),
                        tax = c.Double(nullable: false),
                        description = c.String(),
                        PersonEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.PersonEntity_Id)
                .Index(t => t.vin, unique: true)
                .Index(t => t.registrationNumber, unique: true)
                .Index(t => t.PersonEntity_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 25),
                        password = c.Binary(nullable: false, maxLength: 8000, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fines", "user_Id", "dbo.Users");
            DropForeignKey("dbo.Fines", "finedVehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Fines", "debtor_Id", "dbo.Persons");
            DropForeignKey("dbo.Vehicles", "PersonEntity_Id", "dbo.Persons");
            DropIndex("dbo.Users", new[] { "username" });
            DropIndex("dbo.Vehicles", new[] { "PersonEntity_Id" });
            DropIndex("dbo.Vehicles", new[] { "registrationNumber" });
            DropIndex("dbo.Vehicles", new[] { "vin" });
            DropIndex("dbo.Persons", new[] { "egn" });
            DropIndex("dbo.Fines", new[] { "user_Id" });
            DropIndex("dbo.Fines", new[] { "finedVehicle_Id" });
            DropIndex("dbo.Fines", new[] { "debtor_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Persons");
            DropTable("dbo.Fines");
        }
    }
}
