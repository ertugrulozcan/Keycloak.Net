namespace Keycloak.Services
{
	public abstract class KeycloakServiceBase
	{
		#region Constants

		protected readonly string BASE_URL;
		protected readonly string MASTER_REALM;

		#endregion

		#region Constuctors

		/// <summary>
		/// Constuctor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="masterRealm"></param>
		protected KeycloakServiceBase(string baseUrl, string masterRealm)
		{
			this.BASE_URL = baseUrl;
			this.MASTER_REALM = masterRealm;
		}

		#endregion
	}
}