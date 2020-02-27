using System.Net.Http;
using Keycloak.Rest.Models;

namespace Keycloak.Rest
{
	public interface IRestHandler
	{
		#region Methods

		IResponseResult<TResult> ExecuteRequest<TResult>(HttpMethod method, string url, RequestBody body, IQueryString queryString, IHeaderCollection headers);

		IResponseResult ExecuteRequest(HttpMethod method, string url, RequestBody body, IQueryString queryString, IHeaderCollection headers);
		
		#endregion
	}
}