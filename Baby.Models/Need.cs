namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics.CodeAnalysis;
	using System.Collections.Generic;

	[Table( "Need" )]
	public partial class Need
	{
		[SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Need()
		{
			DisplayNeeds = new HashSet<DisplayNeed>();
			NeedActivities = new HashSet<NeedActivity>();
			//			Donations = new HashSet<Donation>();
			//			NeedSharings = new HashSet<NeedSharing>();
		}

		[Key]
		public Guid NeedId { get; set; }

		[Required]
		[StringLength( 100 )]
		public string Caption { get; set; }

		[Column( TypeName = "ntext" )]
		public string Story { get; set; }

		[Required]
		public bool IsUrgent { get; set; }

		[Column( TypeName = "date" )]
		public DateTime? PublishDate { get; set; }

		[Column( TypeName = "date" )]
		public DateTime? EndDate { get; set; }

		[Required]
		public bool HasNeedBeenMet { get; set; }

		[Required]
		public bool IsActive { get; set; }

		public decimal? AmountNeeded { get; set; }

		[StringLength( 100 )]
		public string Tags { get; set; }

		[Required]
		public File File { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<DisplayNeed> DisplayNeeds { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Donation> Donations { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<NeedActivity> NeedActivities { get; set; }

		public virtual Country Country { get; set; }

		[Required]
		public virtual NeedType NeedType { get; set; }

		[Required]
		public virtual Organization Organization { get; set; }

		public virtual Region Region { get; set; }
	}
}
