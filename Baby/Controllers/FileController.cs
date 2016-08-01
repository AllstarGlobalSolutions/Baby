using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baby.Models;

namespace Baby.Controllers
{
	public class FileController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: File
		public ActionResult Index( Guid id )
		{
			var file = db.Files.Find( id );

			return File( file.Content, file.ContentType );
		}
	}
}