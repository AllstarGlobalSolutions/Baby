namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "OrganizationCurrency" )]
	public partial class OrganizationCurrency
	{
		[Key]
		public Guid OrganizationCurrencyId { get; set; }

		public Guid OrganizationId { get; set; }

		public Guid CurrencyId { get; set; }

		public virtual Currency Currency { get; set; }

		public virtual Organization Organization { get; set; }
	}
}
