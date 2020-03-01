using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Users
{
	public class CredentialsEndpoint :
		EndpointBase<UsersEndpoint.IUrlParams>, ISubEndpoint<UsersEndpoint>,
		IHasGet<UsersEndpoint.IUrlParams>
	{
		#region Properties
		
		public UsersEndpoint ParentEndpoint { get; }
		
		public override string SelfPath
		{
			get
			{
				return $"{this.ParentEndpoint.Path}/credentials";
			}
		}
		
		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="parentEndpoint"></param>
		public CredentialsEndpoint(UsersEndpoint parentEndpoint) : base(parentEndpoint.BasePath)
		{
			this.ParentEndpoint = parentEndpoint;
		}
		
		#endregion

		#region Methods

		public IResponseResult Get(UsersEndpoint.IUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Get, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Get<T>(UsersEndpoint.IUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, urlParams, body, queryString, headers);
		}

		#endregion
	}
}