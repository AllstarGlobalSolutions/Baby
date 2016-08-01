using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Baby.Models
{
	public class File
	{
		public Guid FileId { get; set; }

		[StringLength( 255 )]
		public string FileName { get; set; }

		[StringLength( 100 )]
		public string ContentType { get; set; }

		public byte[] Content { get; set; }

		public Guid NeedId { get; set; }

		public virtual Need Need { get; set; }
	}
}