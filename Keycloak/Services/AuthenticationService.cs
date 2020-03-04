using Keycloak.Api.Auth;
using Keycloak.Core.Models.Auth;
using Keycloak.Rest.Models;
using Keycloak.Services.Interfaces;

namespace Keycloak.Services
{
	public class AuthenticationService : KeycloakServiceBase, IAuthenticationService
	{
		#region Properties

		private Credentials Credentials { get; }

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="masterRealm"></param>
		/// <param name="credentials"></param>
		public AuthenticationService(string baseUrl, string masterRealm, Credentials credentials) : base(baseUrl, masterRealm)
		{
			this.Credentials = credentials;
		}

		#endregion
		
		#region Methods

		public IResponseResult<AuthorizationToken> GetToken(AccessType accessType, ClientProtocol protocol)
		{
			return Authenticator.GetToken(this.BASE_URL, this.MASTER_REALM, this.Credentials, accessType, protocol);
		}

		#endregion
	}
}