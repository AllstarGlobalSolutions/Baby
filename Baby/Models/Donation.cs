namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "Donation" )]
	public partial class Donation
	{
		[Key]
		public Guid DonationId { get; set; }

		public Guid DonorId { get; set; }

		public Guid OrganizationId { get; set; }

		public Guid? NeedId { get; set; }

		[Required]
		public DateTime Date { get; set; }

		public Guid CurrencyId { get; set; }

		public decimal Amount { get; set; }

		public decimal Fee { get; set; }

		public virtual Currency Currency { get; set; }

		public virtual Donor Donor { get; set; }

		public virtual Need Need { get; set; }

		public virtual Organization Organization { get; set; }
	}
}
