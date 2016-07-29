using System.ComponentModel.DataAnnotations;

namespace Baby.Models.ViewModels
{
	public class ForgotViewModel
	{
		[Required]
		[Display( Name = "Email" )]
		public string Email { get; set; }
	}
}
