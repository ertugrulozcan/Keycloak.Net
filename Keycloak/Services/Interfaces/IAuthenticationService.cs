using System;
using Keycloak.Api.Auth;
using Keycloak.Core.Models.Auth;
using Keycloak.Rest.Models;

namespace Keycloak.Services.Interfaces
{
	public interface IAuthenticationService
	{
		IResponseResult<TResult> ExecuteAuthorized<TResult>(Func<AuthorizationToken, IResponseResult<TResult>> action);
		
		IResponseResult<AuthorizationToken> Login(Credentials credentials, AccessType accessType, ClientProtocol protocol);
		
		IResponseResult<AuthorizationToken> GetToken(AccessType accessType, ClientProtocol protocol, bool forceRefreshToken = false);
		
		IResponseResult Logout(string userId);
	}
}