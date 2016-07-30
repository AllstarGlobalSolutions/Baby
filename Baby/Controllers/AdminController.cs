using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baby.Controllers
{
	public class AdminController : Controller
	{
		// GET: Admin
		public ActionResult Index()
		{
			return View();
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
			return View();
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
