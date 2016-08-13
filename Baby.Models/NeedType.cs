namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics.CodeAnalysis;

	[Table( "NeedType" )]
	public partial class NeedType
	{
		[SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public NeedType()
		{
			Users = new HashSet<ApplicationUser>();
			Needs = new HashSet<Need>();
			Advertisements = new HashSet<Advertisement>();
		}

		[Key]
		public Guid NeedTypeId { get; set; }

		[Required]
		[StringLength( 30 )]
		public string Description { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<ApplicationUser> Users { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Need> Needs { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Advertisement> Advertisements { get; set; }
	}
}
