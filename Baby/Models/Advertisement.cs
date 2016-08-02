namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "Advertisement" )]
	public partial class Advertisement
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Advertisement()
		{
			AdTargetDevices = new HashSet<AdTargetDevice>();
			AdTargetDonationAmounts = new HashSet<AdTargetDonationAmount>();
			AdTargetDonorProfiles = new HashSet<AdTargetDonorProfile>();
		}

		[Key]
		public Guid AdvertisementId { get; set; }

		[Required]
		[StringLength( 30 )]
		public string CampaignName { get; set; }

		public Guid? FileId { get; set; }
		public File File { get; set; }

		[Required]
		public string ClickUrl { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public Guid AdvertiserId { get; set; }

		// navigation properties
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<AdTargetDevice> AdTargetDevices { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<AdTargetDonationAmount> AdTargetDonationAmounts { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<AdTargetDonorProfile> AdTargetDonorProfiles { get; set; }

		public virtual Advertiser Advertiser { get; set; }
	}
}
