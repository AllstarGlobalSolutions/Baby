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
	public class DonationsController : BaseController
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Donations
		public ActionResult Index()
		{
			// db.Donations.Include( d => d.Currency ).Include( d => d.User ).Include( d => d.Need ).Include( d => d.Organiation );
			//return View( donations.ToList() );
			return View();
		}

		// GET: Donations/Details/5
		public ActionResult Details( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Donation donation = db.Donations.Find( id );
			if ( donation == null )
			{
				return HttpNotFound();
			}
			return View( donation );
		}

		// GET: Donations/Create
		public ActionResult Create()
		{
			ViewBag.CurrencyId = new SelectList( db.Currencies, "CurrencyId", "Code" );
			ViewBag.DonorId = new SelectList( db.Donors, "DonorId", "Surname" );
			ViewBag.NeedId = new SelectList( db.Needs, "NeedId", "Caption" );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name" );
			return View();
		}

		// POST: Donations/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "DonationId,DonorId,OrganizationId,NeedId,Date,CurrencyId,Amount,Fee" )] Donation donation )
		{
			if ( ModelState.IsValid )
			{
				donation.DonationId = Guid.NewGuid();
				db.Donations.Add( donation );
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}

			ViewBag.CurrencyId = new SelectList( db.Currencies, "CurrencyId", "Code", donation.CurrencyId );
			ViewBag.DonorId = new SelectList( db.Donors, "DonorId", "Surname", donation.DonorId );
			ViewBag.NeedId = new SelectList( db.Needs, "NeedId", "Caption", donation.NeedId );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name", donation.OrganizationId );
			return View( donation );
		}

		// GET: Donations/Edit/5
		public ActionResult Edit( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Donation donation = db.Donations.Find( id );
			if ( donation == null )
			{
				return HttpNotFound();
			}
			ViewBag.CurrencyId = new SelectList( db.Currencies, "CurrencyId", "Code", donation.CurrencyId );
			ViewBag.DonorId = new SelectList( db.Donors, "DonorId", "Surname", donation.DonorId );
			ViewBag.NeedId = new SelectList( db.Needs, "NeedId", "Caption", donation.NeedId );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name", donation.OrganizationId );
			return View( donation );
		}

		// POST: Donations/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "DonationId,DonorId,OrganizationId,NeedId,Date,CurrencyId,Amount,Fee" )] Donation donation )
		{
			if ( ModelState.IsValid )
			{
				db.Entry( donation ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
			ViewBag.CurrencyId = new SelectList( db.Currencies, "CurrencyId", "Code", donation.CurrencyId );
			ViewBag.DonorId = new SelectList( db.Donors, "DonorId", "Surname", donation.DonorId );
			ViewBag.NeedId = new SelectList( db.Needs, "NeedId", "Caption", donation.NeedId );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name", donation.OrganizationId );
			return View( donation );
		}

		// GET: Donations/Delete/5
		public ActionResult Delete( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Donation donation = db.Donations.Find( id );
			if ( donation == null )
			{
				return HttpNotFound();
			}
			return View( donation );
		}

		// POST: Donations/Delete/5
		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( Guid id )
		{
			Donation donation = db.Donations.Find( id );
			db.Donations.Remove( donation );
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
