using System;
using System.Collections.Generic;
using System.Data;
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
	[Authorize]
	public class DeviceInfoesController : ApiController
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: api/DeviceInfoes
		public IQueryable<DeviceInfo> GetDeviceInfos()
		{
			return db.DeviceInfos;
		}

		// GET: api/DeviceInfoes/5
		[ResponseType( typeof( DeviceInfo ) )]
		public async Task<IHttpActionResult> GetDeviceInfo( string id )
		{
			DeviceInfo deviceInfo = await db.DeviceInfos.FindAsync( id );
			if ( deviceInfo == null )
			{
				return NotFound();
			}

			return Ok( deviceInfo );
		}

		// PUT: api/DeviceInfoes/5
		[ResponseType( typeof( void ) )]
		public async Task<IHttpActionResult> PutDeviceInfo( string id, DeviceInfo deviceInfo )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest( ModelState );
			}

			if ( id != deviceInfo.UserId )
			{
				return BadRequest();
			}

			db.Entry( deviceInfo ).State = EntityState.Modified;

			try
			{
				await db.SaveChangesAsync();
			}
			catch ( DbUpdateConcurrencyException )
			{
				if ( !DeviceInfoExists( id ) )
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

		// POST: api/DeviceInfoes
		[ResponseType( typeof( DeviceInfo ) )]
		public async Task<IHttpActionResult> PostDeviceInfo( DeviceInfo deviceInfo )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest( ModelState );
			}

			db.DeviceInfos.Add( deviceInfo );

			try
			{
				await db.SaveChangesAsync();
			}
			catch ( DbUpdateException )
			{
				if ( DeviceInfoExists( deviceInfo.UserId ) )
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtRoute( "DefaultApi", new { id = deviceInfo.UserId }, deviceInfo );
		}

		// DELETE: api/DeviceInfoes/5
		[ResponseType( typeof( DeviceInfo ) )]
		public async Task<IHttpActionResult> DeleteDeviceInfo( string id )
		{
			DeviceInfo deviceInfo = await db.DeviceInfos.FindAsync( id );
			if ( deviceInfo == null )
			{
				return NotFound();
			}

			db.DeviceInfos.Remove( deviceInfo );
			await db.SaveChangesAsync();

			return Ok( deviceInfo );
		}

		protected override void Dispose( bool disposing )
		{
			if ( disposing )
			{
				db.Dispose();
			}
			base.Dispose( disposing );
		}

		private bool DeviceInfoExists( string id )
		{
			return db.DeviceInfos.Count( e => e.UserId == id ) > 0;
		}
	}
}