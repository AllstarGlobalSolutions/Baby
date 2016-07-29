namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public enum Gender
	{
		Male,
		Female
	}

	[Table( "Donor" )]
	public partial class Donor
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Donor()
		{
			Devices = new HashSet<Device>();
			DisplayNeeds = new HashSet<DisplayNeed>();
			Donations = new HashSet<Donation>();
			NeedSharings = new HashSet<NeedSharing>();
			DonorCountries = new HashSet<DonorCountry>();
			DonorNeedTypes = new HashSet<DonorNeedType>();
			DonorRegions = new HashSet<DonorRegion>();
			DonorTags = new HashSet<DonorTag>();
		}

		[Key]
		public Guid DonorId { get; set; }

		[Required]
		[StringLength( 20 )]
		public string Surname { get; set; }

		[StringLength( 20 )]
		public string GivenNames { get; set; }

		[Required]
		[StringLength( 40 )]
		public string Email { get; set; }

		[StringLength( 5 )]
		public string PhoneCountryCode { get; set; }

		[StringLength( 15 )]
		public string PhoneNumber { get; set; }

		public DateTime DateOfBirth { get; set; }

		public Gender Gender { get; set; }

		[StringLength( 30 )]
		public string Occupation { get; set; }

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

		public virtual Country Country { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Device> Devices { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<DisplayNeed> DisplayNeeds { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Donation> Donations { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<NeedSharing> NeedSharings { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<DonorCountry> DonorCountries { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<DonorNeedType> DonorNeedTypes { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<DonorRegion> DonorRegions { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<DonorTag> DonorTags { get; set; }
	}
}
