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
	public class NeedTypesController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public NeedTypesController()
		{
			ViewBag.IsAdmin = true;
		}

		// GET: NeedTypes
		public ActionResult Index()
		{
			return View( db.NeedTypes.ToList() );
		}

		// GET: NeedTypes/Details/5
		public ActionResult Details( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			NeedType needType = db.NeedTypes.Find( id );
			if ( needType == null )
			{
				return HttpNotFound();
			}
			return View( needType );
		}

		// GET: NeedTypes/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: NeedTypes/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "NeedTypeId,Description" )] NeedType needType )
		{
			if ( ModelState.IsValid )
			{
				needType.NeedTypeId = Guid.NewGuid();
				db.NeedTypes.Add( needType );
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}

			return View( needType );
		}

		// GET: NeedTypes/Edit/5
		public ActionResult Edit( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			NeedType needType = db.NeedTypes.Find( id );
			if ( needType == null )
			{
				return HttpNotFound();
			}
			return View( needType );
		}

		// POST: NeedTypes/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "NeedTypeId,Description" )] NeedType needType )
		{
			if ( ModelState.IsValid )
			{
				db.Entry( needType ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
			return View( needType );
		}

		// GET: NeedTypes/Delete/5
		public ActionResult Delete( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			NeedType needType = db.NeedTypes.Find( id );
			if ( needType == null )
			{
				return HttpNotFound();
			}
			return View( needType );
		}

		// POST: NeedTypes/Delete/5
		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( Guid id )
		{
			NeedType needType = db.NeedTypes.Find( id );
			db.NeedTypes.Remove( needType );
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
