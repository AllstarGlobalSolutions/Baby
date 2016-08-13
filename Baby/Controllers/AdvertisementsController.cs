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
	public class AdvertisementsController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Advertisements
		public ActionResult Index( Guid? advertiserId )
		{
			IQueryable<Advertisement> advertisements;

			if ( advertiserId.HasValue )
			{
				ViewBag.Advertiser = db.Advertisers.Find( advertiserId );
				advertisements = db.Advertisements.Include( a => a.Advertiser ).Include( a => a.File ).Where( a => a.Advertiser.AdvertiserId == advertiserId );
			}
			else
			{
				ViewBag.Advertiser = null;
				advertisements = db.Advertisements.Include( a => a.Advertiser ).Include( a => a.File );
			}

			return View( advertisements.ToList() );
		}

		// GET: Advertisements/Details/5
		public ActionResult Details( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}

			Advertisement advertisement = db.Advertisements.Find( id );

			if ( advertisement == null )
			{
				return HttpNotFound();
			}
			return View( advertisement );
		}

		// GET: Advertisements/Create
		public ActionResult Create( Guid advertiserId )
		{
			ViewBag.Advertiser = db.Advertisers.Find( advertiserId );
			ViewBag.AdvertiserId = advertiserId;
			return View();
		}

		// POST: Advertisements/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "AdvertisementId,CampaignName,FileId,ClickUrl,StartDate,EndDate,AdvertiserId" )] Advertisement advertisement, HttpPostedFileBase Image )
		{
			if ( ModelState.IsValid )
			{
				Guid fileId = Guid.NewGuid();

				if ( Image != null && Image.ContentLength > 0 )
				{
					Baby.Models.File file = new Baby.Models.File
					{
						FileId = fileId,
						ContentType = Image.ContentType,
						FileName = System.IO.Path.GetFileName( Image.FileName ),
						FileType = FileType.NeedImage
					};

					using ( var reader = new System.IO.BinaryReader( Image.InputStream ) )
					{
						file.Content = reader.ReadBytes( Image.ContentLength );
					}

					db.Files.Add( file );
					db.SaveChanges();

					advertisement.AdvertisementId = Guid.NewGuid();
					advertisement.File.FileId = fileId;
					db.Advertisements.Add( advertisement );
					db.SaveChanges();
					return RedirectToAction( "Index" );
				}
			}

			ViewBag.Advertiser = db.Advertisers.Find( advertisement.Advertiser.AdvertiserId );
			ViewBag.AdvertiserId = advertisement.Advertiser.AdvertiserId;
			return View( advertisement );
		}

		// GET: Advertisements/Edit/5
		public ActionResult Edit( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}

			Advertisement advertisement = db.Advertisements.Include( a => a.File ).SingleOrDefault( a => a.AdvertisementId == id );

			if ( advertisement == null )
			{
				return HttpNotFound();
			}

			ViewBag.Advertiser = db.Advertisers.Find( advertisement.Advertiser.AdvertiserId );
			ViewBag.AdvertiserId = advertisement.Advertiser.AdvertiserId;
			return View( advertisement );
		}

		// POST: Advertisements/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( [Bind( Include = "AdvertisementId,CampaignName,FileId,ClickUrl,StartDate,EndDate,AdvertiserId" )] Advertisement advertisement, HttpPostedFileBase Image )
		{
			if ( ModelState.IsValid )
			{
				if ( Image != null && Image.ContentLength > 0 )
				{
					Baby.Models.File file = db.Files.Find( advertisement.File.FileId );
					if ( file == null )
					{
						file = new Baby.Models.File
						{
							FileId = Guid.NewGuid(),
							FileName = System.IO.Path.GetFileName( Image.FileName ),
							FileType = FileType.NeedImage,
							ContentType = Image.ContentType
						};
					}
					using ( var reader = new System.IO.BinaryReader( Image.InputStream ) )
					{
						file.Content = reader.ReadBytes( Image.ContentLength );
					}
					db.Files.Add( file );
					db.SaveChanges();

					advertisement.File.FileId = file.FileId;

					db.Entry( advertisement ).State = EntityState.Modified;
					db.SaveChanges();
					return RedirectToAction( "Index" );
				}
			}

			ViewBag.Advertiser = db.Advertisers.Find( advertisement.Advertiser.AdvertiserId );
			ViewBag.AdvertiserId = advertisement.Advertiser.AdvertiserId;
			return View( advertisement );
		}

		// GET: Advertisements/Delete/5
		public ActionResult Delete( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}

			Advertisement advertisement = db.Advertisements.Include( a => a.File ).SingleOrDefault( a => a.AdvertisementId == id );

			if ( advertisement == null )
			{
				return HttpNotFound();
			}
			return View( advertisement );
		}

		// POST: Advertisements/Delete/5
		[HttpPost, ActionName( "Delete" )]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed( Guid id )
		{
			Advertisement advertisement = db.Advertisements.Find( id );
			db.Advertisements.Remove( advertisement );
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
