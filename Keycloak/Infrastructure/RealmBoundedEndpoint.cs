namespace Keycloak.Infrastructure
{
	public abstract class RealmBoundedEndpoint<TUrlParams> : EndpointBase<TUrlParams>, IRealmBoundedEndpoint where TUrlParams : IUrlParams
	{
		#region Properties

		public virtual string Slug
		{
			get
			{
				return "/realms";
			}
		}
		
		public string RealmName { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmName"></param>
		protected RealmBoundedEndpoint(string baseUrl, string realmName) : base(baseUrl)
		{
			this.RealmName = realmName;
		}

		#endregion
	}
}