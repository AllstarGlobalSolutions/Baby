using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Baby.Models
{
	public enum FileType
	{
		NeedImage,
		AdImage
	}

	public class File
	{
		public Guid FileId { get; set; }

		[Required]
		[StringLength( 255 )]
		public string FileName { get; set; }

		[Required]
		[StringLength( 100 )]
		public string ContentType { get; set; }

		[Required]
		public byte[] Content { get; set; }

		[Required]
		public FileType FileType { get; set; }

		public virtual ICollection<Need> Needs { get; set; }
		public virtual ICollection<Advertisement> Advertisements { get; set; }
	}
}