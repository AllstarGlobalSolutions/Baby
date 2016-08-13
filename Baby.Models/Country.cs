namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics.CodeAnalysis;

	[Table( "Country" )]
	public partial class Country
	{
		[SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Country()
		{
			Advertisements = new HashSet<Advertisement>();
			Users = new HashSet<ApplicationUser>();
			Needs = new HashSet<Need>();
		}

		public Guid CountryId { get; set; }

		[Required]
		[StringLength( 2 )]
		public string Code { get; set; }

		[Required]
		[StringLength( 50 )]
		public string Name { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Advertisement> Advertisements { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<ApplicationUser> Users { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Need> Needs { get; set; }
	}
}
