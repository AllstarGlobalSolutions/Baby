using System.Web.Mvc;
using System.Collections.Generic;


namespace Baby.Models.ViewModels
{
	public class ConfigureTwoFactorViewModel
	{
		public string SelectedProvider { get; set; }
		public ICollection<SelectListItem> Providers { get; set; }
	}
}
