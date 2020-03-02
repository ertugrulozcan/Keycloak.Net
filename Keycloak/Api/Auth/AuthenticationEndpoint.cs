using Keycloak.Infrastructure;

namespace Keycloak.Api.Auth
{
	public sealed class AuthenticationEndpoint : RealmBoundedEndpoint<AuthenticationEndpoint.IUrlParams>
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
			this.AuthenticatorProviders = new AuthenticatorProvidersEndpoint(this);
		}

		#endregion
		
		#region QueryParams

		public interface IUrlParams : Keycloak.Infrastructure.IUrlParams
		{
			
		}

		public sealed class AuthenticationUrlParams : UrlParamsBase, IUrlParams
		{
			
		}
		
		public static class UrlParams
		{
			
		}

		#endregion
	}
}