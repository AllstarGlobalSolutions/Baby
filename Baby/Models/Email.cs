namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "Email" )]
	public partial class Email
	{
		[Key]
		public Guid EmailId { get; set; }

		[Required]
		[StringLength( 20 )]
		public string Type { get; set; }

		[Required]
		[StringLength( 40 )]
		public string Address { get; set; }

		public Guid? AdvertiserId { get; set; }

		public Guid? OrganizationId { get; set; }

		public string UserId { get; set; }

		public virtual Advertiser Advertiser { get; set; }

		public virtual Organization Organization { get; set; }

		public virtual ApplicationUser User { get; set; }
	}
}
