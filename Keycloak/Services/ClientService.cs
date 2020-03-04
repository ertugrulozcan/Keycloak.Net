using System.Collections.Generic;
using Keycloak.Api.Clients;
using Keycloak.Boot;
using Keycloak.Core.Models.Clients;
using Keycloak.Core.ResponseModels.Client;
using Keycloak.Rest.Models;
using Keycloak.Services.Interfaces;

namespace Keycloak.Services
{
	public class ClientService : AuthorizedServiceBase, IClientService
	{
		#region Endpoints

		private readonly ClientsEndpoint clientsEndpoint;

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="options"></param>
		/// <param name="authenticationService"></param>
		public ClientService(IKeycloakOptions options, IAuthenticationService authenticationService) : base(options, authenticationService)
		{
			this.clientsEndpoint = new ClientsEndpoint(this.BASE_URL, this.MASTER_REALM);
		}

		#endregion
		
		#region Methods
		
		public IResponseResult<IEnumerable<Client>> GetClients(int? skip = null, int? limit = null)
		{
			return this.ExecuteAuthorized(token =>
			{
				if (skip == null && limit == null)
				{
					return this.clientsEndpoint.Get<IEnumerable<Client>>(headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}"));
				}
				else
				{
					var queryString = QueryString.Add("search", true);
					if (skip != null)
					{
						queryString.Add("first", skip.Value);
					}

					if (limit != null)
					{
						queryString.Add("max", limit.Value);
					}
				
					return this.clientsEndpoint.Get<IEnumerable<Client>>(
						queryString: queryString,
						headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}"));
				}
			});
		}

		public IResponseResult<Client> GetClient(string clientId)
		{
			return this.ExecuteAuthorized(token => this.clientsEndpoint.Get<Client>(
				urlParams: ClientsEndpoint.UrlParams.SetClientId(clientId),
				headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}")));
		}
		
		public IResponseResult<string> GetClientSecret(string clientId)
		{
			return this.ExecuteAuthorized(token =>
			{
				var getClientSecretResponse = this.clientsEndpoint.ClientSecret.Get<ClientSecretResponseModel>(
					urlParams: ClientsEndpoint.UrlParams.SetClientId(clientId),
					headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}"));
			
				if (getClientSecretResponse.IsSuccess)
				{
					var clientSecret = getClientSecretResponse.Data;
					return new ResponseResult<string>(true) { Data = clientSecret.Value };
				}
				else
				{
					return new ResponseResult<string>(false, getClientSecretResponse.Message);
				}
			});
		}

		#endregion
	}
}