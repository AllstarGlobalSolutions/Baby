namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "AdTargetDonationAmount" )]
	public partial class AdTargetDonationAmount
	{
		[Key]
		public Guid AdTargetDonationAmountId { get; set; }

		public decimal? MinimumAmount { get; set; }

		public decimal? MaximumAmount { get; set; }

		public bool IsTotal { get; set; }

		public Guid AdvertisementId { get; set; }

		public virtual Advertisement Advertisement { get; set; }
	}
}
