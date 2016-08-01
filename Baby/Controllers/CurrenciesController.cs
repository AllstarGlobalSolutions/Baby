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
	public class CurrenciesController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public CurrenciesController()
		{
			ViewBag.IsAdmin = true;
		}

		// GET: Currencies
		public ActionResult Index()
		{
			return View( db.Currencies.ToList() );
		}

		// GET: Currencies/Details/5
		public ActionResult Details( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Currency currency = db.Currencies.Find( id );
			if ( currency == null )
			{
				return HttpNotFound();
			}
			return View( currency );
		}

		// GET: Currencies/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Currencies/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "CurrencyId,Code,Description,Symbol,IsSymbolAfter" )] Currency currency )
		{
			if ( ModelState.IsValid )
			{
				currency.CurrencyId = Guid.NewGuid();
				db.Currencies.Add( currency );
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}

			return View( currency );
		}

		// GET: Currencies/Edit/5
		public ActionResult Edit( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Currency currency = db.Currencies.Find( id );
			if ( currency == null )
			{
				return HttpNotFound();
			}
			return View( currency );
		}

		// POST: Currencies/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "CurrencyId,Code,Description,Symbol,IsSymbolAfter" )] Currency currency )
		{
			if ( ModelState.IsValid )
			{
				db.Entry( currency ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
			return View( currency );
		}

		// GET: Currencies/Delete/5
		public ActionResult Delete( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Currency currency = db.Currencies.Find( id );
			if ( currency == null )
			{
				return HttpNotFound();
			}
			return View( currency );
		}

		// POST: Currencies/Delete/5
		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( Guid id )
		{
			Currency currency = db.Currencies.Find( id );
			db.Currencies.Remove( currency );
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
