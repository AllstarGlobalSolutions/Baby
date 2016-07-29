namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "Phone" )]
	public partial class Phone
	{
		[Key]
		public Guid PhoneId { get; set; }

		[Required]
		[StringLength( 10 )]
		public string Type { get; set; }

		[StringLength( 5 )]
		public string CountryCode { get; set; }

		[Required]
		[StringLength( 15 )]
		public string Number { get; set; }

		public Guid? AdvertiserId { get; set; }

		public Guid? OrganizationId { get; set; }

		public string UserId { get; set; }

		public virtual Advertiser Advertiser { get; set; }

		public virtual Organization Organization { get; set; }

		public virtual ApplicationUser User { get; set; }
	}
}
