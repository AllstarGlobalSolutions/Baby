using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BabyWebAPI.Models
{
	using Baby.Models;

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			 : base( "DefaultConnection", throwIfV1Schema: false )
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public virtual DbSet<Advertisement> Advertisements { get; set; }
		public virtual DbSet<Advertiser> Advertisers { get; set; }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<File> Files { get; set; }
		public virtual DbSet<Need> Needs { get; set; }
		public virtual DbSet<DisplayNeed> DisplayNeeds { get; set; }
		public virtual DbSet<NeedType> NeedTypes { get; set; }
		public virtual DbSet<Organization> Organizations { get; set; }
		public virtual DbSet<Region> Regions { get; set; }

	}
}