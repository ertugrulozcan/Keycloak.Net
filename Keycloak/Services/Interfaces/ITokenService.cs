using Keycloak.Core.Models.Auth;
using Keycloak.Rest.Models;

namespace Keycloak.Services.Interfaces
{
	public interface ITokenService
	{
		IResponseResult<AuthorizationToken> GetToken(string clientId, string username, string password);
	}
}