namespace BabyWebAPI.Models
{
	using System;
	using System.Security.Claims;
	using System.Threading.Tasks;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System.ComponentModel.DataAnnotations;

	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync( UserManager<ApplicationUser> manager, string authenticationType )
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync( this, authenticationType );
			// Add custom user claims here
			return userIdentity;
		}

		[Required]
		public string Surname { get; set; }
		public string GivenNames { get; set; }

		public Guid? OrganizationId { get; set; }
		public virtual Organization Organization { get; set; }

		[Required]
		public int Type { get; set;  } // 0 = admin, 1 = org, 2 = mobile/donor
	}
}