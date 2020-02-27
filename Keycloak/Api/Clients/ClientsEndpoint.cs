using System.Net.Http;
using Keycloak.Helpers;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Clients
{
	public class ClientsEndpoint : RealmBoundedEndpoint<ClientsEndpoint.TUrlParams>, IHasGet, IHasPost, IHasPut, IHasDelete
	{
		#region Constants

		private const string CLIENT_ID_TAG = "CLIENT_ID";

		#endregion
		
		#region Properties

		public override string Slug
		{
			get
			{
				return $"/auth/admin/realms/{this.RealmSlug}/clients/{CLIENT_ID_TAG.ToUrlParam()}";
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmSlug"></param>
		public ClientsEndpoint(string baseUrl, string realmSlug) : base(baseUrl, realmSlug)
		{
			
		}

		#endregion

		#region Methods

		public IResponseResult Get(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Get, body, queryString, headers);
		}
		
		public IResponseResult<T> Get<T>(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, body, queryString, headers);
		}
		
		public IResponseResult Post(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Post, body, queryString, headers);
		}
		
		public IResponseResult<T> Post<T>(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Post, body, queryString, headers);
		}
		
		public IResponseResult Put(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Put, body, queryString, headers);
		}
		
		public IResponseResult<T> Put<T>(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Put, body, queryString, headers);
		}
		
		public IResponseResult Delete(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Delete, body, queryString, headers);
		}
		
		public IResponseResult<T> Delete<T>(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Delete, body, queryString, headers);
		}

		#endregion
		
		#region QueryParams

		public sealed class TUrlParams : EndpointUrlParams
		{
			public TUrlParams SetClientId(string clientId)
			{
				this.SetKeyValue(CLIENT_ID_TAG, clientId);
				return this;
			}
		}

		#endregion
	}
}