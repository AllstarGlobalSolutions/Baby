namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "DonorTag" )]
	public partial class DonorTag
	{
		[Key]
		public Guid DonorTagId { get; set; }

		public Guid DonorId { get; set; }

		[Required]
		[StringLength( 50 )]
		public string Tag { get; set; }

		public virtual Donor Donor { get; set; }
	}
}
