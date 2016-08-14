namespace Baby.Models
{
	using System;
	using System.IO;
	using System.Data.Entity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using Microsoft.AspNet.Identity;
	using Baby.Models;

	public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
		protected override void Seed( ApplicationDbContext context )
		{
			AddUsers( context );
			AddRegions( context );
			AddNeedTypes( context );
			AddCurrencies( context );
			AddCountries( context );

			base.Seed( context );
		}

		/*
		 * NOTE: This function has no exception handling due to its seldome use.  So two common exceptions would be:
		 *		1 - The countries.csv file has lines with more than one (1) comma
		 *		2 - The countries.csv file has country names greater than 50 characters
		*/
		protected void AddCountries( ApplicationDbContext context )
		{
			using ( Stream stream = this.GetType().Assembly.GetManifestResourceStream( "Baby.Models.countries.csv" ) )
			{
				StreamReader sr = new StreamReader( stream );

				// loop until we reach the en of the file
				while ( !sr.EndOfStream )
				{
					string line = sr.ReadLine();
					string[] parts = line.Split( ',' );

					context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = parts[ 1 ], Name = parts[ 0 ] } );
				} // StreamReader sr = new StreamReader( stream );

				context.SaveChanges();
			} // using ( Stream stream = this.GetType().Assembly.GetManifestResourceStream( "Baby.ViewResources.countries.csv" ) )
		}

		protected void AddUsers( ApplicationDbContext context )
		{
			var userStore = new UserStore<ApplicationUser>( context );
			var userManager = new UserManager<ApplicationUser>( userStore );
			var userToInsert = new ApplicationUser { UserName = "admin", Surname = "Admin", GivenNames = "System", Email = "admin@local.com", Type = 0 };
			userManager.Create( userToInsert, "Password@123" );

			// add an email record for this user as well
			userToInsert.Emails.Add( new Email { EmailId = Guid.NewGuid(), Address = "admin@local.com", Type = "Work" } );
			context.SaveChanges();
//			userToInsert = new ApplicationUser { UserName = "evhatfield@yahoo.com", Surname = "Hatfield", GivenNames = "Eric Scott", Email = "evhatfield@yahoo.com", Type=2 };
//			userManager.Create( userToInsert, "Password@123" );
		}

		public void AddRegions( ApplicationDbContext context )
		{
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Africa" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Eastern Africa" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Middle Africa" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Northern Africa" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Southern Africa" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Western Africa" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "The Americas" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Northern America" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Latin America" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "The Caribbean" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Central Americ" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "South America" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Asia" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Europe" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Middle East" } );
			context.Regions.Add( new Region { RegionId = Guid.NewGuid(), Name = "Oceania" } );
		}

		public void AddNeedTypes( ApplicationDbContext context )
		{
			context.NeedTypes.Add( new NeedType { NeedTypeId = Guid.NewGuid(), Description = "Hunger" } );
			context.NeedTypes.Add( new NeedType { NeedTypeId = Guid.NewGuid(), Description = "Medical" } );
			context.NeedTypes.Add( new NeedType { NeedTypeId = Guid.NewGuid(), Description = "Financial" } );
			context.NeedTypes.Add( new NeedType { NeedTypeId = Guid.NewGuid(), Description = "Education" } );
			context.NeedTypes.Add( new NeedType { NeedTypeId = Guid.NewGuid(), Description = "Disaster Relief" } );
			context.NeedTypes.Add( new NeedType { NeedTypeId = Guid.NewGuid(), Description = "Clothing" } );
			context.NeedTypes.Add( new NeedType { NeedTypeId = Guid.NewGuid(), Description = "Transportation" } );
		}

		public void AddCurrencies( ApplicationDbContext context )
		{
			context.Currencies.Add( new Currency { CurrencyId = Guid.NewGuid(), Code = "CNY", Description = "Chinese Yuan (RMB)", Symbol = "元", IsSymbolAfter = true } );
			context.Currencies.Add( new Currency { CurrencyId = Guid.NewGuid(), Code = "USD", Description = "US Dollar", Symbol = "$", IsSymbolAfter = false } );
		}
	}
}