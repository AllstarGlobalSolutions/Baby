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
    public class NeedTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/NeedTypes
        public IQueryable<NeedType> GetNeedTypes()
        {
            return db.NeedTypes;
        }

        // GET: api/NeedTypes/5
        [ResponseType(typeof(NeedType))]
        public async Task<IHttpActionResult> GetNeedType(Guid id)
        {
            NeedType needType = await db.NeedTypes.FindAsync(id);
            if (needType == null)
            {
                return NotFound();
            }

            return Ok(needType);
        }

        // PUT: api/NeedTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNeedType(Guid id, NeedType needType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != needType.NeedTypeId)
            {
                return BadRequest();
            }

            db.Entry(needType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeedTypeExists(id))
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

        // POST: api/NeedTypes
        [ResponseType(typeof(NeedType))]
        public async Task<IHttpActionResult> PostNeedType(NeedType needType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NeedTypes.Add(needType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NeedTypeExists(needType.NeedTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = needType.NeedTypeId }, needType);
        }

        // DELETE: api/NeedTypes/5
        [ResponseType(typeof(NeedType))]
        public async Task<IHttpActionResult> DeleteNeedType(Guid id)
        {
            NeedType needType = await db.NeedTypes.FindAsync(id);
            if (needType == null)
            {
                return NotFound();
            }

            db.NeedTypes.Remove(needType);
            await db.SaveChangesAsync();

            return Ok(needType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NeedTypeExists(Guid id)
        {
            return db.NeedTypes.Count(e => e.NeedTypeId == id) > 0;
        }
    }
}