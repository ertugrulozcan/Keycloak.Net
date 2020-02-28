using Keycloak.Rest.Models;

namespace Keycloak.Infrastructure
{
	public interface IEndpoint
	{
		string SelfPath { get; }
	}

	public interface IHasGet<in TUrlParams> where TUrlParams : IUrlParams
	{
		IResponseResult Get(TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
		
		IResponseResult<T> Get<T>(TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
	}
	
	public interface IHasPost<in TUrlParams> where TUrlParams : IUrlParams
	{
		IResponseResult Post(TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
		
		IResponseResult<T> Post<T>(TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
	}
	
	public interface IHasPut<in TUrlParams> where TUrlParams : IUrlParams
	{
		IResponseResult Put(TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
		
		IResponseResult<T> Put<T>(TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
	}
	
	public interface IHasDelete<in TUrlParams> where TUrlParams : IUrlParams
	{
		IResponseResult Delete(TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
		
		IResponseResult<T> Delete<T>(TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null);
	}
}