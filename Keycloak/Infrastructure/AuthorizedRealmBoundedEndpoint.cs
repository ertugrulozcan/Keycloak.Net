namespace Keycloak.Infrastructure
{
	public abstract class AuthorizedRealmBoundedEndpoint<TUrlParams> : RealmBoundedEndpoint<TUrlParams>, IAdministratorEndpoint where TUrlParams : IUrlParams
	{
		#region Properties
		
		public string AdminSlug
		{
			get
			{
				return "admin";
			}
		}

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmName"></param>
		protected AuthorizedRealmBoundedEndpoint(string baseUrl, string realmName) : base(baseUrl, realmName)
		{
			
		}

		#endregion
	}
}