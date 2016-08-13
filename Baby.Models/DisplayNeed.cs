namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "DisplayNeed" )]
	public partial class DisplayNeed
	{
		[Key]
		public Guid DisplayNeedId { get; set; }

		public DateTime DisplayDttm { get; set; }

		public int Count { get; set; }

		public virtual ApplicationUser User { get; set; }

		public virtual Need Need { get; set; }
	}
}
