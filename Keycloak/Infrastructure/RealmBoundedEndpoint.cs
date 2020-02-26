namespace Keycloak.Infrastructure
{
	public abstract class RealmBoundedEndpoint : EndpointBase<RealmBoundedEndpoint.TUrlParams>
	{
		#region Properties

		public string RealmSlug { get; }

		#endregion

		#region Constructors

		protected RealmBoundedEndpoint(string baseUrl, string realmSlug) : base(baseUrl)
		{
			this.RealmSlug = realmSlug;
		}

		#endregion
		
		#region QueryParams

		public sealed class TUrlParams : EndpointUrlParams
		{
			
		}

		#endregion
	}
}