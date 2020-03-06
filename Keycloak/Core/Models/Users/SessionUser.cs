using Newtonsoft.Json;

namespace Keycloak.Core.Models.Users
{
	public class SessionUser
	{
		[JsonProperty("userId")]
		public string UserId { get; set; }
		
		[JsonProperty("realm")]
		public string RealmName { get; set; }
		
		[JsonProperty("displayName")]
		public string DisplayName { get; set; }
	}
}