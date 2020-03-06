using System;
using Newtonsoft.Json;

namespace Keycloak.Core.ResponseModels
{
	public class ErrorModel
	{
		#region Properties

		[JsonProperty("error")]
		public string Message { get; set; }
		
		[JsonProperty("error_description")]
		public string Description { get; set; }

		#endregion

		#region Methods

		public static bool TryParse(string json, out ErrorModel errorModel)
		{
			try
			{
				errorModel = JsonConvert.DeserializeObject<ErrorModel>(json);
				return true;
			}
			catch
			{
				errorModel = null;
				return false;
			}
		}

		#endregion
	}
}