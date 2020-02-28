using System.Net.Http;
using Keycloak.Helpers;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Auth
{
	public sealed class TokenEndpoint : RealmBoundedEndpoint<TokenEndpoint.EndpointUrlParams>, IAuthorizedEndpoint, IHasPost<TokenEndpoint.EndpointUrlParams>
	{
		#region Constants
		
		private const string PROTOCOL_TYPE_TAG = "PROTOCOL_TYPE";

		#endregion
		
		#region Properties

		public override string SelfPath
		{
			get
			{
				return $"/protocol/{PROTOCOL_TYPE_TAG.ToUrlParam()}/token";
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmSlug"></param>
		public TokenEndpoint(string baseUrl, string realmSlug) : base(baseUrl, realmSlug)
		{
			
		}

		#endregion

		#region Methods

		public IResponseResult Post(EndpointUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Post, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Post<T>(EndpointUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Post, urlParams, body, queryString, headers);
		}

		#endregion

		#region QueryParams

		public sealed class EndpointUrlParams : UrlParamsBase
		{
			public EndpointUrlParams SetProtocol(ClientProtocol protocol)
			{
				this.SetKeyValue(PROTOCOL_TYPE_TAG, protocol.ToString());
				return this;
			}
		}

		#endregion
	}
}