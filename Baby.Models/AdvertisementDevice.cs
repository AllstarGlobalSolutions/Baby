namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class AdvertisementDevice
	{
		[Key]
		public Guid AdvertisementDeviceId { get; set; }

		[StringLength( 20 )]
		public string Manufacturer { get; set; }

		[StringLength( 20 )]
		public string Model { get; set; }

		[StringLength( 20 )]
		public string OS { get; set; }

		[Required]
		public virtual Advertisement Advertisement { get; set; }

	}
}
