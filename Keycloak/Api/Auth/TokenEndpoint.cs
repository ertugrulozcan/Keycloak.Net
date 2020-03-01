using System.Net.Http;
using Keycloak.Helpers;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Auth
{
	public sealed class TokenEndpoint : RealmBoundedEndpoint<TokenEndpoint.IUrlParams>, IAuthorizedEndpoint, IHasPost<TokenEndpoint.IUrlParams>
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

		public IResponseResult Post(IUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Post, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Post<T>(IUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Post, urlParams, body, queryString, headers);
		}

		#endregion

		#region QueryParams
		
		public interface IUrlParams : Keycloak.Infrastructure.IUrlParams
		{
			IUrlParams SetProtocol(ClientProtocol protocol);
		}

		public sealed class TokenUrlParams : UrlParamsBase, IUrlParams
		{
			public IUrlParams SetProtocol(ClientProtocol protocol)
			{
				this.SetKeyValue(PROTOCOL_TYPE_TAG, protocol.ToString());
				return this;
			}
		}
		
		public static class UrlParams
		{
			public static IUrlParams SetProtocol(ClientProtocol protocol)
			{
				var urlParams = new TokenUrlParams();
				urlParams.SetProtocol(protocol);
				return urlParams;
			}
		}

		#endregion
	}
}