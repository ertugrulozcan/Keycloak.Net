using System.Security.Authentication;
using Keycloak.Api.Auth;
using Keycloak.Boot;
using Keycloak.Core.Models.Auth;
using Keycloak.Rest.Models;
using Keycloak.Services.Interfaces;

namespace Keycloak.Services
{
	public class AuthenticationService : KeycloakServiceBase, IAuthenticationService
	{
		#region Properties

		private Credentials Credentials { get; set; }
		
		private AuthorizationToken CurrentToken { get; set; }

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="options"></param>
		public AuthenticationService(IKeycloakOptions options) : base(options)
		{
			
		}

		#endregion
		
		#region Methods
		
		public IResponseResult<AuthorizationToken> Login(Credentials credentials, AccessType accessType, ClientProtocol protocol)
		{
			var tokenResponse = Authenticator.GetToken(this.BASE_URL, this.MASTER_REALM, credentials, accessType, protocol);
			if (tokenResponse.IsSuccess)
			{
				this.Credentials = credentials;	
			}
			else
			{
				throw new AuthenticationException(tokenResponse.Message);
			}

			return tokenResponse;
		}

		public IResponseResult<AuthorizationToken> GetToken(AccessType accessType, ClientProtocol protocol)
		{
			if (this.Credentials == null)
			{
				throw new AuthenticationException("You have not logged-in yet!");
			}

			if (this.CurrentToken != null)
			{
				return new ResponseResult<AuthorizationToken>(true, "CurrentToken") { Data = this.CurrentToken };
			}
			
			var tokenResult = Authenticator.GetToken(this.BASE_URL, this.MASTER_REALM, this.Credentials, accessType, protocol);
			if (tokenResult.IsSuccess)
			{
				this.CurrentToken = tokenResult.Data;
			}

			return tokenResult;
		}

		#endregion
	}
}