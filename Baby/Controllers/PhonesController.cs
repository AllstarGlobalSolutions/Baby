using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baby.Models;
using Baby.Controllers.Base;

namespace Baby.Controllers
{
	public class PhonesController : BaseController
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Phones
		public ActionResult Index()
		{
			var phones = db.Phones.Include( p => p.Advertiser ).Include( p => p.Organization ).Include( p => p.User );
			return View( phones.ToList() );
		}

		// GET: Phones/Details/5
		public ActionResult Details( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Phone phone = db.Phones.Find( id );
			if ( phone == null )
			{
				return HttpNotFound();
			}
			return View( phone );
		}

		// GET: Phones/Create
		public ActionResult Create()
		{
			ViewBag.AdvertiserId = new SelectList( db.Advertisers, "AdvertiserId", "Name" );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name" );
			ViewBag.UserId = new SelectList( db.Users, "Id", "Surname" );
			return View();
		}

		// POST: Phones/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "PhoneId,Type,CountryCode,Number,AdvertiserId,OrganizationId,UserId" )] Phone phone )
		{
			if ( ModelState.IsValid )
			{
				phone.PhoneId = Guid.NewGuid();
				db.Phones.Add( phone );
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}

			ViewBag.AdvertiserId = new SelectList( db.Advertisers, "AdvertiserId", "Name", phone.AdvertiserId );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name", phone.OrganizationId );
			ViewBag.UserId = new SelectList( db.Users, "Id", "Surname", phone.UserId );
			return View( phone );
		}

		// GET: Phones/Edit/5
		public ActionResult Edit( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Phone phone = db.Phones.Find( id );
			if ( phone == null )
			{
				return HttpNotFound();
			}
			ViewBag.AdvertiserId = new SelectList( db.Advertisers, "AdvertiserId", "Name", phone.AdvertiserId );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name", phone.OrganizationId );
			ViewBag.UserId = new SelectList( db.Users, "Id", "Surname", phone.UserId );
			return View( phone );
		}

		// POST: Phones/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "PhoneId,Type,CountryCode,Number,AdvertiserId,OrganizationId,UserId" )] Phone phone )
		{
			if ( ModelState.IsValid )
			{
				db.Entry( phone ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
			ViewBag.AdvertiserId = new SelectList( db.Advertisers, "AdvertiserId", "Name", phone.AdvertiserId );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name", phone.OrganizationId );
			ViewBag.UserId = new SelectList( db.Users, "Id", "Surname", phone.UserId );
			return View( phone );
		}

		// GET: Phones/Delete/5
		public ActionResult Delete( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Phone phone = db.Phones.Find( id );
			if ( phone == null )
			{
				return HttpNotFound();
			}
			return View( phone );
		}

		// POST: Phones/Delete/5
		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( Guid id )
		{
			Phone phone = db.Phones.Find( id );
			db.Phones.Remove( phone );
			db.SaveChanges();
			return RedirectToAction( "Index" );
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
