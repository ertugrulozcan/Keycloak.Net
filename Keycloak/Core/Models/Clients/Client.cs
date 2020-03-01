using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.Core.Models.Clients
{
	public class Client
	{
		#region Properties

		[JsonProperty("id")]
        public string Id { get; set; }
		
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        
		[JsonProperty("name")]
        public string Name { get; set; }
        
		[JsonProperty("rootUrl")]
		public string RootUrl { get; set; }
		
		[JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }
        
		[JsonProperty("surrogateAuthRequired")]
        public bool SurrogateAuthRequired { get; set; }
        
		[JsonProperty("enabled")]
        public bool Enabled { get; set; }
		
		[JsonProperty("alwaysDisplayInConsole")]
		public bool AlwaysDisplayInConsole { get; set; }

		[JsonProperty("clientAuthenticatorType")]
        public string ClientAuthenticatorType { get; set; }
        
		[JsonProperty("defaultRoles")]
        public string[] DefaultRoles { get; set; }
		
		[JsonProperty("redirectUris")]
		public string[] RedirectUris { get; set; }
        
		[JsonProperty("webOrigins")]
        public object[] WebOrigins { get; set; }
        
		[JsonProperty("notBefore")]
        public int NotBefore { get; set; }
        
		[JsonProperty("bearerOnly")]
        public bool BearerOnly { get; set; }
        
		[JsonProperty("consentRequired")]
        public bool ConsentRequired { get; set; }
        
		[JsonProperty("standardFlowEnabled")]
        public bool StandardFlowEnabled { get; set; }
        
		[JsonProperty("implicitFlowEnabled")]
        public bool ImplicitFlowEnabled { get; set; }
        
		[JsonProperty("directAccessGrantsEnabled")]
        public bool DirectAccessGrantsEnabled { get; set; }
        
		[JsonProperty("serviceAccountsEnabled")]
        public bool ServiceAccountsEnabled { get; set; }
        
		[JsonProperty("publicClient")]
        public bool PublicClient { get; set; }
        
		[JsonProperty("frontchannelLogout")]
        public bool FrontChannelLogout { get; set; }
        
		[JsonProperty("protocol")]
        public string Protocol { get; set; }
        
		[JsonProperty("attributes")]
        public ClientAttributes Attributes { get; set; }
        
		[JsonProperty("authenticationFlowBindingOverrides")]
        public ClientAuthFlowBindingOverrides AuthenticationFlowBindingOverrides { get; set; }
        
		[JsonProperty("fullScopeAllowed")]
        public bool FullScopeAllowed { get; set; }
        
		[JsonProperty("nodeReRegistrationTimeout")]
        public int NodeReregistrationTimeout { get; set; }
        
		[JsonProperty("protocolMappers")]
        public ClientProtocolMapper[] ProtocolMappers { get; set; }
        
		[JsonProperty("defaultClientScopes")]
        public IEnumerable<string> DefaultClientScopes { get; set; }
        
		[JsonProperty("optionalClientScopes")]
        public IEnumerable<string> OptionalClientScopes { get; set; }
        
		[JsonProperty("access")]
        public ClientAccess Access { get; set; }

		#endregion

		#region Methods

		public override string ToString()
		{
			return this.Name;
		}

		#endregion
	}
}