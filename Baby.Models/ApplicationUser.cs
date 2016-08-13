namespace Baby.Models
{
	using System;
	using System.Security.Claims;
	using System.Threading.Tasks;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System.ComponentModel.DataAnnotations;
	using System.Collections.Generic;

	public enum UserType
	{
		Admin,
		Organization,
		Mobile
	}
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser() : base()
		{
			DisplayNeeds = new HashSet<DisplayNeed>();
			Regions = new HashSet<Region>();
			Donations = new HashSet<Donation>();
			NeedActivities = new HashSet<NeedActivity>();
			Phones = new HashSet<Phone>();
			Emails = new HashSet<Email>();
			Addresses = new HashSet<Address>();
		}

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync( UserManager<ApplicationUser> manager, string authenticationType )
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync( this, authenticationType );
			// Add custom user claims here
			return userIdentity;
		}

		[Required]
		[StringLength( 20 )]
		public string Surname { get; set; }

		[StringLength( 20 )]

		public string GivenNames { get; set; }

		[StringLength( 50 )]
		public string Tags { get; set; }

		public virtual Organization Organization { get; set; }

		[Required]
		public UserType Type { get; set; }

		public virtual DeviceInfo DeviceInfo { get; set; }

		public virtual ICollection<DisplayNeed> DisplayNeeds { get; set; }
		public virtual ICollection<Region> Regions { get; set; }
		public virtual ICollection<Donation> Donations { get; set; }
		public virtual ICollection<NeedActivity> NeedActivities { get; set; }
		public virtual ICollection<NeedType> NeedTypes { get; set; }
		public virtual ICollection<Country> Countries { get; set; }
		public virtual ICollection<Phone> Phones { get; set; }
		public virtual ICollection<Email> Emails { get; set; }
		public virtual ICollection<Address> Addresses { get; set; }
	}
}
