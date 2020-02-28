namespace Keycloak.Infrastructure
{
	public interface ISubEndpoint<out TParentEndpoint> : IEndpoint where TParentEndpoint : IEndpoint
	{
		#region Properties

		TParentEndpoint ParentEndpoint { get; }

		#endregion
	}
}