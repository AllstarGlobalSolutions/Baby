namespace BabyWebAPI.Controllers
{
	using System;
	using Baby.Models;
	using System.Web.Http;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Net;
	using System.IO;

	/*
	 * This controller is used for returning images to an <img /> HTML tag.
	 */
	[AllowAnonymous]
	public class FilesController : ApiController
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		public HttpResponseMessage Get( Guid id )
		{
			var file = db.Files.Find( id );
			HttpResponseMessage response = new HttpResponseMessage( HttpStatusCode.OK );

			response.Content = new StreamContent( new MemoryStream( file.Content ) );
			response.Content.Headers.ContentType = new MediaTypeHeaderValue( file.ContentType );
			return response;
		}
	}
}
