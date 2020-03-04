using System.Collections.Generic;
using Keycloak.Core.Models.Clients;
using Keycloak.Rest.Models;

namespace Keycloak.Services.Interfaces
{
	public interface IClientService
	{
		IResponseResult<IEnumerable<Client>> GetClients(int? skip = null, int? limit = null);
		
		IResponseResult<Client> GetClient(string clientId);

		IResponseResult<string> GetClientSecret(string clientId);
	}
}