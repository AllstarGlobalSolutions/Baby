namespace Baby.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "DeviceInfo" )]
	public partial class DeviceInfo
	{
		[Key, ForeignKey( "User" )]
		public string UserId { get; set; }

		[Required]
		[StringLength( 20 )]
		public string Manufacturer { get; set; }

		[StringLength( 20 )]
		public string Model { get; set; }

		[StringLength( 10 )]
		public string Version { get; set; }

		[StringLength( 15 )]
		public string OS { get; set; }

		[Required]
		public virtual ApplicationUser User { get; set; }
	}
}
