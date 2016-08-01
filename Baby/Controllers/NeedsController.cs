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
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Baby.Controllers
{
	public class NeedsController : BaseController
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Needs
		public ActionResult Index()
		{
			var needs = db.Needs.Include( n => n.Country ).Include( n => n.NeedType ).Include( n => n.Organization ).Include( n => n.Region );
			return View( needs.ToList() );
		}

		// GET: Needs/Details/5
		public ActionResult Details( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Need need = db.Needs.Find( id );
			if ( need == null )
			{
				return HttpNotFound();
			}
			return View( need );
		}

		// GET: Needs/Create
		public ActionResult Create()
		{
			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Code" );
			ViewBag.NeedTypeId = new SelectList( db.NeedTypes, "NeedTypeId", "Description" );
			ViewBag.RegionId = new SelectList( db.Regions, "RegionId", "Name" );
			return View();
		}

		// POST: Needs/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
//		public ActionResult Create( [Bind( Include = "NeedId,Caption,Story,Image,IsUrgent,PublishDate,EndDate,HasNeedBitMet,IsActive,AmountNeeded,AdditionalTags,OrganizationId,NeedTypeId,RegionId,CountryId,City" )] Need need, HttpPostedFileBase ImageFile )
		public ActionResult Create( Need need )
		{
			if ( ModelState.IsValid )
			{
				need.NeedId = Guid.NewGuid();
				db.Needs.Add( need );

				if ( need.Image.ContentLength > 0 )
				{
					need.ImageFileName = Path.GetFileName( need.Image.FileName );
					var uploadPath = Path.Combine( Server.MapPath( "~/App_Data/uploads" ), this.Organization.OrganizationId.ToString() );
					if ( !Directory.Exists( uploadPath ) )
					{
						Directory.CreateDirectory( uploadPath );
					}
					uploadPath = Path.Combine( uploadPath, need.NeedId.ToString() );
					need.Image.SaveAs( uploadPath );
				}

				db.SaveChanges();
				return RedirectToAction( "Index" );
			}

			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Name", need.CountryId );
			ViewBag.NeedTypeId = new SelectList( db.NeedTypes, "NeedTypeId", "Description", need.NeedTypeId );
			ViewBag.RegionId = new SelectList( db.Regions, "RegionId", "Name", need.RegionId );
			return View( need );
		}

		// GET: Needs/Edit/5
		public ActionResult Edit( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Need need = db.Needs.Find( id );
			if ( need == null )
			{
				return HttpNotFound();
			}
			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Code", need.CountryId );
			ViewBag.NeedTypeId = new SelectList( db.NeedTypes, "NeedTypeId", "Description", need.NeedTypeId );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name", need.OrganizationId );
			ViewBag.RegionId = new SelectList( db.Regions, "RegionId", "Name", need.RegionId );
			return View( need );
		}

		// POST: Needs/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "NeedId,Caption,Story,Image,IsUrgent,PublishDate,EndDate,HasNeedBitMet,IsActive,AmountNeeded,AdditionalTags,OrganizationId,NeedTypeId,RegionId,CountryId,City" )] Need need )
		{
			if ( ModelState.IsValid )
			{
				db.Entry( need ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Code", need.CountryId );
			ViewBag.NeedTypeId = new SelectList( db.NeedTypes, "NeedTypeId", "Description", need.NeedTypeId );
			ViewBag.OrganizationId = new SelectList( db.Organizations, "OrganizationId", "Name", need.OrganizationId );
			ViewBag.RegionId = new SelectList( db.Regions, "RegionId", "Name", need.RegionId );
			return View( need );
		}

		// GET: Needs/Delete/5
		public ActionResult Delete( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Need need = db.Needs.Find( id );
			if ( need == null )
			{
				return HttpNotFound();
			}
			return View( need );
		}

		// POST: Needs/Delete/5
		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( Guid id )
		{
			Need need = db.Needs.Find( id );
			db.Needs.Remove( need );
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
