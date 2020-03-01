using Keycloak.Rest.Models;

namespace Keycloak.Extensions
{
	public static class RequestBodyExtensions
	{
		public static RequestBody ToRequestBody(this object obj)
		{
			if (obj == null)
				return null;
			
			return new RequestBody(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
		}
	}
}