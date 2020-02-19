namespace MVCAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ColorVehicle_Model_Class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ColorVehicles",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ColorId);
            
            DropColumn("dbo.Vehicles", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Color", c => c.Int(nullable: false));
            DropTable("dbo.ColorVehicles");
        }
    }
}
