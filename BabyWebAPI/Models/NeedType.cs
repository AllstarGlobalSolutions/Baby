namespace BabyWebAPI.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "NeedType" )]
	public partial class NeedType
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public NeedType()
		{
//			DonorNeedTypes = new HashSet<DonorNeedType>();
			Needs = new HashSet<Need>();
		}

		[Key]
		public Guid NeedTypeId { get; set; }

		[Required]
		[StringLength( 30 )]
		public string Description { get; set; }

//		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<DonorNeedType> DonorNeedTypes { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Need> Needs { get; set; }
	}
}