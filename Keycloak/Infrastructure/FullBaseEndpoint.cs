using System.Net.Http;
using Keycloak.Rest.Models;

namespace Keycloak.Infrastructure
{
	public abstract class FullBaseEndpoint<TUrlParams> :
		AuthorizedRealmBoundedEndpoint<TUrlParams>, 
		IHasGet<TUrlParams>, 
		IHasPost<TUrlParams>, 
		IHasPut<TUrlParams>, 
		IHasDelete<TUrlParams>
		where TUrlParams : class, IUrlParams
	{
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmSlug"></param>
		protected FullBaseEndpoint(string baseUrl, string realmSlug) : base(baseUrl, realmSlug)
		{
			
		}

		#endregion

		#region Methods

		public IResponseResult Get(TUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Get, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Get<T>(TUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, urlParams, body, queryString, headers);
		}
		
		public IResponseResult Post(TUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Post, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Post<T>(TUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Post, urlParams, body, queryString, headers);
		}
		
		public IResponseResult Put(TUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Put, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Put<T>(TUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Put, urlParams, body, queryString, headers);
		}
		
		public IResponseResult Delete(TUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Delete, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Delete<T>(TUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Delete, urlParams, body, queryString, headers);
		}

		#endregion
	}
}