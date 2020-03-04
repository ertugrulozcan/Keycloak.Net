using Keycloak.Boot;

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
		/// <param name="options"></param>
		protected KeycloakServiceBase(IKeycloakOptions options)
		{
			this.BASE_URL = options.BaseUrl;
			this.MASTER_REALM = options.MasterRealm;
		}

		#endregion
	}
}