namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "Device" )]
	public partial class Device
	{
		[Key]
		public Guid DeviceId { get; set; }

		[Required]
		[StringLength( 20 )]
		public string Manufacturer { get; set; }

		[StringLength( 20 )]
		public string Model { get; set; }

		[StringLength( 10 )]
		public string Version { get; set; }

		public bool IsTablet { get; set; }

		[StringLength( 15 )]
		public string OS { get; set; }

		public Guid DonorId { get; set; }

		public virtual Donor Donor { get; set; }
	}
}
