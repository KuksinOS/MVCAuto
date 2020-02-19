using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MVCAuto.Library.Models;

namespace MVCAuto.Library.DataAccess
{

    public class MVCAutoContext : DbContext
    {
        public MVCAutoContext() : base("DefaultConnection")
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ColorVehicle> ColorVehicles { get; set; }
    }


}
