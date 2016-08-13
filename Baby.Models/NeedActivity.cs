namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "NeedActivity" )]
	public class NeedActivity
	{
		[Key]
		public Guid NeedActivityId { get; set; }

		[Required]
		[StringLength( 20 )]
		public string Type { get; set; }

		[Required]
		[StringLength( 200 )]
		public string Detail { get; set; }

		[Required]
		public DateTime StartDttmUTC { get; set; }

		[Required]
		public DateTime EndDttmUTC { get; set; }

		[Required]
		public Need Need { get; set; }

		[Required]
		public ApplicationUser User { get; set; }
	}
}
