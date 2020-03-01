using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Clients
{
	public class ClientSecretEndpoint : 
		EndpointBase<ClientsEndpoint.IUrlParams>, ISubEndpoint<ClientsEndpoint>,
		IHasGet<ClientsEndpoint.IUrlParams> 
	{
		#region Properties
		
		public ClientsEndpoint ParentEndpoint { get; }
		
		public override string SelfPath
		{
			get
			{
				return $"{this.ParentEndpoint.Path}/client-secret";
			}
		}
		
		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="parentEndpoint"></param>
		public ClientSecretEndpoint(ClientsEndpoint parentEndpoint) : base(parentEndpoint.BasePath)
		{
			this.ParentEndpoint = parentEndpoint;
		}
		
		#endregion

		#region Methods

		public IResponseResult Get(ClientsEndpoint.IUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest(HttpMethod.Get, urlParams, body, queryString, headers);
		}
		
		public IResponseResult<T> Get<T>(ClientsEndpoint.IUrlParams urlParams = null, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, urlParams, body, queryString, headers);
		}

		#endregion
	}
}