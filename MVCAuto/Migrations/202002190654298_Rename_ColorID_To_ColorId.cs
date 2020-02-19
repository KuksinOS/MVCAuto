namespace MVCAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_ColorID_To_ColorId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Vehicles", new[] { "ColorID" });
            CreateIndex("dbo.Vehicles", "ColorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vehicles", new[] { "ColorId" });
            CreateIndex("dbo.Vehicles", "ColorID");
        }
    }
}
