namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "Address" )]
	public partial class Address
	{
		[Key]
		public Guid AddressId { get; set; }

		[Required]
		[StringLength( 20 )]
		public string Type { get; set; }

		[StringLength( 30 )]
		public string Street1 { get; set; }

		[StringLength( 20 )]
		public string Street2 { get; set; }

		[StringLength( 20 )]
		public string District { get; set; }

		[StringLength( 20 )]
		public string City { get; set; }

		[StringLength( 20 )]
		public string StateOrProvince { get; set; }

		[StringLength( 10 )]
		public string PostalCode { get; set; }

		public Guid? CountryId { get; set; }

		public Guid? AdvertiserId { get; set; }

		public Guid? OrganizationId { get; set; }

		public string UserId { get; set; }

		// navigation properties
		public virtual Advertiser Advertiser { get; set; }
		public virtual Country Country { get; set; }
		public virtual Organization Organization { get; set; }
		public virtual ApplicationUser User { get; set; }
	}
}
