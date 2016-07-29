namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "NeedSharing" )]
	public partial class NeedSharing
	{
		[Key]
		public Guid NeedSharingId { get; set; }

		public Guid DonorId { get; set; }

		public Guid NeedId { get; set; }

		[Column( TypeName = "date" )]
		public DateTime Date { get; set; }

		[Required]
		[StringLength( 20 )]
		public string HowShared { get; set; }

		public virtual Donor Donor { get; set; }

		public virtual Need Need { get; set; }
	}
}
