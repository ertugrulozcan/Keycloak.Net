using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Auth
{
	public sealed class AuthenticatorProvidersEndpoint : 
		EndpointBase<AuthenticationEndpoint.IUrlParams>, 
		ISubEndpoint<AuthenticationEndpoint>,
		IHasGet<AuthenticationEndpoint.IUrlParams>
	{
		#region Properties

		public AuthenticationEndpoint ParentEndpoint { get; }
		
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
		/// <param name="parentEndpoint"></param>
		public AuthenticatorProvidersEndpoint(AuthenticationEndpoint parentEndpoint) : base(parentEndpoint.BasePath)
		{
			this.ParentEndpoint = parentEndpoint;
		}

		#endregion

		#region Methods

		public IResponseResult Get(AuthenticationEndpoint.IUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Get, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Get<T>(AuthenticationEndpoint.IUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, urlParams, body, queryString, headers);
		}

		#endregion
	}
}