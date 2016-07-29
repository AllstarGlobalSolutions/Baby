using System.ComponentModel.DataAnnotations;

namespace Baby.Models.ViewModels
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display( Name = "Email" )]
		public string Email { get; set; }
	}
}
