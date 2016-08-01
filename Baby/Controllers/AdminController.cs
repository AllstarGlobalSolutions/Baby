using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baby.Models;

namespace Baby.Controllers
{
	public class AdminController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public AdminController()
		{
			ViewBag.IsAdmin = true;
		}

		// GET: Admin
		public ActionResult Index()
		{
			var organizations = db.Organizations;//.Include( o => o.ProcessedBy );
			return View( organizations.ToList() );
		}

		// GET: Admin/Accept/5
		public ActionResult Accept( Guid id )
		{
			return View();
		}

		// POST: Admin/Accpt/5
		[HttpPost]
		public ActionResult Accept( Guid id, FormCollection collection )
		{
			Organization org = db.Organizations.FirstOrDefault( o => o.OrganizationId == id );

			if ( org != null )
			{
				org.ApplicationApproveRejectDate = DateTime.Now;
				org.Status = "Application Accepted";
				SendApplicationAcceptedEmail();
				return RedirectToAction( "Index" );
			}
			return View();
		}

		public void SendApplicationAcceptedEmail()
		{
			//TODO: This functionality needs to work
		}

		// GET: Admin/Reject/5
		public ActionResult Reject( Guid id )
		{
			return View();
		}

		// POST: Admin/Reject/5
		[HttpPost]
		public ActionResult Reject( Guid id, FormCollection collection )
		{
			return View();
		}

		// GET: Admin/Delete/5
		public ActionResult Delete( Guid id )
		{
			return View();
		}

		// POST: Admin/Delete/5
		[HttpPost]
		public ActionResult Delete( Guid id, FormCollection collection )
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction( "Index" );
			}
			catch
			{
				return View();
			}
		}
	}
}
