namespace Keycloak.Api.Auth
{
	public sealed class ClientProtocol
	{
		#region Protocols

		public static ClientProtocol OpenIdConnect = new ClientProtocol("OpenIdConnect", "openid-connect");
		
		public static ClientProtocol Saml = new ClientProtocol("SAML", "saml");

		#endregion
		
		#region Properties

		public string Name { get; }
		
		public string Slug { get; }

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="slug"></param>
		private ClientProtocol(string name, string slug)
		{
			this.Name = name;
			this.Slug = slug;
		}

		#endregion
		
		#region Methods

		public override string ToString()
		{
			return this.Slug;
		}

		#endregion
	}
}