namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class DisplayAdvertisement
	{
		[Key]
		public Guid DisplayAdvertisementId { get; set; }

		public DateTime DisplayDttmUTC { get; set; }

		public virtual Advertisement Advertisement { get; set; }
		public virtual ApplicationUser User { get; set; }
	}
}
