namespace BabyWebAPI.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "DisplayNeed" )]
	public partial class DisplayNeed
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public DisplayNeed()
		{
//			DisplayNeedActivities = new HashSet<DisplayNeedActivity>();
		}

		[Key]
		public Guid DisplayNeedId { get; set; }

		public Guid NeedId { get; set; }

		public string UserId { get; set; }

		public DateTime? DisplayDttm { get; set; }

		public bool IsSaved { get; set; }

		public virtual ApplicationUser User { get; set; }

		public virtual Need Need { get; set; }

//		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
//		public virtual ICollection<DisplayNeedActivity> DisplayNeedActivities { get; set; }
	}
}