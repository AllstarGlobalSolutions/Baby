using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baby.Models;

namespace Baby.Controllers
{
	public class AdvertisersController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Advertisers
		public ActionResult Index()
		{
			return View( db.Advertisers.Include( a => a.Addresses ).Include( a => a.Emails ).Include( a => a.Phones ).ToList() );
		}

		// GET: Advertisers/Details/5
		public ActionResult Details( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}

			Advertiser advertiser = db.Advertisers.Find( id );

			if ( advertiser == null )
			{
				return HttpNotFound();
			}

			return View( advertiser );
		}

		// GET: Advertisers/Create
		public ActionResult Create()
		{
			ViewBag.CountryId = new SelectList( db.Countries.OrderBy( c => c.Name ), "CountryId", "Name" );
			return View();
		}

		// POST: Advertisers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "AdvertiserId,Name" )] Advertiser advertiser )
		{
			if ( ModelState.IsValid )
			{
				advertiser.AdvertiserId = Guid.NewGuid();
				db.Advertisers.Add( advertiser );

				advertiser.Emails.Add( new Email
				{
					EmailId = Guid.NewGuid(),
					Type = "Work",
					Address = Request[ "Email" ],
				} );

				advertiser.Phones.Add( new Phone
				{
					PhoneId = Guid.NewGuid(),
					Type = "Work",
					CountryCode = Request[ "CountryCode" ],
					Number = Request[ "Phone" ],
				} );

				advertiser.Addresses.Add( new Address
				{
					AddressId = Guid.NewGuid(),
					Type = "Mailing",
					Street = Request[ "StreetAddress" ],
					City = Request[ "City" ],
					StateOrProvince = Request[ "StateOrProvince" ],
					PostalCode = Request[ "PostalCode" ],
					Country = db.Countries.Find( Guid.Parse( Request[ "CountryId" ] ) ),
				} );

				db.SaveChanges();
				return RedirectToAction( "Index" );
			}

			ViewBag.CountryId = new SelectList( db.Countries.OrderBy( c => c.Name ), "CountryId", "Name" );
			return View( advertiser );
		}

		// GET: Advertisers/Edit/5
		public ActionResult Edit( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Advertiser advertiser = db.Advertisers.FirstOrDefault();//.Include( a => a.Addresses ).Include( a => a.Emails ).Include( a => a.Phones ).SingleOrDefault( a => a.AdvertiserId == id );
			if ( advertiser == null )
			{
				return HttpNotFound();
			}

			ViewBag.CountryId = new SelectList( db.Countries.OrderBy( c => c.Name ), "CountryId", "Name" );
			return View( advertiser );
		}

		// POST: Advertisers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "AdvertiserId,Name" )] Advertiser advertiser )
		{
			if ( ModelState.IsValid )
			{
				db.Entry( advertiser ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
			ViewBag.CountryId = new SelectList( db.Countries.OrderBy( c => c.Name ), "CountryId", "Name" );
			return View( advertiser );
		}

		// GET: Advertisers/Delete/5
		public ActionResult Delete( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Advertiser advertiser = db.Advertisers.Find( id );
			if ( advertiser == null )
			{
				return HttpNotFound();
			}
			return View( advertiser );
		}

		// POST: Advertisers/Delete/5
		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( Guid id )
		{
			Advertiser advertiser = db.Advertisers.Find( id );
			db.Advertisers.Remove( advertiser );
			db.SaveChanges();
			return RedirectToAction( "Index" );
		}

		// GET: Advertisers/Advertisemetns/5
		public ActionResult Advertisements( Guid advertiserId )
		{
			return View( db.Advertisements.Where( a => a.Advertiser.AdvertiserId == advertiserId ).ToList() );
		}

		protected override void Dispose( bool disposing )
		{
			if ( disposing )
			{
				db.Dispose();
			}
			base.Dispose( disposing );
		}
	}
}
