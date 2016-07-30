using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Baby.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[Display( Name = "Surname" )]
		public string Surname { get; set; }

		[Display( Name = "GivenNames" )]
		public string GivenNames { get; set; }

		[Required]
		[Display( Name = "User Name" )]
		public string UserName { get; set; }

		[Required]
		[StringLength( 100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6 )]
		[DataType( DataType.Password )]
		[Display( Name = "Password" )]
		public string Password { get; set; }

		[DataType( DataType.Password )]
		[Display( Name = "Confirm password" )]
		[Compare( "Password", ErrorMessage = "The password and confirmation password do not match." )]
		public string ConfirmPassword { get; set; }
	}
}
