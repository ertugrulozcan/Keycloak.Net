using System;
using Keycloak.Api.Auth;
using Keycloak.Boot;
using Keycloak.Core.Models.Auth;
using Keycloak.Rest.Models;
using Keycloak.Services.Interfaces;

namespace Keycloak.Services
{
	public class TokenService : KeycloakServiceBase, ITokenService
	{
		#region Services

		private readonly IClientService clientService;

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="clientService"></param>
		/// <param name="options"></param>
		public TokenService(IClientService clientService, IKeycloakOptions options) : base(options)
		{
			this.clientService = clientService;
		}

		#endregion

		#region Methods

		public IResponseResult<AuthorizationToken> GetToken(string clientId, string username, string password)
		{
			var getClientResponse = this.clientService.GetClient(clientId);
			if (getClientResponse.IsSuccess)
			{
				var client = getClientResponse.Data;
				var clientSecretResponse = this.clientService.GetClientSecret(clientId);
				if (clientSecretResponse.IsSuccess)
				{
					return Authenticator.GetToken(
						this.BASE_URL, 
						this.MASTER_REALM, 
						new Credentials
						{
							Username = username,
							Password = password,
							ClientId = client.ClientId,
							ClientSecret = clientSecretResponse.Data,
							GrantType = "password"
						}, 
						AccessType.Confidential, 
						ClientProtocol.OpenIdConnect);	
				}
				else
				{
					return new ResponseResult<AuthorizationToken>(false, "ClientSecret coulld not fetch!") { Exception = new Exception(clientSecretResponse.Message) };
				}			
			}
			else
			{
				return new ResponseResult<AuthorizationToken>(false, getClientResponse.Message);
			}
		}

		#endregion
	}
}