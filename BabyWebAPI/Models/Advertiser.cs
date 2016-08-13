namespace BabyWebAPI.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "Advertiser" )]
	public partial class Advertiser
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Advertiser()
		{
//			Addresses = new HashSet<Address>();
			Advertisements = new HashSet<Advertisement>();
//			Emails = new HashSet<Email>();
//			Phones = new HashSet<Phone>();
		}

		[Key]
		public Guid AdvertiserId { get; set; }

		[Required]
		[StringLength( 30 )]
		public string Name { get; set; }

//		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<Address> Addresses { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Advertisement> Advertisements { get; set; }

//		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<Email> Emails { get; set; }

//		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<Phone> Phones { get; set; }
	}
}