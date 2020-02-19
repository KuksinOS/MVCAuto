using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCAuto.Models
{
    public class ColorVehicleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ColorVehicle
        public ActionResult Index()
        {
            return View(db.ColorVehicles.ToList());
        }

        // GET: ColorVehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorVehicle colorVehicle = db.ColorVehicles.Find(id);
            if (colorVehicle == null)
            {
                return HttpNotFound();
            }
            return View(colorVehicle);
        }

        // GET: ColorVehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorVehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColorId,Name")] ColorVehicle colorVehicle)
        {
            if (ModelState.IsValid)
            {
                db.ColorVehicles.Add(colorVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colorVehicle);
        }

        // GET: ColorVehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorVehicle colorVehicle = db.ColorVehicles.Find(id);
            if (colorVehicle == null)
            {
                return HttpNotFound();
            }
            return View(colorVehicle);
        }

        // POST: ColorVehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColorId,Name")] ColorVehicle colorVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colorVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colorVehicle);
        }

        // GET: ColorVehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorVehicle colorVehicle = db.ColorVehicles.Find(id);
            if (colorVehicle == null)
            {
                return HttpNotFound();
            }
            return View(colorVehicle);
        }

        // POST: ColorVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ColorVehicle colorVehicle = db.ColorVehicles.Find(id);
            db.ColorVehicles.Remove(colorVehicle);
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
