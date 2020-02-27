using Keycloak.Rest.Models;

namespace Keycloak.Infrastructure
{
	public interface IEndpoint
	{
		string Slug { get; }
	}

	public interface IHasGet
	{
		IResponseResult Get(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
		
		IResponseResult<T> Get<T>(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
	}
	
	public interface IHasPost
	{
		IResponseResult Post(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
		
		IResponseResult<T> Post<T>(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
	}
	
	public interface IHasPut
	{
		IResponseResult Put(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
		
		IResponseResult<T> Put<T>(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
	}
	
	public interface IHasDelete
	{
		IResponseResult Delete(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
		
		IResponseResult<T> Delete<T>(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
	}
}