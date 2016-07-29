namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "DonorCountry" )]
	public partial class DonorCountry
	{
		[Key]
		public Guid DonorCountryId { get; set; }

		public Guid DonorId { get; set; }

		public Guid CountryId { get; set; }

		public virtual Country Country { get; set; }

		public virtual Donor Donor { get; set; }
	}
}
