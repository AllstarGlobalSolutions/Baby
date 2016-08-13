namespace Baby.Models
{
	using Microsoft.AspNet.Identity.EntityFramework;
	using System.Data.Entity;
	using System.Data.Entity.ModelConfiguration.Conventions;

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
			/*
			 * Problems
			 * 
			 * ALTER TABLE [dbo].[Donation] ADD CONSTRAINT [FK_dbo.Donation_dbo.Currency_Currency_CurrencyId] FOREIGN KEY ([Currency_CurrencyId]) REFERENCES [dbo].[Currency] ([CurrencyId]) ON DELETE CASCADE
			 * ALTER TABLE [dbo].[Need] ADD CONSTRAINT [FK_dbo.Need_dbo.NeedType_NeedType_NeedTypeId] FOREIGN KEY ([NeedType_NeedTypeId]) REFERENCES [dbo].[NeedType] ([NeedTypeId]) ON DELETE CASCADE
			 * 
			 * NEED TO FORCE FOLLOWING TO CASCADE
			 * ALTER TABLE [dbo].[AspNetUsers] ADD CONSTRAINT [FK_dbo.AspNetUsers_dbo.Organization_Organization_OrganizationId] FOREIGN KEY ([Organization_OrganizationId]) REFERENCES [dbo].[Organization] ([OrganizationId])
			 * ALTER TABLE [dbo].[DeviceInfo] ADD CONSTRAINT [FK_dbo.DeviceInfo_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
			 * ALTER TABLE [dbo].[DisplayNeed] ADD CONSTRAINT [FK_dbo.DisplayNeed_dbo.Need_Need_NeedId] FOREIGN KEY ([Need_NeedId]) REFERENCES [dbo].[Need] ([NeedId])
			 * ALTER TABLE [dbo].[DisplayNeed] ADD CONSTRAINT [FK_dbo.DisplayNeed_dbo.AspNetUsers_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[AspNetUsers] ([Id])
			 */
			// remove all cascading deletes...we'll add manually
			//modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			//modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			/*
						#region Need
						// don't delete needs if needtype is deleted
						modelBuilder.Entity<Need>().HasRequired( n => n.NeedType ).WithRequiredDependent().WillCascadeOnDelete( false );
						#endregion Need

						#region AspNetUser
						// force delete of Users when organization is deleted
						modelBuilder.Entity<ApplicationUser>().HasOptional( u => u.Organization ).WithMany().WillCascadeOnDelete( true );
						#endregion AspNetUser

						#region Donation
						//			modelBuilder.Entity<Donation>().HasRequired( d => d.Organization ).WithMany().WillCascadeOnDelete( false );
						// do not delete donations if need is deleted
						modelBuilder.Entity<Donation>().HasRequired( d => d.Need ).WithMany().WillCascadeOnDelete( false );

						// do not delete donation if currency is deleted
						modelBuilder.Entity<Donation>().HasRequired( d => d.Currency ).WithMany().WillCascadeOnDelete( false );
						#endregion Donation

						#region UserNeedTypes
						// delete userneedtypes if user is deleted
						modelBuilder.Entity<UserNeedType>().HasRequired( unt => unt.User ).WithMany().WillCascadeOnDelete( true );
						#endregion
			*/
			base.OnModelCreating( modelBuilder );
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
		public virtual DbSet<NeedActivity> NeedActivities { get; set; }
		public virtual DbSet<Donation> Donations { get; set; }
		public virtual DbSet<Currency> Currencies { get; set; }
		public virtual DbSet<DeviceInfo> DeviceInfos { get; set; }
	}
}
