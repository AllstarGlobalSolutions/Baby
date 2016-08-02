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
			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Name" );
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
				db.SaveChanges();

				var email = new Email
				{
					EmailId = Guid.NewGuid(),
					Type = "Work",
					Address = Request[ "Email" ],
					AdvertiserId = advertiser.AdvertiserId
				};
				db.Emails.Add( email );
				db.SaveChanges();

				var phone = new Phone
				{
					PhoneId = Guid.NewGuid(),
					Type = "Work",
					Number = Request[ "Phone" ],
					AdvertiserId = advertiser.AdvertiserId
				};
				db.Phones.Add( phone );
				db.SaveChanges();

				var address = new Address
				{
					AddressId = Guid.NewGuid(),
					Type = "Mailing",
					Street1 = Request[ "StreetAddress1" ],
					Street2 = Request[ "StreetAddress2" ],
					District = Request[ "District" ],
					City = Request[ "City" ],
					StateOrProvince = Request[ "StateOrProvince" ],
					PostalCode = Request[ "PostalCode" ],
					CountryId = Guid.Parse( Request[ "CountryId" ] ),
					AdvertiserId = advertiser.AdvertiserId
				};
				db.Addresses.Add( address );
				db.SaveChanges();

				return RedirectToAction( "Index" );
			}

			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Name" );
			return View( advertiser );
		}

		// GET: Advertisers/Edit/5
		public ActionResult Edit( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Advertiser advertiser = db.Advertisers.Include( a => a.Addresses ).Include( a => a.Emails ).Include( a => a.Phones ).SingleOrDefault( a => a.AdvertiserId == id );
			if ( advertiser == null )
			{
				return HttpNotFound();
			}

			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Name" );
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
			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Name" );
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
			return View( db.Advertisements.Where( a => a.AdvertiserId == advertiserId ).ToList() );
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
