using System.Collections.Generic;
using Keycloak.Core.Models.Clients;
using Keycloak.Core.Models.Users;

namespace Keycloak.WebClient.ViewModels.Home
{
	public class HomeViewModel
	{
		#region Properties

		public User Me { get; set; }
		
		public IEnumerable<Client> Clients { get; set; }
		
		public IEnumerable<User> Users { get; set; }

		#endregion
	}
}