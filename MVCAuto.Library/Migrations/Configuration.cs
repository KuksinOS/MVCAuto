namespace MVCAuto.Library.Migrations
{
    using FizzWare.NBuilder;
    using MVCAuto.Library.DataAccess;
    using MVCAuto.Library.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    public sealed class Configuration : DbMigrationsConfiguration<MVCAuto.Library.DataAccess.MVCAutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(MVCAuto.Library.DataAccess.MVCAutoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            ColorVehicleData dataColor = new ColorVehicleData();
            var colorsVehicle = dataColor.GetColorVehiclesOrderByName().ToList();
            var listColorId = (from d in colorsVehicle
                                    select d.ColorId).ToList();


            // Generate vehicles
            var vinGenerator = new RandomGenerator();
            var priceGenerator = new RandomGenerator();
            var daysGenerator = new RandomGenerator();
            var itemCountGenerator = new RandomGenerator();
            var colorIdGenerator = new RandomGenerator();


            var vehicles = Builder<Vehicle>.CreateListOfSize(1000)
                .All()
                    .With(v => v.Vin = vinGenerator.NextString(17,17))
                    .With(v => v.Price = priceGenerator.Next(50, 500))
                    .With(v => v.OperDate = DateTime.Now.AddDays(-daysGenerator.Next(1, 100)))
                    .With(v => v.IntRowVer = itemCountGenerator.Next(1, 10))
                    //.With(v => v. = Pick<ColorVehicle>.RandomItemFrom(colorsVehicle))
                    .With(v => v.ColorId = Pick<int>.RandomItemFrom(listColorId))
                    .Build();

            context.Vehicles.AddOrUpdate(v => v.ID, vehicles.ToArray());
        }
    }
}
