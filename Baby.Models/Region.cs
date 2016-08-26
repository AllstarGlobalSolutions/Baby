namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics.CodeAnalysis;

	[Table( "Region" )]
	public partial class Region
	{
		[SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Region()
		{
			Users = new HashSet<ApplicationUser>();
			Advertisements = new HashSet<Advertisement>();
			Needs = new HashSet<Need>();
		}

		[Key]
		public Guid RegionId { get; set; }

		[Required]
		[StringLength( 25 )]
		public string Name { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public ICollection<ApplicationUser> Users { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public ICollection<Need> Needs { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public ICollection<Advertisement> Advertisements { get; set; }
	}
}
