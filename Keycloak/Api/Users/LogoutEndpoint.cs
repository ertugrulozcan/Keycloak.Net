using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Users
{
	public class LogoutEndpoint :
		EndpointBase<UsersEndpoint.IUrlParams>, ISubEndpoint<UsersEndpoint>,
		IHasPost<UsersEndpoint.IUrlParams> 
	{
		#region Properties
		
		public UsersEndpoint ParentEndpoint { get; }
		
		public override string SelfPath
		{
			get
			{
				return $"{this.ParentEndpoint.Path}/logout";
			}
		}
		
		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="parentEndpoint"></param>
		public LogoutEndpoint(UsersEndpoint parentEndpoint) : base(parentEndpoint.BasePath)
		{
			this.ParentEndpoint = parentEndpoint;
		}
		
		#endregion

		#region Methods

		public IResponseResult Post(UsersEndpoint.IUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Post, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Post<T>(UsersEndpoint.IUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Post, urlParams, body, queryString, headers);
		}

		#endregion
	}
}