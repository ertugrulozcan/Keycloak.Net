using System.Net.Http;
using Keycloak.Helpers;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Clients
{
	public sealed class ClientsEndpoint : 
		AuthorizedRealmBoundedEndpoint<ClientsEndpoint.EndpointUrlParams>, 
		IHasGet<ClientsEndpoint.EndpointUrlParams>, 
		IHasPost<ClientsEndpoint.EndpointUrlParams>, 
		IHasPut<ClientsEndpoint.EndpointUrlParams>, 
		IHasDelete<ClientsEndpoint.EndpointUrlParams>
	{
		#region Constants

		private const string CLIENT_ID_TAG = "CLIENT_ID";

		#endregion
		
		#region Properties

		public override string SelfPath
		{
			get
			{
				return $"/clients/{CLIENT_ID_TAG.ToUrlParam()}";
			}
		}

		#endregion

		#region Sub Endpoints

		public ClientSecretEndpoint ClientSecret { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmSlug"></param>
		public ClientsEndpoint(string baseUrl, string realmSlug) : base(baseUrl, realmSlug)
		{
			this.ClientSecret = new ClientSecretEndpoint(this);
		}

		#endregion

		#region Methods

		public IResponseResult Get(EndpointUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Get, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Get<T>(EndpointUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, urlParams, body, queryString, headers);
		}
		
		public IResponseResult Post(EndpointUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Post, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Post<T>(EndpointUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Post, urlParams, body, queryString, headers);
		}
		
		public IResponseResult Put(EndpointUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Put, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Put<T>(EndpointUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Put, urlParams, body, queryString, headers);
		}
		
		public IResponseResult Delete(EndpointUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Delete, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Delete<T>(EndpointUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Delete, urlParams, body, queryString, headers);
		}

		#endregion
		
		#region QueryParams

		public class EndpointUrlParams : UrlParamsBase
		{
			public EndpointUrlParams SetClientId(string clientId)
			{
				this.SetKeyValue(CLIENT_ID_TAG, clientId);
				return this;
			}
		}

		#endregion
	}
}