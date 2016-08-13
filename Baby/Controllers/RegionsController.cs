using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Baby.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Baby.Controllers
{
	public class RegionsController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();
		HttpClient client;
		string url = "http://192.168.1.6:58637/api/Regions";

		public RegionsController()
		{
			ViewBag.IsAdmin = true;
			client = new HttpClient();
			client.BaseAddress = new Uri( url );
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
		}

/*		// GET: Regions
		public ActionResult Index()
		{
			return View( db.Regions.ToList() );
		}
*/

		// GET: Regions
		public async Task<ActionResult> Index()
		{
			HttpResponseMessage response = await client.GetAsync( url );

			if ( response.IsSuccessStatusCode )
			{
				var responseData = response.Content.ReadAsStringAsync().Result;
				var regions = JsonConvert.DeserializeObject<List<Region>>( responseData );
				return View( regions );
			}

			return View( "Error" );
		}

/*	
		// GET: Regions/Details/5
		public ActionResult Details( Guid? id )
		{
			if ( id == null )
			{
				return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
			}
			Region region = db.Regions.Find( id );
			if ( region == null )
			{
				return HttpNotFound();
			}
			return View( region );
		}
*/
		// GET: Regions/Create
		public ActionResult Create()
		{
			return View();
		}

/*
		// POST: Regions/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create( [Bind( Include = "RegionId,Name" )] Region region )
		{
			if ( ModelState.IsValid )
			{
				region.RegionId = Guid.NewGuid();
				db.Regions.Add( region );
				db.SaveChanges();
				return RedirectToAction( "Index" );
			}

			return View( region );
		}
*/
		// POST: Regions/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create( Region region )
		{
			HttpResponseMessage responseMessage = await client.PostAsJsonAsync( url, region );

			if ( responseMessage.IsSuccessStatusCode )
			{
				return RedirectToAction( "Index" );
			}

			return RedirectToAction( "Error" );
		}

		/*
				// GET: Regions/Edit/5
				public ActionResult Edit( Guid? id )
				{
					if ( id == null )
					{
						return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
					}
					Region region = db.Regions.Find( id );
					if ( region == null )
					{
						return HttpNotFound();
					}
					return View( region );
				}

				// POST: Regions/Edit/5
				// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
				// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
				[HttpPost]
				[ValidateAntiForgeryToken]
				public ActionResult Edit( [Bind( Include = "RegionId,Name" )] Region region )
				{
					if ( ModelState.IsValid )
					{
						db.Entry( region ).State = EntityState.Modified;
						db.SaveChanges();
						return RedirectToAction( "Index" );
					}
					return View( region );
				}
		*/
		public async Task<ActionResult> Edit( Guid id )
		{
			HttpResponseMessage responseMessage = await client.GetAsync( url + "/" + id );

			if ( responseMessage.IsSuccessStatusCode )
			{
				var responseData = responseMessage.Content.ReadAsStringAsync().Result;
				var region = JsonConvert.DeserializeObject<Region>( responseData );

				return View( region );
			}

			return View( "Error" );
		}

		//The PUT Method
		[HttpPost]
		public async Task<ActionResult> Edit( Guid id, Region region )
		{
			HttpResponseMessage responseMessage = await client.PutAsJsonAsync( url + "/" + id, region );

			if ( responseMessage.IsSuccessStatusCode )
			{
				return RedirectToAction( "Index" );
			}

			return RedirectToAction( "Error" );
		}
		/*
				// GET: Regions/Delete/5
				public ActionResult Delete( Guid? id )
				{
					if ( id == null )
					{
						return new HttpStatusCodeResult( HttpStatusCode.BadRequest );
					}
					Region region = db.Regions.Find( id );
					if ( region == null )
					{
						return HttpNotFound();
					}
					return View( region );
				}

				// POST: Regions/Delete/5
				[HttpPost, ActionName( "Delete" )]
				[ValidateAntiForgeryToken]
				public ActionResult DeleteConfirmed( Guid id )
				{
					Region region = db.Regions.Find( id );
					db.Regions.Remove( region );
					db.SaveChanges();
					return RedirectToAction( "Index" );
				}
		*/

		public async Task<ActionResult> Delete( Guid id )
		{
			HttpResponseMessage responseMessage = await client.GetAsync( url + "/" + id );

			if ( responseMessage.IsSuccessStatusCode )
			{
				var responseData = responseMessage.Content.ReadAsStringAsync().Result;
				var region = JsonConvert.DeserializeObject<Region>( responseData );

				return View( region );
			}

			return View( "Error" );
		}

		//The DELETE method
		[HttpPost]
		public async Task<ActionResult> Delete( int id, Region region )
		{
			HttpResponseMessage responseMessage = await client.DeleteAsync( url + "/" + id );

			if ( responseMessage.IsSuccessStatusCode )
			{
				return RedirectToAction( "Index" );
			}
			return RedirectToAction( "Error" );
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
