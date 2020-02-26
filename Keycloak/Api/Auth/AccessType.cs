namespace Keycloak.Api.Auth
{
	public sealed class AccessType
	{
		#region Protocols

		public static AccessType Public = new AccessType("Public", "public");
		
		public static AccessType Confidential = new AccessType("Confidential", "confidential");
		
		public static AccessType BearerOnly = new AccessType("BearerOnly", "bearer-only");

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
		private AccessType(string name, string slug)
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