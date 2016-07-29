namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "DisplayNeedActivity" )]
	public partial class DisplayNeedActivity
	{
		[Key]
		public Guid DisplayNeedActivityId { get; set; }

		public Guid DisplayNeedId { get; set; }

		[Required]
		[StringLength( 30 )]
		public string ActionType { get; set; }

		public DateTime? Time { get; set; }

		public virtual DisplayNeed DisplayNeed { get; set; }
	}
}
