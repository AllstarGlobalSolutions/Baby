namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Web;

	[Table( "Need" )]
	public partial class Need
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Need()
		{
			DisplayNeeds = new HashSet<DisplayNeed>();
			Donations = new HashSet<Donation>();
			NeedSharings = new HashSet<NeedSharing>();
		}

		[Key]
		public Guid NeedId { get; set; }

		[Required]
		[StringLength( 30 )]
		public string Caption { get; set; }

		[Column( TypeName = "ntext" )]
		public string Story { get; set; }

		public bool IsUrgent { get; set; }

		[Column( TypeName = "date" )]
		public DateTime? PublishDate { get; set; }

		[Column( TypeName = "date" )]
		public DateTime? EndDate { get; set; }

		public bool HasNeedBeenMet { get; set; }

		public bool IsActive { get; set; }

		public decimal? AmountNeeded { get; set; }

		[StringLength( 50 )]
		public string AdditionalTags { get; set; }

		public Guid OrganizationId { get; set; }

		public Guid NeedTypeId { get; set; }

		public Guid? RegionId { get; set; }

		public Guid? CountryId { get; set; }

		public Guid FileId { get; set; }

		public File File { get; set; }

		[StringLength( 25 )]
		public string City { get; set; }

		public virtual Country Country { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<DisplayNeed> DisplayNeeds { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Donation> Donations { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<NeedSharing> NeedSharings { get; set; }

		public virtual NeedType NeedType { get; set; }

		public virtual Organization Organization { get; set; }

		public virtual Region Region { get; set; }
	}
}
