using MVCAuto.Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAuto.Library.DataAccess
{
    public class VehicleData : IDisposable
    {
        private MVCAutoContext db = new MVCAutoContext();

        public List<Vehicle> GetVehicles(int colorId, int? SelectedColorVehicle)
        {
            return db.Vehicles
            .Where(v => !SelectedColorVehicle.HasValue || v.ColorId == colorId)
            .OrderBy(v => v.Vin)
            .Include(c => c.ColorVehicle).ToList();
        }

        public Vehicle FindVehicle(int? id)
        {
            return db.Vehicles.Find(id);
        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            db.Vehicles.Add(vehicle);
            await db.SaveChangesAsync();
        }

        public void EditVehicle(Vehicle vehicle)
        {
            db.Entry(vehicle).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
