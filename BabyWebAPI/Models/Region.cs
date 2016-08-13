namespace BabyWebAPI.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "Region" )]
	public partial class Region
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Region()
		{
//			DonorRegions = new HashSet<DonorRegion>();
			Needs = new HashSet<Need>();
		}

		[Key]
		public Guid RegionId { get; set; }

		[Required]
		[StringLength( 25 )]
		public string Name { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<DonorRegion> DonorRegions { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Need> Needs { get; set; }
	}
}