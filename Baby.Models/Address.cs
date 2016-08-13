namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "Address" )]
	public class Address
	{
		[Key]
		public Guid AddressId { get; set; }

		[StringLength( 20 )]
		public string Type { get; set; }

		[StringLength( 30 )]
		public string Street { get; set; }

		[StringLength( 20 )]
		public string City { get; set; }

		[StringLength( 20 )]
		public string StateOrProvince { get; set; }

		[StringLength( 20 )]
		public string PostalCode { get; set; }

		public Country Country { get; set; }

		public virtual ApplicationUser User { get; set; }
		public virtual Organization Organization { get; set; }
		public virtual Advertiser Advertiser { get; set; }
	}
}
