using System.ComponentModel.DataAnnotations;

namespace Keycloak.WebClient.ViewModels.Home
{
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }
		
		[Required]
		[Display(Name = "Name")]
		public string FirstName { get; set; }
		
		[Required]
		[Display(Name = "Surname")]
		public string LastName { get; set; }
		
		[Required]
		[Display(Name = "Email Address")]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }

		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}