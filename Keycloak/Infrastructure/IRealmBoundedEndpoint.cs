namespace Keycloak.Infrastructure
{
	public interface IRealmBoundedEndpoint
	{
		string RealmName { get; }
	}
}