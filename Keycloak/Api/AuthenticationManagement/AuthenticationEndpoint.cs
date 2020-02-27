using Keycloak.Infrastructure;

namespace Keycloak.Api.AuthenticationManagement
{
	public sealed class AuthenticationEndpoint : RealmBoundedEndpoint<AuthenticationEndpoint.TUrlParams>
	{
		#region Properties

		public override string Slug
		{
			get
			{
				return $"/{this.RealmSlug}/authentication";
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

		public sealed class TUrlParams : EndpointUrlParams
		{
			
		}

		#endregion
	}
}