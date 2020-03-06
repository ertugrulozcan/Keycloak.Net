using Keycloak.Api.Auth;
using Keycloak.Boot;
using Keycloak.Ioc;
using Keycloak.Services.Interfaces;
using NUnit.Framework;

namespace Keycloak.Tests
{
	public class ServiceTests : KeycloakUnitTestBase
	{
		[Test]
		public void ClientServiceTest()
		{
			var options = new KeycloakOptions
			{
				BaseUrl = this.BASE_URL,
				MasterRealm = "master"
			};
			
			Bootstrapper bootstrapper = new Bootstrapper(options);
			bootstrapper.InitializeServices();

			var authenticationService = ServiceProvider.Current.GetInstance<IAuthenticationService>();
			authenticationService.Login(this.Credentials, AccessType.Confidential, ClientProtocol.OpenIdConnect);
			
			var clientService = ServiceProvider.Current.GetInstance<IClientService>();
			var userService = ServiceProvider.Current.GetInstance<IUserService>();
			var tokenService = ServiceProvider.Current.GetInstance<ITokenService>();

			Assert.NotNull(authenticationService);
			Assert.NotNull(clientService);
			Assert.NotNull(userService);
		}
	}
}