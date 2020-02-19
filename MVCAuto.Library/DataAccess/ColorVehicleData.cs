using MVCAuto.Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAuto.Library.DataAccess
{
    public class ColorVehicleData:IDisposable
    {
        private MVCAutoContext db = new MVCAutoContext();
        public List<ColorVehicle> GetColorVehicles()
        {
            return db.ColorVehicles.ToList();
        }

        public IEnumerable<ColorVehicle> GetColorVehiclesOrderByName()
        {
            //return db.ColorVehicles.ToList();
            var colorVehicleQuery = from d in db.ColorVehicles
                                    orderby d.Name
                                    select d;
            return colorVehicleQuery;
        }

        public ColorVehicle FindColorVehicle(int? id)
        {
            return db.ColorVehicles.Find(id);
        }

        public void AddColorVehicle(ColorVehicle colorVehicle)
        {
            db.ColorVehicles.Add(colorVehicle);
            db.SaveChanges();
        }

        public void EditColorVehicle(ColorVehicle colorVehicle)
        {
            db.Entry(colorVehicle).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteColorVehicle(ColorVehicle colorVehicle)
        {
            db.ColorVehicles.Remove(colorVehicle);
            db.SaveChanges();
        }

        public void Dispose()
        {
                db.Dispose();
        }
    }
}
