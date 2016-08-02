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
			ViewBag.Advertisers = db.Advertisers.ToList();
			var organizations = db.Organizations;//.Include( o => o.ProcessedBy );
			return View( organizations.ToList() );
		}

		// GET: Admin/Accept/5
		public ActionResult Accept( Guid id )
		{
			Organization org = db.Organizations.Find( id );
			return View( org );
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
				db.SaveChanges();
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
			Organization org = db.Organizations.Find( id );
			return View( org );
		}

		// POST: Admin/Reject/5
		[HttpPost]
		public ActionResult Reject( Guid id, FormCollection collection )
		{
			Organization org = db.Organizations.FirstOrDefault( o => o.OrganizationId == id );

			if ( org != null )
			{
				org.ApplicationApproveRejectDate = DateTime.Now;
				org.Status = "Application Rejected";
				org.RejectionReason = collection[ "RejectionReason" ];
				db.SaveChanges();
				SendApplicationRejectedEmail();
				return RedirectToAction( "Index" );
			}
			return View();
		}

		public void SendApplicationRejectedEmail()
		{
			//TODO: This functionality need to work
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

		// GET: Admin/AddUser
		public ActionResult AddUser()
		{
			return View();
		}
	}
}
