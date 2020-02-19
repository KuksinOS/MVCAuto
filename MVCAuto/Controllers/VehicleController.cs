using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCAuto.Models;
using MVCAuto.ModelView;

namespace MVCAuto.Controllers
{
    public class VehicleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        

        // GET: Vehicle
        public ActionResult Index(int? id, int? SelectedColorVehicle)
        {
            var viewModel = new VehicleViews();
            var colorVehicleQuery = from d in db.ColorVehicles
                                    orderby d.Name
                                    select d;
            ViewBag.ColorVehicles = new SelectList(colorVehicleQuery, "ColorId", "Name", SelectedColorVehicle);
            int colorId = SelectedColorVehicle.GetValueOrDefault();


            //viewModel.Vehicles = db.Vehicles.ToList();
            //viewModel.Vehicles = db.Vehicles.OrderBy(q => q.Vin).ToList();
            viewModel.Vehicles = db.Vehicles
            .Where(v => !SelectedColorVehicle.HasValue || v.ColorId == colorId)
            .OrderBy(v => v.Vin)
            .Include(c => c.ColorVehicle).ToList();

            if (id != null)
            {
                ViewBag.ID = id.Value;
                Vehicle vehicle = db.Vehicles.Find(id);
                if (vehicle != null)
                {
                    viewModel.SelVehicle = vehicle;
                }
            }

            return View(viewModel);
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(db.ColorVehicles, "ColorId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Vin,ColorId,Price,OperDate,IntRowVer")] Vehicle SelVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(SelVehicle);
                await db.SaveChangesAsync();
                // return View("Index", SelVehicle);
                return RedirectToAction("Index");
            }
            //return View("Index", SelVehicle);
            return RedirectToAction("Index");
        }




        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ColorId = new SelectList(db.ColorVehicles, "ColorId", "Name");
            PopulateColorVehiclesDropDownList(vehicle.ColorId);
            return View(vehicle);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vin,ColorId,Price,OperDate,IntRowVer,RowVersion")] Vehicle SelVehicle)
        {
            if (SelVehicle.ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                db.Entry(SelVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PopulateColorVehiclesDropDownList(object selectedColorVehicle = null)
        {
            var colorVehicleQuery = from d in db.ColorVehicles
                                    orderby d.Name
                                    select d;
            ViewBag.ColorId = new SelectList(colorVehicleQuery, "ColorId", "Name", selectedColorVehicle);
        }
    }
}
