namespace Baby.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table( "CustomNeedType" )]
	public partial class CustomNeedType
	{
		[Key]
		public Guid CustomNeedTypeId { get; set; }

		[Required]
		[StringLength( 20 )]
		public string Description { get; set; }

		public Guid OrganizationId { get; set; }
		public virtual Organization Organization { get; set; }
	}
}
