using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Keycloak.WebClient.ViewModels.Home
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }

		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		
		public IEnumerable<SelectListItem> ClientList { set; get; }
		
		[Required(ErrorMessage = "Please select a client!")]
		[Display(Name = "Client")]
		public string ClientId { get; set; }
	}
}