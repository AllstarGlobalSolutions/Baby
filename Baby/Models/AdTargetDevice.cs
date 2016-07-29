namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "AdTargetDevice" )]
	public partial class AdTargetDevice
	{
		[Key]
		public Guid AtTargetDeviceId { get; set; }

		[StringLength( 20 )]
		public string Manufacturer { get; set; }

		[StringLength( 20 )]
		public string Model { get; set; }

		[StringLength( 15 )]
		public string Version { get; set; }

		public bool IsTablet { get; set; }

		public Guid AdvertisementId { get; set; }

		// navigation property
		public virtual Advertisement Advertisement { get; set; }
	}
}
