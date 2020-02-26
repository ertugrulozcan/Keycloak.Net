using Newtonsoft.Json;

namespace Keycloak.Core.Models.Auth
{
	public class Credentials
	{
		#region Properties

		[JsonProperty("username")]
		public string Username { get; set; }
		
		[JsonProperty("password")]
		public string Password { get; set; }
		
		[JsonProperty("grant_type")]
		public string GrantType { get; set; }
		
		[JsonProperty("client_id")]
		public string ClientId { get; set; }
		
		[JsonProperty("client_secret")]
		public string ClientSecret { get; set; }

		#endregion
	}
}