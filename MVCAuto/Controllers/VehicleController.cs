using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public ActionResult Index(int? id)
        {
            var viewModel = new VehicleViews();
            viewModel.Vehicles = db.Vehicle.ToList();

            if (id != null)
            {
                ViewBag.ID = id.Value;
                Vehicle vehicle = db.Vehicle.Find(id);
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
            Vehicle vehicle = db.Vehicle.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Vin,Color,Price,OperDate,IntRowVer,RowVersion")] Vehicle vehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Vehicle.Add(vehicle);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(vehicle);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vin,Color,Price,OperDate,IntRowVer,RowVersion")] Vehicle SelVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicle.Add(SelVehicle);
                db.SaveChanges();
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
            Vehicle vehicle = db.Vehicle.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Vin,Color,Price,OperDate,IntRowVer,RowVersion")] Vehicle vehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehicle).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vehicle);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vin,Color,Price,OperDate,IntRowVer,RowVersion")] Vehicle SelVehicle)
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
            Vehicle vehicle = db.Vehicle.Find(id);
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
            Vehicle vehicle = db.Vehicle.Find(id);
            db.Vehicle.Remove(vehicle);
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
    }
}
