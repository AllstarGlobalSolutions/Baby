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
			Donations = new HashSet<Donation>();
			//NeedSharings = new HashSet<NeedSharing>();
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

		public Guid? Image1Id { get; set; }
		public File Image1 { get; set; }
		public Guid? Image2Id { get; set; }
		public File Image2 { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<DisplayNeed> DisplayNeeds { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Donation> Donations { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<NeedActivity> NeedActivities { get; set; }

		[Required]
		public Guid CountryId { get; set; }
		public virtual Country Country { get; set; }

		[Required]
		public Guid NeedTypeId { get; set; }
		public virtual NeedType NeedType { get; set; }

		[Required]
		public Guid OrganizationId { get; set; }
		public virtual Organization Organization { get; set; }

		[Required]
		public Guid RegionId { get; set; }
		public virtual Region Region { get; set; }
	}
}
