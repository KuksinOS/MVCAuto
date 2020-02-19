namespace MVCAuto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_FK_dboVehicles_dboColorVehicles_ColorID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ColorID", c => c.Int(nullable: true));
            //вставим данные заглушки в базу данных для удовлетворения ограничений внешнего ключа, и это будет сделано. 
            Sql("INSERT INTO dbo.ColorVehicles (Name) VALUES ('Temp')");
            //При выполнении Department Course Department метода он вставит строки в таблицу и будет связывать существующие строки с новыми строками. Seed Если вы еще не добавили какие-либо курсы в пользовательский интерфейс, вам больше не потребуется "Temp" или значение по умолчанию для Course.DepartmentID столбца. Чтобы позволить кому-либо добавить курсы с помощью приложения, необходимо также обновить Seed код метода, чтобы убедиться, что все Course строки (а не только те, которые были вставлены в предыдущих запусках Seed метода) имеют Допустимые DepartmentID значения, прежде чем удалить значение по умолчанию из столбца и удалить временный отдел.
            // Create  a department for course to point to.
            Sql("UPDATE dbo.Vehicles SET ColorID = CV.ColorID FROM dbo.ColorVehicles CV WHERE Name ='Temp' ");
            //  default value for FK points to department created above.

            CreateIndex("dbo.Vehicles", "ColorID");
            AddForeignKey("dbo.Vehicles", "ColorID", "dbo.ColorVehicles", "ColorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "ColorID", "dbo.ColorVehicles");
            DropIndex("dbo.Vehicles", new[] { "ColorID" });
            DropColumn("dbo.Vehicles", "ColorID");
        }
    }
}
