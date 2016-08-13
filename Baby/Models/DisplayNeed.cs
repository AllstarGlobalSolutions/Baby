namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "DisplayNeed" )]
	public partial class DisplayNeed
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public DisplayNeed()
		{
			DisplayNeedActivities = new HashSet<DisplayNeedActivity>();
		}

		[Key]
		public Guid DisplayNeedId { get; set; }

		public Guid NeedId { get; set; }

		public Guid DonorId { get; set; }

		public DateTime? DisplayDttm { get; set; }

		public bool IsSaved { get; set; }

		public virtual Donor Donor { get; set; }

		public virtual Need Need { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<DisplayNeedActivity> DisplayNeedActivities { get; set; }
	}
}
