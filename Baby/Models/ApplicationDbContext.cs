using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Baby.Models
{

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

		protected override void OnModelCreating( DbModelBuilder modelBuilder )
		{
			#region Address
			#endregion

			#region AdTargetDevice
			#endregion

			#region AdTargetDonationAmount
			modelBuilder.Entity<AdTargetDonationAmount>()
				 .Property( e => e.MinimumAmount )
				 .HasPrecision( 18, 0 );

			modelBuilder.Entity<AdTargetDonationAmount>()
				 .Property( e => e.MaximumAmount )
				 .HasPrecision( 18, 0 );
			#endregion

			#region AdTargetDonorProfile
			#endregion

			#region Advertisement
			modelBuilder.Entity<Advertisement>()
				 .HasMany( e => e.AdTargetDonorProfiles )
				 .WithRequired( e => e.Advertisement )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Advertisement>()
				 .HasMany( e => e.AdTargetDevices )
				 .WithRequired( e => e.Advertisement )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Advertisement>()
				.HasMany( e => e.AdTargetDonationAmounts )
				.WithRequired( e => e.Advertisement )
				.WillCascadeOnDelete();
			#endregion

			#region Advertiser
			modelBuilder.Entity<Advertiser>()
				 .HasMany( e => e.Addresses )
				 .WithOptional( e => e.Advertiser )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Advertiser>()
				 .HasMany( e => e.Emails )
				 .WithOptional( e => e.Advertiser )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Advertiser>()
				 .HasMany( e => e.Phones )
				 .WithOptional( e => e.Advertiser )
				 .WillCascadeOnDelete();
			#endregion

			#region ApplicationUser
			modelBuilder.Entity<ApplicationUser>()
				.HasMany( e => e.Addresses )
				.WithOptional( e => e.User )
				.WillCascadeOnDelete();

			modelBuilder.Entity<ApplicationUser>()
				.HasMany( e => e.Emails )
				.WithOptional( e => e.User )
				.WillCascadeOnDelete();

			modelBuilder.Entity<ApplicationUser>()
				.HasMany( e => e.Phones )
				.WithOptional( e => e.User )
				.WillCascadeOnDelete();

/*			modelBuilder.Entity<ApplicationUser>()
				.HasMany( e => e.ProcessedOrganizations )
				.WithOptional( e => e.ProcessedBy )
				.WillCascadeOnDelete( false );*/
			#endregion

			#region Country
			modelBuilder.Entity<Country>()
				 .HasMany( e => e.Addresses )
				 .WithOptional( e => e.Country )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Country>()
				 .HasMany( e => e.DonorCountries )
				 .WithRequired( e => e.Country )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Country>()
				.HasMany( e => e.Donors )
				.WithOptional( e => e.Country )
				.WillCascadeOnDelete( false );

			modelBuilder.Entity<Country>()
				 .HasMany( e => e.Needs )
				 .WithOptional( e => e.Country )
				 .WillCascadeOnDelete( false );
			#endregion

			#region Currency
			modelBuilder.Entity<Currency>()
				 .HasMany( e => e.Donations )
				 .WithRequired( e => e.Currency )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Currency>()
				.HasMany( e => e.OrganizationCurrencies )
				.WithRequired( e => e.Currency )
				.WillCascadeOnDelete();
			#endregion

			#region Device
			#endregion

			#region DisplayNeed
			modelBuilder.Entity<DisplayNeed>()
				 .HasMany( e => e.DisplayNeedActivities )
				 .WithRequired( e => e.DisplayNeed )
				 .WillCascadeOnDelete();
			#endregion

			#region DisplayNeedActivity
			#endregion

			#region Donation
			modelBuilder.Entity<Donation>()
				 .Property( e => e.Amount )
				 .HasPrecision( 18, 0 );

			modelBuilder.Entity<Donation>()
				 .Property( e => e.Fee )
				 .HasPrecision( 18, 0 );
			#endregion

			#region Donor
			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.DisplayNeeds )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.Donations )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.NeedSharings )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.DonorCountries )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.DonorNeedTypes )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.DonorRegions )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.DonorTags )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete();
			#endregion

			#region DonorCountry
			#endregion

			#region DonorNeedType
			#endregion

			#region DonorRegion
			#endregion

			#region DonorTag
			#endregion

			#region Email
			#endregion

			#region Need
			modelBuilder.Entity<Need>()
				 .Property( e => e.Image )
				 .IsFixedLength();

			modelBuilder.Entity<Need>()
				 .Property( e => e.AmountNeeded )
				 .HasPrecision( 18, 0 );

			modelBuilder.Entity<Need>()
				 .HasMany( e => e.DisplayNeeds )
				 .WithRequired( e => e.Need )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Need>()
				 .HasMany( e => e.NeedSharings )
				 .WithRequired( e => e.Need )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Need>()
				.HasMany( e => e.Donations )
				.WithOptional( e => e.Need )
				.WillCascadeOnDelete( false );
			#endregion

			#region NeedSharing
			#endregion

			#region NeedType
			modelBuilder.Entity<NeedType>()
				 .HasMany( e => e.DonorNeedTypes )
				 .WithRequired( e => e.NeedType )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<NeedType>()
				 .HasMany( e => e.Needs )
				 .WithRequired( e => e.NeedType )
				 .WillCascadeOnDelete( false );
			#endregion

			#region Organization
			modelBuilder.Entity<Organization>()
				 .HasMany( e => e.Addresses )
				 .WithOptional( e => e.Organization )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Organization>()
				 .HasMany( e => e.Donations )
				 .WithRequired( e => e.Organization )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Organization>()
				 .HasMany( e => e.Emails )
				 .WithOptional( e => e.Organization )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Organization>()
				 .HasMany( e => e.Needs )
				 .WithRequired( e => e.Organization )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Organization>()
				 .HasMany( e => e.Phones )
				 .WithOptional( e => e.Organization )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Organization>()
				 .HasMany( e => e.ApplicationUsers )
				 .WithOptional( e => e.Organization )
				 .WillCascadeOnDelete( false );
			#endregion

			#region OrganizationCurrency
			#endregion

			#region Phone
			#endregion

			#region Region
			modelBuilder.Entity<Region>()
				 .HasMany( e => e.DonorRegions )
				 .WithRequired( e => e.Region )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Region>()
				 .HasMany( e => e.Needs )
				 .WithOptional( e => e.Region )
				 .WillCascadeOnDelete( false );
			#endregion

			base.OnModelCreating( modelBuilder );
		}

		public virtual DbSet<Address> Addresses { get; set; }
		public virtual DbSet<AdTargetDevice> AdTargetDevices { get; set; }
		public virtual DbSet<AdTargetDonationAmount> AdTargetDonationAmounts { get; set; }
		public virtual DbSet<AdTargetDonorProfile> AdTargetDonorProfiles { get; set; }
		public virtual DbSet<Advertisement> Advertisements { get; set; }
		public virtual DbSet<Advertiser> Advertisers { get; set; }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<Currency> Currencies { get; set; }
		public virtual DbSet<Device> Devices { get; set; }
		public virtual DbSet<DisplayNeed> DisplayNeeds { get; set; }
		public virtual DbSet<DisplayNeedActivity> DisplayNeedActivities { get; set; }
		public virtual DbSet<Donation> Donations { get; set; }
		public virtual DbSet<Donor> Donors { get; set; }
		public virtual DbSet<DonorCountry> DonorCountries { get; set; }
		public virtual DbSet<DonorNeedType> DonorNeedTypes { get; set; }
		public virtual DbSet<DonorRegion> DonorRegions { get; set; }
		public virtual DbSet<DonorTag> DonorTags { get; set; }
		public virtual DbSet<Email> Emails { get; set; }
		public virtual DbSet<Need> Needs { get; set; }
		public virtual DbSet<NeedSharing> NeedSharings { get; set; }
		public virtual DbSet<NeedType> NeedTypes { get; set; }
		public virtual DbSet<Organization> Organizations { get; set; }
		public virtual DbSet<OrganizationCurrency> OrganizationCurrencies { get; set; }
		public virtual DbSet<Phone> Phones { get; set; }
		public virtual DbSet<Region> Regions { get; set; }
		//		public virtual DbSet<User> Users { get; set; }

	}
}