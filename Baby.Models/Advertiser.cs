namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics.CodeAnalysis;

	[Table( "Advertiser" )]
	public partial class Advertiser
	{
		[SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Advertiser()
		{
			Addresses = new HashSet<Address>();
			Advertisements = new HashSet<Advertisement>();
			Emails = new HashSet<Email>();
			Phones = new HashSet<Phone>();
			Donations = new HashSet<Donation>();
		}

		[Key]
		public Guid AdvertiserId { get; set; }

		[Required]
		[StringLength( 30 )]
		public string Name { get; set; }

		[Required]
		public string About { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Donation> Donations { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Address> Addresses { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Advertisement> Advertisements { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Email> Emails { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Phone> Phones { get; set; }
	}
}
