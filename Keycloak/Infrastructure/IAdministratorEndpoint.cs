namespace Keycloak.Infrastructure
{
	public interface IAdministratorEndpoint : IAuthorizedEndpoint
	{
		string AdminSlug { get; }
	}
}