using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baby.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Baby.Controllers.Base;

namespace Baby.Controllers
{
	public class HomeController : BaseController
	{
		protected ApplicationDbContext db = new ApplicationDbContext();
		protected UserManager<ApplicationUser> UserManager;

		public HomeController()
		{
			UserManager = new UserManager<ApplicationUser>( new UserStore<ApplicationUser>( db ) );
		}

		public ActionResult Index()
		{
			if ( User.Identity.IsAuthenticated )
			{
				var user = UserManager.FindById( User.Identity.GetUserId() );
				if ( user != null && user.IsAdmin )
				{
					return RedirectToAction( "Index", "Admin" );
				}
			}
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}