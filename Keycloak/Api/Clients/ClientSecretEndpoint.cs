using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Clients
{
	public class ClientSecretEndpoint : 
		EndpointBase<ClientSecretEndpoint.EndpointUrlParams>, ISubEndpoint<ClientsEndpoint>,
		IHasGet<ClientSecretEndpoint.EndpointUrlParams> 
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

		public sealed class EndpointUrlParams : ClientsEndpoint.EndpointUrlParams
		{
			
		}

		#endregion
	}
}