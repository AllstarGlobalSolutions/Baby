namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "DonorRegion" )]
	public partial class DonorRegion
	{
		[Key]
		public Guid DonorRegionId { get; set; }

		public Guid DonorId { get; set; }

		public Guid RegionId { get; set; }

		public virtual Donor Donor { get; set; }

		public virtual Region Region { get; set; }
	}
}
