using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.AuthenticationManagement
{
	public sealed class AuthenticatorProvidersEndpoint : RealmBoundedEndpoint<AuthenticatorProvidersEndpoint.TUrlParams>, IHasGet
	{
		#region Properties

		public override string Slug
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

		public IResponseResult Get(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Get, body, queryString, headers);
		}
		
		public IResponseResult<T> Get<T>(RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, body, queryString, headers);
		}

		#endregion
		
		#region QueryParams

		public sealed class TUrlParams : EndpointUrlParams
		{
			
		}

		#endregion
	}
}