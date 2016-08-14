namespace Baby.Models.ViewModels
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class CreateNeedViewModel
	{
		[Required]
		public string Caption { get; set; }

		[Required]
		public string Story { get; set; }

		[Required]
		public bool IsUrgent { get; set; }

		public DateTime? PublishDate { get; set; }

		public DateTime? EndDate { get; set; }

		public decimal? AmountNeeded { get; set; }

		[StringLength( 100 )]
		public string Tags { get; set; }

		public Guid? CountryId { get; set; }
		public Guid? RegionId { get; set; }
		public Guid NeedTypeId { get; set; }
	}
}