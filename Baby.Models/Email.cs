namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "Email" )]
	public class Email
	{
		[Key]
		public Guid EmailId { get; set; }

		[StringLength( 20 )]
		public string Type { get; set; }

		[StringLength( 40 )]
		public string Address { get; set; }

		public virtual ApplicationUser User { get; set; }
		public virtual Organization Organization { get; set; }
		public virtual Advertiser Advertiser { get; set; }
	}
}
