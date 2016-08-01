using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Baby.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			Addresses = new HashSet<Address>();
			Emails = new HashSet<Email>();
//			ProcessedOrganizations = new HashSet<Organization>();
			Phones = new HashSet<Phone>();
		}

		[Required]
		public string Surname { get; set; }
		public string GivenNames { get; set; }

		public Guid? OrganizationId { get; set; }
		public virtual Organization Organization { get; set; }

		public virtual ICollection<Address> Addresses { get; set; }

		public virtual ICollection<Phone> Phones { get; set; }

		public virtual ICollection<Email> Emails { get; set; }

//		public virtual ICollection<Organization> ProcessedOrganizations { get; set; }

		public bool IsAdmin
		{
			get { return this.OrganizationId == null; }
		}

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync( UserManager<ApplicationUser> manager )
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync( this, DefaultAuthenticationTypes.ApplicationCookie );
			// Add custom user claims here
			return userIdentity;
		}
	}
}
