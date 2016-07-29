namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "DonorNeedType" )]
	public partial class DonorNeedType
	{
		[Key]
		public Guid DonorNeedTypeId { get; set; }

		public Guid DonorId { get; set; }

		public Guid NeedTypeId { get; set; }

		public virtual Donor Donor { get; set; }

		public virtual NeedType NeedType { get; set; }
	}
}
