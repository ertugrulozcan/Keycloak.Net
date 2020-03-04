using System;
using System.Security.Authentication;
using Keycloak.Api.Auth;
using Keycloak.Boot;
using Keycloak.Core.Models.Auth;
using Keycloak.Rest.Models;
using Keycloak.Services.Interfaces;

namespace Keycloak.Services
{
	public abstract class AuthorizedServiceBase : KeycloakServiceBase
	{
		#region Services

		private readonly IAuthenticationService authenticationService;

		#endregion

		#region Constuctors

		/// <summary>
		/// Constuctor
		/// </summary>
		/// <param name="options"></param>
		/// <param name="authenticationService"></param>
		protected AuthorizedServiceBase(IKeycloakOptions options, IAuthenticationService authenticationService) : base(options)
		{
			this.authenticationService = authenticationService;
		}

		#endregion

		#region Methods

		protected IResponseResult<TResult> ExecuteAuthorized<TResult>(Func<AuthorizationToken, IResponseResult<TResult>> action)
		{
			try
			{
				var response = action(this.GetToken());
				return response;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		private AuthorizationToken GetToken()
		{
			var tokenResult = this.authenticationService.GetToken(AccessType.Confidential, ClientProtocol.OpenIdConnect);
			if (tokenResult.IsSuccess)
			{
				return tokenResult.Data;	
			}
			else
			{
				throw new AuthenticationException("Critical Error! Admin authentication failed!", new Exception(tokenResult.Message));
			}
		}

		#endregion
	}
}