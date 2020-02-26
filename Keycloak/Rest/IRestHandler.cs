using System.Collections.Generic;
using System.Net.Http;
using Keycloak.Rest.Models;

namespace Keycloak.Rest
{
	public interface IRestHandler
	{
		#region Methods

		IResponseResult<TResult> ExecuteRequest<TResult>(HttpMethod method, string url, RequestBody body, IDictionary<string, object> parameters, IDictionary<string, object> headers);

		IResponseResult ExecuteRequest(HttpMethod method, string url, RequestBody body, IDictionary<string, object> parameters, IDictionary<string, object> headers);
		
		#endregion
	}
}