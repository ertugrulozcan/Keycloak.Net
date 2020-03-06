using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Console
{
	public class MeEndpoint : AuthorizedRealmBoundedEndpoint<MeEndpoint.IUrlParams>, IHasGet<MeEndpoint.IUrlParams>
	{
		#region Properties
		
		public override string Slug
		{
			get
			{
				return string.Empty;
			}
		}

		public override string SelfPath
		{
			get
			{
				return $"/console/whoami";
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmSlug"></param>
		public MeEndpoint(string baseUrl, string realmSlug) : base(baseUrl, realmSlug)
		{
			
		}

		#endregion

		#region Methods

		public IResponseResult Get(IUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Get, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Get<T>(IUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, urlParams, body, queryString, headers);
		}

		#endregion

		#region QueryParams

		public interface IUrlParams : Keycloak.Infrastructure.IUrlParams
		{
			
		}

		public class MeUrlParams : UrlParamsBase, IUrlParams
		{
			
		}
		
		public static class UrlParams
		{
			
		}
		
		#endregion
	}
}