namespace Baby.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table( "Organization" )]
	public partial class Organization
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
		public Organization()
		{
			Addresses = new HashSet<Address>();
			Donations = new HashSet<Donation>();
			Emails = new HashSet<Email>();
			Needs = new HashSet<Need>();
			OrganizationCurrencies = new HashSet<OrganizationCurrency>();
			Phones = new HashSet<Phone>();
			ApplicationUsers = new HashSet<ApplicationUser>();
		}

		[Key]
		public Guid OrganizationId { get; set; }

		[Required]
		[StringLength( 40 )]
		public string Name { get; set; }

		[Required]
		[StringLength( 20 )]
		[Index( IsUnique = true )]
		public string OfficialOrganizationId { get; set; }

		public byte[] LargeLogo { get; set; }

		public byte[] SmallLogo { get; set; }

		public byte[] WeChatCode { get; set; }

		[StringLength( 30 )]
		public string TimeZoneId { get; set; }

		public DateTime ApplicationSubmissionDate { get; set; }

		public DateTime? ApplicationApproveRejectDate { get; set; }

		[StringLength( 50 )]
		public string RejectionReason { get; set; }

//		public string ProcessedById { get; set; }

		[Required]
		[StringLength( 25 )]
		public string Status { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Address> Addresses { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Donation> Donations { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Email> Emails { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Need> Needs { get; set; }

//		public virtual ApplicationUser ProcessedBy { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<OrganizationCurrency> OrganizationCurrencies { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<Phone> Phones { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
		public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
	}
}
