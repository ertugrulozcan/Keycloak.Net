using Keycloak.Infrastructure;

namespace Keycloak.Api.AuthenticationManagement
{
	public sealed class AuthenticationEndpoint : RealmBoundedEndpoint<AuthenticationEndpoint.EndpointUrlParams>
	{
		#region Properties

		public override string SelfPath
		{
			get
			{
				return $"/{this.RealmName}/authentication";
			}
		}

		#endregion

		#region Endpoints

		public AuthenticatorProvidersEndpoint AuthenticatorProviders { get; }

		#endregion
		
		#region Constructors

		public AuthenticationEndpoint(string baseUrl, string realmSlug) : base(baseUrl, realmSlug)
		{
			
		}

		#endregion
		
		#region QueryParams

		public sealed class EndpointUrlParams : UrlParamsBase
		{
			
		}

		#endregion
	}
}