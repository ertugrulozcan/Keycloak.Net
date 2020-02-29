using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Users
{
	public class UsersCountEndpoint : 
		EndpointBase<UsersCountEndpoint.EndpointUrlParams>, ISubEndpoint<UsersEndpoint>,
		IHasGet<UsersCountEndpoint.EndpointUrlParams> 
	{
		#region Properties
		
		public UsersEndpoint ParentEndpoint { get; }
		
		public override string SelfPath
		{
			get
			{
				return $"{this.ParentEndpoint.Path}/count";
			}
		}
		
		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="parentEndpoint"></param>
		public UsersCountEndpoint(UsersEndpoint parentEndpoint) : base(parentEndpoint.BasePath)
		{
			this.ParentEndpoint = parentEndpoint;
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

		#endregion
		
		#region QueryParams

		public sealed class EndpointUrlParams : UsersEndpoint.EndpointUrlParams
		{
			
		}

		#endregion
	}
}