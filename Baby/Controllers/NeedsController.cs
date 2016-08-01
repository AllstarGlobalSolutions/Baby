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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity.Infrastructure;

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
			Need need = db.Needs.Include( n => n.Images ).SingleOrDefault( n => n.NeedId == id );
			if ( need == null )
			{
				return HttpNotFound();
			}
			return View( need );
		}

		// GET: Needs/Create
		public ActionResult Create()
		{
			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Name" );
			ViewBag.NeedTypeId = new SelectList( db.NeedTypes, "NeedTypeId", "Description" );
			ViewBag.RegionId = new SelectList( db.Regions, "RegionId", "Name" );
			return View();
		}

		// POST: Needs/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "NeedId,Caption,Story,IsUrgent,PublishDate,EndDate,HasNeedBeenMet,IsActive,AmountNeeded,AdditionalTags,OrganizationId,NeedTypeId,RegionId,CountryId,City" )] Need need, HttpPostedFileBase Image )
		{
			try
			{
				if ( ModelState.IsValid )
				{
					need.NeedId = Guid.NewGuid();
					db.Needs.Add( need );

					if ( Image != null && Image.ContentLength > 0 )
					{
						Baby.Models.File file = new Baby.Models.File
						{
							FileId = Guid.NewGuid(),
							ContentType = Image.ContentType,
							FileName = System.IO.Path.GetFileName( Image.FileName )
						};

						using ( var reader = new System.IO.BinaryReader( Image.InputStream ) )
						{
							file.Content = reader.ReadBytes( Image.ContentLength );
						}

						need.Images.Add( file );
						db.SaveChanges();
					}

					db.SaveChanges();
					return RedirectToAction( "Index" );
				}
			}
			catch ( RetryLimitExceededException /*e*/)
			{
				ModelState.AddModelError( "", "Unable to Save Changes." );
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

			Need need = db.Needs.Include( n => n.Images ).SingleOrDefault( n => n.NeedId == id );

			if ( need == null )
			{
				return HttpNotFound();
			}
			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Name", need.CountryId );
			ViewBag.NeedTypeId = new SelectList( db.NeedTypes, "NeedTypeId", "Description", need.NeedTypeId );
			ViewBag.RegionId = new SelectList( db.Regions, "RegionId", "Name", need.RegionId );
			return View( need );
		}

		// POST: Needs/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "NeedId,Caption,Story,IsUrgent,PublishDate,EndDate,HasNeedBeenMet,IsActive,AmountNeeded,AdditionalTags,OrganizationId,NeedTypeId,RegionId,CountryId,City" )] Need need, HttpPostedFileBase Image )
		{
			if ( ModelState.IsValid )
			{
				if ( Image != null && Image.ContentLength > 0 )
				{
					if ( db.Files.Any( f => f.NeedId == need.NeedId ) )
					{
						db.Files.Remove( db.Files.First( f => f.NeedId == need.NeedId ) );
					}
					Baby.Models.File image = new Baby.Models.File
					{
						FileId = Guid.NewGuid(),
						FileName = System.IO.Path.GetFileName( Image.FileName ),
						ContentType = Image.ContentType,
						NeedId = need.NeedId
					};
					using ( var reader = new System.IO.BinaryReader( Image.InputStream ) )
					{
						image.Content = reader.ReadBytes( Image.ContentLength );
					}
					db.Files.Add( image );
//					need.Images = new List<File> { image };
				}
				db.Entry( need ).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}
			ViewBag.CountryId = new SelectList( db.Countries, "CountryId", "Name", need.CountryId );
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
