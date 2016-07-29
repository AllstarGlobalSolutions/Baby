using System.ComponentModel.DataAnnotations;

namespace Baby.Models.ViewModels
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[Display( Name = "Email" )]
		public string Email { get; set; }
	}
}
