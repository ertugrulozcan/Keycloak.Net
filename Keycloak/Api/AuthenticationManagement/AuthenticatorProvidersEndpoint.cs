using System.Collections.Generic;
using System.Net.Http;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.AuthenticationManagement
{
	public sealed class AuthenticatorProvidersEndpoint : RealmBoundedEndpoint, IHasGet
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

		public IResponseResult<T> Get<T>(RequestBody body = null, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Get, body, parameters, headers);
		}

		#endregion
	}
}