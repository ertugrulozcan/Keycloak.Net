using Newtonsoft.Json;

namespace Keycloak.Core.Models.Users
{
	public class UserCredentials
	{
		#region Properties

		[JsonProperty("id")]
		public string Id { get; set; }
		
		[JsonProperty("type")]
		public string CredentialType { get; set; }
		
		[JsonProperty("createdDate")]
		public long CreatedDateTimeStamp { get; set; }
		
		[JsonProperty("credentialData")]
		public string CredentialData { get; set; }
		
		[JsonProperty("value")]
		public string Value { get; set; }

		#endregion
	}
}