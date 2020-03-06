namespace Keycloak.Infrastructure
{
	public interface IRealmBoundedEndpoint
	{
		string Slug { get; }
		
		string RealmName { get; }
	}
}