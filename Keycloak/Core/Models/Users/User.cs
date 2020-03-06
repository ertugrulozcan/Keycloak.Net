using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Core.Models.Users
{
	public class User
	{
		#region Properties

		[JsonProperty("id")]
		public string Id { get; set; }
		
		[JsonProperty("createdTimestamp")]
		public long CreatedAtTimeStamp { get; set; }

		[JsonProperty("username")]
		public string Username { get; set; }
		
		[JsonProperty("firstName")]
		public string FirstName { get; set; }
		
		[JsonProperty("lastName")]
		public string LastName { get; set; }

		[JsonProperty("email")]
		public string EmailAddress { get; set; }
		
		[JsonProperty("enabled")]
		public bool IsEnabled { get; set; }
		
		[JsonProperty("totp")]
		public bool TotP { get; set; }
		
		[JsonProperty("emailVerified")]
		public bool EmailVerified { get; set; }
		
		[JsonProperty("disableableCredentialTypes")]
		public object[] DisableableCredentialTypes { get; set; }
		
		[JsonProperty("requiredActions")]
		public object[] RequiredActions { get; set; }
		
		[JsonProperty("notBefore")]
		public int NotBefore { get; set; }
		
		[JsonProperty("access")]
		public UserAccess Access { get; set; }

		[JsonProperty("credentials")]
		public IEnumerable<UserCredentials> Credentials { get; set; }

		[JsonIgnore]
		public string FullName
		{
			get
			{
				return $"{this.FirstName} {this.LastName}";
			}
		}
		
		#endregion
	}
}