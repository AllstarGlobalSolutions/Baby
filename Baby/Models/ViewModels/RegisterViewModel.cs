using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Baby.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		public string OrganizationName { get; set; }

		[Display( Name = "Organization Identification Number" )]
		public string OfficialOrganizationId { get; set; }

		[Required]
		[EmailAddress]
		[Display( Name = "Organization Email" )]
		public string Email { get; set; }

		[Required]
		[Display( Name = "Organization Phone Number" )]
		public string PhoneNumber { get; set; }

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

		[Required]
		[Display( Name = "Organization Time Zone" )]
		public string TimeZone { get; set; }

		[Display( Name = "Organization Street Address" )]
		public string StreetAddress1 { get; set; }

		[Display( Name = "" )]
		public string StreetAddress2 { get; set; }

		[Display( Name = "District" )]
		public string District { get; set; }

		[Required]
		[Display( Name = "City" )]
		public string City { get; set; }

		[Display( Name = "State or Province" )]
		public string StateOrProvince { get; set; }

		[Display( Name = "Postal Code" )]
		public string PostalCode { get; set; }

		[Required]
		[Display( Name = "Country" )]
		public Guid CountryId { get; set; }
	}
}
