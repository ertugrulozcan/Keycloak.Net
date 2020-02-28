using Newtonsoft.Json;

namespace Keycloak.Core.ResponseModels.Client
{
	public class ClientSecretResponseModel
	{
		#region Properties

		[JsonProperty("type")]
        public string Type { get; set; }
		
        [JsonProperty("value")]
        public string Value { get; set; }

		#endregion

		#region Methods

		public override string ToString()
		{
			return this.Value;
		}

		#endregion
	}
}