namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics.CodeAnalysis;

	[Table( "Currency" )]
	public partial class Currency
	{
		[SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Currency()
		{
			Donations = new HashSet<Donation>();
			Organizations = new HashSet<Organization>();
		}

		[Key]
		public Guid CurrencyId { get; set; }

		[Required]
		[StringLength( 3 )]
		public string Code { get; set; }

		[Required]
		[StringLength( 20 )]
		public string Description { get; set; }

		[Required]
		[StringLength( 3 )]
		public string Symbol { get; set; }

		[Required]
		public bool IsSymbolAfter { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Donation> Donations { get; set; }

		[SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Organization> Organizations { get; set; }
	}
}
