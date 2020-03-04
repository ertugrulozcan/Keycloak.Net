using Keycloak.Api.Auth;
using Keycloak.Core.Models.Auth;
using Keycloak.Rest.Models;

namespace Keycloak.Services.Interfaces
{
	public interface IAuthenticationService
	{
		IResponseResult<AuthorizationToken> Login(Credentials credentials, AccessType accessType, ClientProtocol protocol);
		
		IResponseResult<AuthorizationToken> GetToken(AccessType accessType, ClientProtocol protocol);
	}
}