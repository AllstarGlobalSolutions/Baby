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
	[RoutePrefix( "api/Needs" )]
	public class NeedsController : ApiController
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: api/Needs
		public IQueryable<Need> GetNeeds()
		{
			return db.Needs;
		}

		// GET: api/Needs/5
		[ResponseType( typeof( Need ) )]
		public async Task<IHttpActionResult> GetNeed( Guid id )
		{
			Need need = await db.Needs.FindAsync( id );
			if ( need == null )
			{
				return NotFound();
			}

			return Ok( need );
		}

		class NeedResponse
		{
			public Guid NeedId { get; set; }
			public string Caption { get; set; }
			public string Story { get; set; }
			public Guid? FileId { get; set; }
			public string OrgName { get; set; }
			public string NeedType { get; set; }
			public string Tags { get; set; }
			public decimal? AmountNeeded { get; set; }
		}

		// GET: api/Needs/Next/5
		[ResponseType( typeof( NeedResponse ) )]
		[Route( "Next/{id}" )]
//		[HttpGet]
		public async Task<IHttpActionResult> GetNextNeed( string id )
		{
			List<DisplayNeed> displayNeeds = await db.DisplayNeeds.Where( dn => dn.User.Id == id ).ToListAsync();
			Need need = db.Needs.Include( n => n.Country ).Include( n => n.Region ).Include( n => n.Organization ).Include( n => n.NeedType ).Where( n => !displayNeeds.Select( dn => dn.Need.NeedId ).Contains( n.NeedId ) ).FirstOrDefault();

			// if we found a need that hasn't been displayed
			if ( need != default( Need ) )
			{
				NeedResponse needResponse = new NeedResponse
				{
					NeedId = need.NeedId,
					Caption = need.Caption,
					Story = need.Story,
					FileId = need.File.FileId,
					OrgName = need.Organization.Name,
					NeedType = need.NeedType.Description,
					Tags = need.Tags,
					AmountNeeded = need.AmountNeeded
				};
				return Ok( needResponse );
			}
			else
			{
				NeedResponse needResponse = new NeedResponse
				{
					Caption = "No Needs Available"
				};
				return Ok( needResponse );
			}
		}

		// PUT: api/Needs/5
		[ResponseType( typeof( void ) )]
		public async Task<IHttpActionResult> PutNeed( Guid id, Need need )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest( ModelState );
			}

			if ( id != need.NeedId )
			{
				return BadRequest();
			}

			db.Entry( need ).State = EntityState.Modified;

			try
			{
				await db.SaveChangesAsync();
			}
			catch ( DbUpdateConcurrencyException )
			{
				if ( !NeedExists( id ) )
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

		// POST: api/Needs
		[ResponseType( typeof( Need ) )]
		public async Task<IHttpActionResult> PostNeed( Need need )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest( ModelState );
			}

			db.Needs.Add( need );

			try
			{
				await db.SaveChangesAsync();
			}
			catch ( DbUpdateException )
			{
				if ( NeedExists( need.NeedId ) )
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtRoute( "DefaultApi", new { id = need.NeedId }, need );
		}

		// DELETE: api/Needs/5
		[ResponseType( typeof( Need ) )]
		public async Task<IHttpActionResult> DeleteNeed( Guid id )
		{
			Need need = await db.Needs.FindAsync( id );
			if ( need == null )
			{
				return NotFound();
			}

			db.Needs.Remove( need );
			await db.SaveChangesAsync();

			return Ok( need );
		}

		protected override void Dispose( bool disposing )
		{
			if ( disposing )
			{
				db.Dispose();
			}
			base.Dispose( disposing );
		}

		private bool NeedExists( Guid id )
		{
			return db.Needs.Count( e => e.NeedId == id ) > 0;
		}
	}
}