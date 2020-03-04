namespace Keycloak.Boot
{
	public interface IKeycloakOptions
	{
		#region Properties

		string BaseUrl { get; }
		
		string MasterRealm { get; }

		#endregion
	}
	
	public class KeycloakOptions : IKeycloakOptions
	{
		#region Properties

		public string BaseUrl { get; set; }
		
		public string MasterRealm { get; set; }

		#endregion
	}
}