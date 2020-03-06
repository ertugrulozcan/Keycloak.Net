using System;
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
			return this.authenticationService.ExecuteAuthorized(action);
		}

		#endregion
	}
}