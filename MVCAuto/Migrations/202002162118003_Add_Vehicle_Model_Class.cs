namespace MVCAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Vehicle_Model_Class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vin = c.String(nullable: false, maxLength: 17),
                        Color = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        OperDate = c.DateTime(nullable: false),
                        IntRowVer = c.Long(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
