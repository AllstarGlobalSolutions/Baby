namespace WebApplication1.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Model1 : DbContext
	{
		public Model1()
			 : base( "name=DataModel" )
		{
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

		protected override void OnModelCreating( DbModelBuilder modelBuilder )
		{
			modelBuilder.Entity<AdTargetDonationAmount>()
				 .Property( e => e.MinimumAmount )
				 .HasPrecision( 18, 0 );

			modelBuilder.Entity<AdTargetDonationAmount>()
				 .Property( e => e.MaximumAmount )
				 .HasPrecision( 18, 0 );

			modelBuilder.Entity<Advertisement>()
				 .HasMany( e => e.AdTargetDonorProfiles )
				 .WithRequired( e => e.Advertisement )
				 .WillCascadeOnDelete( false );

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

			modelBuilder.Entity<Country>()
				 .HasMany( e => e.Addresses )
				 .WithOptional( e => e.Country )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Country>()
				 .HasMany( e => e.DonorCountries )
				 .WithRequired( e => e.Country )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Country>()
				 .HasMany( e => e.Needs )
				 .WithRequired( e => e.Country )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Currency>()
				 .HasMany( e => e.Donations )
				 .WithRequired( e => e.Currency )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<DisplayNeed>()
				 .HasMany( e => e.DisplayNeedActivities )
				 .WithRequired( e => e.DisplayNeed )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Donation>()
				 .Property( e => e.Amount )
				 .HasPrecision( 18, 0 );

			modelBuilder.Entity<Donation>()
				 .Property( e => e.Fee )
				 .HasPrecision( 18, 0 );

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
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.DonorNeedTypes )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.DonorRegions )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Donor>()
				 .HasMany( e => e.DonorTags )
				 .WithRequired( e => e.Donor )
				 .WillCascadeOnDelete( false );

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

			modelBuilder.Entity<NeedType>()
				 .HasMany( e => e.DonorNeedTypes )
				 .WithRequired( e => e.NeedType )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<NeedType>()
				 .HasMany( e => e.Needs )
				 .WithRequired( e => e.NeedType )
				 .WillCascadeOnDelete( false );

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
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Organization>()
				 .HasMany( e => e.Phones )
				 .WithOptional( e => e.Organization )
				 .WillCascadeOnDelete();

			modelBuilder.Entity<Organization>()
				 .HasMany( e => e.Users )
				 .WithOptional( e => e.Organization )
				 .HasForeignKey( e => e.OrganizationId );

			modelBuilder.Entity<Region>()
				 .HasMany( e => e.DonorRegions )
				 .WithRequired( e => e.Region )
				 .WillCascadeOnDelete( false );

			modelBuilder.Entity<Region>()
				 .HasMany( e => e.Needs )
				 .WithRequired( e => e.Region )
				 .WillCascadeOnDelete( false );

/*			modelBuilder.Entity<ApplicationUser>()
				 .HasMany( e => e.Organizations )
				 .WithOptional( e => e.ProcessedBy )
				 .HasForeignKey( e => e.ProcessedById );*/
		}
	}
}
