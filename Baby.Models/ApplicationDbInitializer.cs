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
		private Guid orgId = Guid.NewGuid();
		private Organization org;
		private Guid cnId = Guid.NewGuid();
		private Guid usId = Guid.NewGuid();

		protected override void Seed( ApplicationDbContext context )
		{

			AddCountries( context );
			AddCurrencies( context );
			AddOrganizations( context );
			AddAdvertisers( context );
			AddUsers( context );
			AddRegions( context );
			AddNeedTypes( context );

			base.Seed( context );
		}

		protected void AddOrganizations( ApplicationDbContext context )
		{
			org = new Organization
			{
				OrganizationId = orgId,
				Name = "Operation Renewed Hope",
				OfficialOrganizationId = "USA12345",
				Status = "Accepted",
				ApplicationSubmissionDate = DateTime.UtcNow
			};

			context.Organizations.Add( org );

			org.Addresses.Add( new Address()
			{
				AddressId = Guid.NewGuid(),
				Type = "Work",
				Street = "",
				City = "Raleigh",
				StateOrProvince = "North Carolina",
				PostalCode = "",
				Country = context.Countries.Find( usId )
			} );

			org.Phones.Add( new Phone()
			{
				PhoneId = Guid.NewGuid(),
				Type = "Work",
				CountryCode = "1",
				Number = "910-987-5072"
			} );

			org.Emails.Add( new Email()
			{
				EmailId = Guid.NewGuid(),
				Type = "Work",
				Address = "orhus@aol.com"
			} );

			context.SaveChanges();
		}

		protected void AddAdvertisers( ApplicationDbContext context )
		{
			context.Advertisers.Add( new Advertiser { AdvertiserId = Guid.NewGuid(), Name = "Allstar Global Solutions", About = "We're number 1!!!!!" } );
		}

		/*
		 * NOTE: This function has no exception handling due to its seldome use.  So two common exceptions would be:
		 *		1 - The countries.csv file has lines with more than one (1) comma
		 *		2 - The countries.csv file has country names greater than 50 characters
		*/
		protected void AddCountries( ApplicationDbContext context )
		{
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AF", Name = "Afghanistan" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AX", Name = "Åland Islands" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AL", Name = "Albania" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "DZ", Name = "Algeria" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AS", Name = "American Samoa" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AD", Name = "Andorra" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AO", Name = "Angola" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AI", Name = "Anguilla" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AQ", Name = "Antarctica" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AG", Name = "Antigua and Barbuda" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AR", Name = "Argentina" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AM", Name = "Armenia" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AW", Name = "Aruba" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AU", Name = "Australia" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AT", Name = "Austria" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "AZ", Name = "Azerbaijan" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BS", Name = "Bahamas" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BH", Name = "Bahrain" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BD", Name = "Bangladesh" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BB", Name = "Barbados" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BY", Name = "Belarus" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BE", Name = "Belgium" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BZ", Name = "Belize" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BJ", Name = "Benin" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BM", Name = "Bermuda" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BT", Name = "Bhutan" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BO", Name = "Bolivia (Plurinational State of)" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BQ", Name = "Bonaire (Sint Eustatius and Saba)" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BA", Name = "Bosnia and Herzegovina" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BW", Name = "Botswana" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BV", Name = "Bouvet Island" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BR", Name = "Brazil" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "IO", Name = "British Indian Ocean Territory" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BN", Name = "Brunei Darussalam" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BG", Name = "Bulgaria" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BF", Name = "Burkina Faso" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "BI", Name = "Burundi" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "KH", Name = "Cambodia" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CM", Name = "Cameroon," } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CA", Name = "Canada" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CV", Name = "Cape Verde" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "KY", Name = "Cayman Islands" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CF", Name = "Central African Republic" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "TD", Name = "Chad" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CL", Name = "Chile" } );

			cnId = Guid.NewGuid();
			context.Countries.Add( new Country { CountryId = cnId, Code = "CN", Name = "China" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CX", Name = "Christmas Island" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CC", Name = "Cocos (Keeling) Islands" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CO", Name = "Colombia" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "KM", Name = "Comoros" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CG", Name = "Congo" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CD", Name = "Congo (The Democratic Republic of the)" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CK", Name = "Cook Islands" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CR", Name = "Costa Rica" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CI", Name = "Côte d'Ivoire" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "HR", Name = "Croatia" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CU", Name = "Cuba" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CW", Name = "Curaçao" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CY", Name = "Cyprus" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "CZ", Name = "Czech Republic" } );
			/*			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Denmark,DK" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Djibouti,DJ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Dominica,DM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Dominican Republic,DO" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Ecuador,EC" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Egypt,EG" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "El Salvador,SV" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Equatorial Guinea,GQ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Eritrea,ER" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Estonia,EE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Ethiopia,ET" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Falkland Islands ( Malvinas ), FK" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Faroe Islands, FO" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Fiji, FJ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Finland, FI" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "France, FR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "French Guiana, GF" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "French Polynesia, PF" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "French Southern Territories, TF" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Gabon, GA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Gambia, GM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Georgia, GE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Germany, DE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Ghana, GH" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Gibraltar, GI" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Greece, GR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Greenland, GL" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Grenada, GD" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Guadeloupe, GP" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Guam, GU" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Guatemala, GT" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Guernsey, GG" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Guinea, GN" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Guinea - Bissau, GW" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Guyana, GY" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Haiti, HT" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Heard Island and McDonald Islands, HM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Holy See( Vatican City State ), VA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Honduras, HN" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Hong Kong, HK" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Hungary, HU" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Iceland, IS" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "India, IN" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Indonesia, ID" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Iran( Islamic Republic of ), IR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Iraq, IQ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Ireland, IE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Isle of Man, IM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Israel, IL" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Italy, IT" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Jamaica, JM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Japan, JP" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Jersey, JE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Jordan, JO" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Kazakhstan, KZ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Kenya, KE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Kiribati, KI" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Korea( Democratic People's Republic of),KP" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Korea( Republic of ), KR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Kuwait, KW" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Kyrgyzstan, KG" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Lao People's Democratic Republic,LA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Latvia, LV" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Lebanon, LB" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Lesotho, LS" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Liberia, LR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Libya, LY" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Liechtenstein, LI" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Lithuania, LT" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Luxembourg, LU" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Macao, MO" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Macedonia( The Former Yugoslav Republic of ), MK" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Madagascar, MG" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Malawi, MW" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Malaysia, MY" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Maldives, MV" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Mali, ML" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Malta, MT" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Marshall Islands, MH" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Martinique, MQ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Mauritania, MR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Mauritius, MU" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Mayotte, YT" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Mexico, MX" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Micronesia( Federated States of ), FM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Moldova( Republic of ), MD" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Monaco, MC" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Mongolia, MN" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Montenegro, ME" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Montserrat, MS" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Morocco, MA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Mozambique, MZ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Myanmar, MM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Namibia, NA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Nauru, NR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Nepal, NP" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Netherlands, NL" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "New Caledonia, NC" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "New Zealand, NZ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Nicaragua, NI" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Niger, NE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Nigeria, NG" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Niue, NU" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Norfolk Island, NF" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Northern Mariana Islands, MP" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Norway, NO" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Oman, OM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Pakistan, PK" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Palau, PW" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Palestine( State of ), PS" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Panama, PA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Papua New Guinea, PG" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Paraguay, PY" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Peru, PE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Philippines, PH" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Pitcairn, PN" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Poland, PL" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Portugal, PT" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Puerto Rico, PR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Qatar, QA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Réunion, RE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Romania, RO" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Russian Federation, RU" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Rwanda, RW" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Saint Barthélemy, BL" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Saint Helena( Ascension and Tristan da Cunha ), SH" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Saint Kitts and Nevis, KN" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Saint Lucia, LC" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Saint Martin( French part ), MF" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Saint Pierre and Miquelon, PM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Saint Vincent and the Grenadines, VC" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Samoa, WS" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "San Marino, SM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Sao Tome and Principe, ST" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Saudi Arabia, SA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Senegal, SN" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Serbia, RS" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Seychelles, SC" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Sierra Leone, SL" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Singapore, SG" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Sint Maarten( Dutch part ), SX" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Slovakia, SK" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Slovenia, SI" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Solomon Islands, SB" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Somalia, SO" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "South Africa, ZA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "South Georgia and the South Sandwich Islands, GS" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "South Sudan, SS" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Spain, ES" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Sri Lanka, LK" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Sudan, SD" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Suriname, SR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Svalbard and Jan Mayen, SJ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Swaziland, SZ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Sweden, SE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Switzerland, CH" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Syrian Arab Republic, SY" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Taiwan( Province of China ), TW" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Tajikistan, TJ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Tanzania( United Republic of ), TZ" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Thailand, TH" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Timor - Leste, TL" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Togo, TG" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Tokelau, TK" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Tonga, TO" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Trinidad and Tobago, TT" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Tunisia, TN" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Turkey, TR" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Turkmenistan, TM" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Turks and Caicos Islands, TC" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Tuvalu, TV" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Uganda, UG" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "Ukraine, UA" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "United Arab Emirates, AE" } );
						context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "", Name = "United Kingdom, GB" } );
						*/
			usId = Guid.NewGuid();
			context.Countries.Add( new Country { CountryId = usId, Code = "US", Name = "United States" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "UM", Name = "United States Minor Outlying Islands" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "UY", Name = "Uruguay" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "UZ", Name = "Uzbekistan" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "VU", Name = "Vanuatu" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "VE", Name = "Venezuela (Bolivarian Republic of)" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "VN", Name = "Viet Nam" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "VG", Name = "Virgin Islands (British)" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "VI", Name = "Virgin Islands (U.S.)" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "WF", Name = "Wallis and Futuna" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "EH", Name = "Western Sahara" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "YE", Name = "Yemen" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "ZM", Name = "Zambia" } );
			context.Countries.Add( new Country { CountryId = Guid.NewGuid(), Code = "ZW", Name = "Zimbabwe" } );
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

			userToInsert = new ApplicationUser { UserName = "jmilton", Surname = "Milton", GivenNames = "Jan", Email = "orhus@aol.com", Type=UserType.Organization, Organization = org };
			userManager.Create( userToInsert, "Password@123" );
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