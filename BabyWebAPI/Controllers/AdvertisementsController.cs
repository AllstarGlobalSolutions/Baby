namespace BabyWebAPI.Controllers
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Threading.Tasks;
	using System.Web.Http;
	using System.Web.Http.Description;
	using Baby.Models;

	public class AdvertisementsController : ApiController
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: api/Advertisements
		public IQueryable<Advertisement> GetAdvertisements()
		{
			return db.Advertisements;
		}

		// GET: api/Advertisements/5
		[ResponseType( typeof( Advertisement ) )]
		public async Task<IHttpActionResult> GetAdvertisement( Guid id )
		{
			Advertisement advertisement = await db.Advertisements.FindAsync( id );
			if ( advertisement == null )
			{
				return NotFound();
			}

			return Ok( advertisement );
		}

		/*
		 * This class is used to send  response to the mobile app.  If there are any changes needed, you need to change in BabyApp as well.
		 */
		class AdResponse
		{
			public Guid? ImageId;
			public string ClickUrl;
		}

		// GET: api/Advertisements/Next/5
		[ResponseType( typeof( AdResponse ) )]
		[Route( "Next/{id}" )]
		public async Task<IHttpActionResult> GetNextAdvertisement( string id )
		{
			List<DisplayAdvertisement> displayAds = await db.DisplayAdvertisements.Where( da => da.User.Id == id ).ToListAsync();

			// get the first ad
			// TODO: change to other ads -- need to store some kind of order of ads displayed
			Advertisement ad = db.Advertisements
					.Where( a => !displayAds.Select( da => da.Advertisement.AdvertisementId ).Contains( a.AdvertisementId ) ).FirstOrDefault();

			// if we found a ad that hasn't been displayed
			if ( ad != default( Advertisement ) )
			{
				AdResponse adResponse = new AdResponse
				{
					ImageId = ad.FileId,
					ClickUrl = ad.ClickUrl
				};

				DisplayAdvertisement da = new DisplayAdvertisement
				{
					DisplayAdvertisementId = Guid.NewGuid(),
					DisplayDttmUTC = DateTime.UtcNow,
					Advertisement = ad,
					User = db.Users.Find( id )
				};

				db.DisplayAdvertisements.Add( da );

				if ( db.SaveChanges() == 0 )
				{
					return InternalServerError();
				}

				return Ok( adResponse );
			}
			else
			{
				AdResponse adResponse = new AdResponse
				{
					ImageId = null
				};
				return Ok( adResponse );
			}
		}

		// PUT: api/Advertisements/5
		[ResponseType( typeof( void ) )]
		public async Task<IHttpActionResult> PutAdvertisement( Guid id, Advertisement advertisement )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest( ModelState );
			}

			if ( id != advertisement.AdvertisementId )
			{
				return BadRequest();
			}

			db.Entry( advertisement ).State = EntityState.Modified;

			try
			{
				await db.SaveChangesAsync();
			}
			catch ( DbUpdateConcurrencyException )
			{
				if ( !AdvertisementExists( id ) )
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return StatusCode( HttpStatusCode.NoContent );
		}

		// POST: api/Advertisements
		[ResponseType( typeof( Advertisement ) )]
		public async Task<IHttpActionResult> PostAdvertisement( Advertisement advertisement )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest( ModelState );
			}

			db.Advertisements.Add( advertisement );

			try
			{
				await db.SaveChangesAsync();
			}
			catch ( DbUpdateException )
			{
				if ( AdvertisementExists( advertisement.AdvertisementId ) )
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtRoute( "DefaultApi", new { id = advertisement.AdvertisementId }, advertisement );
		}

		// DELETE: api/Advertisements/5
		[ResponseType( typeof( Advertisement ) )]
		public async Task<IHttpActionResult> DeleteAdvertisement( Guid id )
		{
			Advertisement advertisement = await db.Advertisements.FindAsync( id );
			if ( advertisement == null )
			{
				return NotFound();
			}

			db.Advertisements.Remove( advertisement );
			await db.SaveChangesAsync();

			return Ok( advertisement );
		}

		protected override void Dispose( bool disposing )
		{
			if ( disposing )
			{
				db.Dispose();
			}
			base.Dispose( disposing );
		}

		private bool AdvertisementExists( Guid id )
		{
			return db.Advertisements.Count( e => e.AdvertisementId == id ) > 0;
		}
	}
}