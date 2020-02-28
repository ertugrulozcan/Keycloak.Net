using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.AuthenticationManagement
{
	public sealed class AuthenticatorProvidersEndpoint : RealmBoundedEndpoint<AuthenticatorProvidersEndpoint.EndpointUrlParams>, IHasGet<AuthenticatorProvidersEndpoint.EndpointUrlParams>
	{
		#region Properties

		public override string SelfPath
		{
			get
			{
				return "authenticator-providers";
			}
		}

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmSlug"></param>
		public AuthenticatorProvidersEndpoint(string baseUrl, string realmSlug) : base(baseUrl, realmSlug)
		{
			
		}

		#endregion

		#region Methods

		public IResponseResult Get(EndpointUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Get, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Get<T>(EndpointUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, urlParams, body, queryString, headers);
		}

		#endregion
		
		#region QueryParams

		public sealed class EndpointUrlParams : UrlParamsBase
		{
			
		}

		#endregion
	}
}