using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Baby.Models;

namespace BabyWebAPI.Controllers
{
    public class AdvertisementsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Advertisements
        public IQueryable<Advertisement> GetAdvertisements()
        {
            return db.Advertisements;
        }

        // GET: api/Advertisements/5
        [ResponseType(typeof(Advertisement))]
        public async Task<IHttpActionResult> GetAdvertisement(Guid id)
        {
            Advertisement advertisement = await db.Advertisements.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return Ok(advertisement);
        }

        // PUT: api/Advertisements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdvertisement(Guid id, Advertisement advertisement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != advertisement.AdvertisementId)
            {
                return BadRequest();
            }

            db.Entry(advertisement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisementExists(id))
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

        // POST: api/Advertisements
        [ResponseType(typeof(Advertisement))]
        public async Task<IHttpActionResult> PostAdvertisement(Advertisement advertisement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Advertisements.Add(advertisement);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdvertisementExists(advertisement.AdvertisementId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = advertisement.AdvertisementId }, advertisement);
        }

        // DELETE: api/Advertisements/5
        [ResponseType(typeof(Advertisement))]
        public async Task<IHttpActionResult> DeleteAdvertisement(Guid id)
        {
            Advertisement advertisement = await db.Advertisements.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }

            db.Advertisements.Remove(advertisement);
            await db.SaveChangesAsync();

            return Ok(advertisement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdvertisementExists(Guid id)
        {
            return db.Advertisements.Count(e => e.AdvertisementId == id) > 0;
        }
    }
}