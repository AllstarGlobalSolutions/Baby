using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baby.Models;

namespace Baby.Controllers.Base
{
	public class BaseController : Controller
	{
		protected Organization Organization = null;

		protected override void OnActionExecuting( ActionExecutingContext filterContext )
		{
			base.OnActionExecuting( filterContext );

			if ( Request != null && Request.IsAuthenticated )
			{
				ApplicationUserManager um = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
				this.Organization = um.FindById( User.Identity.GetUserId() ).Organization;
				ViewBag.Organization = this.Organization;
			}
		}

		protected ApplicationUser GetUser()
		{
			ApplicationUserManager um = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			return um.FindById( User.Identity.GetUserId() );
		}

		protected Organization GetOrganization()
		{
			return GetUser().Organization;
		}

	}
}