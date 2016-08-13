namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "Donation" )]
	public partial class Donation
	{
		[Key]
		public Guid DonationId { get; set; }

		[Required]
		public DateTime DateTimeUTC { get; set; }

		[Required]
		public decimal Amount { get; set; }

		public decimal Fee { get; set; }

		[Required]
		public virtual Currency Currency { get; set; }

		public virtual ApplicationUser User { get; set; }

		public virtual Advertiser Advertiser { get; set; }

		[Required]
		public virtual Need Need { get; set; }
	}
}
