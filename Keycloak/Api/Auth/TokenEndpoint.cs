using System.Collections.Generic;
using System.Net.Http;
using Keycloak.Core.Models.Realms;
using Keycloak.Helpers;
using Keycloak.Infrastructure;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Auth
{
	public class TokenEndpoint : UnboundedEndpoint<TokenEndpoint.TUrlParams>, IHasPost
	{
		#region Constants

		private const string REALM_NAME_TAG = "REALM_NAME";
		private const string PROTOCOL_TYPE_TAG = "PROTOCOL_TYPE";

		#endregion
		
		#region Properties

		public override string Slug
		{
			get
			{
				return $"/auth/realms/{REALM_NAME_TAG.ToUrlParam()}/protocol/{PROTOCOL_TYPE_TAG.ToUrlParam()}/token";
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		public TokenEndpoint(string baseUrl) : base(baseUrl)
		{
			
		}

		#endregion

		#region Methods

		public IResponseResult<T> Post<T>(RequestBody body = null, IDictionary<string, object> parameters = null, IDictionary<string, object> headers = null)
		{
			return this.ExecuteRequest<T>(HttpMethod.Post, body, parameters, headers);
		}

		#endregion

		#region QueryParams

		public sealed class TUrlParams : EndpointUrlParams
		{
			public TUrlParams SetRealm(IRealm realm)
			{
				this.SetKeyValue(REALM_NAME_TAG, realm.ToString());
				return this;
			}
			
			public TUrlParams SetProtocol(ClientProtocol protocol)
			{
				this.SetKeyValue(PROTOCOL_TYPE_TAG, protocol.ToString());
				return this;
			}
		}

		#endregion
	}
}