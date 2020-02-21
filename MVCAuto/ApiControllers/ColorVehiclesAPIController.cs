using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVCAuto.Library.Models;
using MVCAuto.Models;
using MVCAuto.Plugins;

namespace MVCAuto.ApiControllers
{
    public class ColorVehiclesAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ColorVehiclesAPI
        public IQueryable<ColorVehicle> GetColorVehicles()
        {
            return db.ColorVehicles;
        }

        [HttpGet]
        [Route("api/ColorVehiclesAPI/GetParamsPagerColorVehicles")]
        public Pager1 GetParamsPagerColorVehicles()
        {
            var colorvehicles = db.ColorVehicles.ToList<ColorVehicle>();
            int iTotalItems = colorvehicles.Count;
            int pagesize = 5;
            double dpagesize = (iTotalItems / pagesize);
            int iTotalPages = (int)Math.Ceiling(dpagesize);

            Pager1 pager = new Pager1(iTotalItems, iTotalPages, 1);

            return pager;
        }

        [HttpGet]
        [Route("api/ColorVehiclesAPI/GetPagerColorVehicles")]
        public IEnumerable<ColorVehicle> GetPagerColorVehicles(int page)
        {
            var colorvehicles = db.ColorVehicles.ToList<ColorVehicle>();
            int iTotalItems = colorvehicles.Count;

            var pager = new Pager(iTotalItems, page);

            return colorvehicles.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

        }



        // GET: api/ColorVehiclesAPI/5
        [ResponseType(typeof(ColorVehicle))]
        public IHttpActionResult GetColorVehicle(int id)
        {
            ColorVehicle colorVehicle = db.ColorVehicles.Find(id);
            if (colorVehicle == null)
            {
                return NotFound();
            }

            return Ok(colorVehicle);
        }

        // PUT: api/ColorVehiclesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColorVehicle(int id, ColorVehicle colorVehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colorVehicle.ColorId)
            {
                return BadRequest();
            }

            db.Entry(colorVehicle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorVehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ColorVehiclesAPI
        [ResponseType(typeof(ColorVehicle))]
        public IHttpActionResult PostColorVehicle(ColorVehicle colorVehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ColorVehicles.Add(colorVehicle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = colorVehicle.ColorId }, colorVehicle);
        }

        // DELETE: api/ColorVehiclesAPI/5
        [ResponseType(typeof(ColorVehicle))]
        public IHttpActionResult DeleteColorVehicle(int id)
        {
            ColorVehicle colorVehicle = db.ColorVehicles.Find(id);
            if (colorVehicle == null)
            {
                return NotFound();
            }

            db.ColorVehicles.Remove(colorVehicle);
            db.SaveChanges();

            return Ok(colorVehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorVehicleExists(int id)
        {
            return db.ColorVehicles.Count(e => e.ColorId == id) > 0;
        }
    }
}