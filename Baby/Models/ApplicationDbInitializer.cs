namespace Baby.Models
{
	using System;
	using System.IO;
	using System.Data.Entity;

	public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
		protected override void Seed( ApplicationDbContext context )
		{
			AddAdminUser( context );
			ReadAndInsertCountries( context );

			base.Seed( context );
		}

		/*
		 * NOTE: This function has no exception handling due to its seldome use.  So two common exceptions would be:
		 *		1 - The countries.csv file has lines with more than one (1) comma
		 *		2 - The countries.csv file has country names greater than 50 characters
		*/
		protected void ReadAndInsertCountries( ApplicationDbContext context )
		{
			using ( Stream stream = this.GetType().Assembly.GetManifestResourceStream( "Baby.ViewResources.countries.csv" ) )
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

		protected void AddAdminUser( ApplicationDbContext context )
		{

		}
	}
}
