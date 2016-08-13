namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics.CodeAnalysis;
	using System.Collections.Generic;

	[Table( "Advertisement" )]
	public partial class Advertisement
	{
		[SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Advertisement()
		{
			Regions = new HashSet<Region>();
			AdvertisementDevices = new HashSet<AdvertisementDevice>();
			Countries = new HashSet<Country>();
			NeedTypes = new HashSet<NeedType>();
		}

		[Key]
		public Guid AdvertisementId { get; set; }

		[Required]
		[StringLength( 30 )]
		public string CampaignName { get; set; }

		[Required]
		public File File { get; set; }

		[Required]
		public string ClickUrl { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		// navigation properties
		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Region> Regions { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<AdvertisementDevice> AdvertisementDevices { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Country> Countries { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<NeedType> NeedTypes { get; set; }

		[Required]
		public virtual Advertiser Advertiser { get; set; }
	}
}
