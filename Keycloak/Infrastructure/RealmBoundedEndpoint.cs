namespace Keycloak.Infrastructure
{
	public abstract class RealmBoundedEndpoint<TUrlParams> : EndpointBase<TUrlParams> where TUrlParams : IUrlParams
	{
		#region Properties

		protected string RealmSlug { get; }

		#endregion

		#region Constructors

		protected RealmBoundedEndpoint(string baseUrl, string realmSlug) : base(baseUrl)
		{
			this.RealmSlug = realmSlug;
		}

		#endregion
	}
}