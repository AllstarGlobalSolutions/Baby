namespace BabyWebAPI.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "Country" )]
	public partial class Country
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Country()
		{
//			Addresses = new HashSet<Address>();
//			AdTargetDonorProfiles = new HashSet<AdTargetDonorProfile>();
//			Donors = new HashSet<Donor>();
//			DonorCountries = new HashSet<DonorCountry>();
			Needs = new HashSet<Need>();
		}

		public Guid CountryId { get; set; }

		[Required]
		[StringLength( 2 )]
		public string Code { get; set; }

		[Required]
		[StringLength( 50 )]
		public string Name { get; set; }

//		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<Address> Addresses { get; set; }

//		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<AdTargetDonorProfile> AdTargetDonorProfiles { get; set; }

//		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<Donor> Donors { get; set; }

//		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<DonorCountry> DonorCountries { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Need> Needs { get; set; }
	}
}