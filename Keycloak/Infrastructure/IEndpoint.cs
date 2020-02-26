using System.Collections.Generic;
using Keycloak.Rest.Models;

namespace Keycloak.Infrastructure
{
	public interface IEndpoint
	{
		string Slug { get; }
	}

	public interface IHasGet
	{
		IResponseResult<T> Get<T>(RequestBody body = null, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null);
	}
	
	public interface IHasPost
	{
		IResponseResult<T> Post<T>(RequestBody body = null, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null);
	}
	
	public interface IHasPut
	{
		IResponseResult<T> Put<T>(RequestBody body = null, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null);
	}
	
	public interface IHasDelete
	{
		IResponseResult<T> Delete<T>(RequestBody body = null, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null);
	}
}