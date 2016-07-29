namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "AdTargetDonorProfile" )]
	public partial class AdTargetDonorProfile
	{
		[Key]
		public Guid AdTargetDonorProfileId { get; set; }

		public byte Gender { get; set; }

		[StringLength( 20 )]
		public string Occupation { get; set; }

		[StringLength( 20 )]
		public string District { get; set; }

		[StringLength( 20 )]
		public string City { get; set; }

		[StringLength( 20 )]
		public string StateOrProvince { get; set; }

		[StringLength( 10 )]
		public string PostalCode { get; set; }

		public Guid? CountryId { get; set; }

		public Guid AdvertisementId { get; set; }

		public virtual Advertisement Advertisement { get; set; }

		public virtual Country Country { get; set; }
	}
}
