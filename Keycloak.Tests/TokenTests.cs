using Keycloak.Api.Auth;
using NUnit.Framework;

namespace Keycloak.Tests
{
	public class TokenTests : KeycloakUnitTestBase
	{
		[Test]
		public void GetTokenTest()
		{
			var tokenResult = Authenticator.GetToken(BASE_URL, this.Credentials, AccessType.Confidential, ClientProtocol.OpenIdConnect);
			if (tokenResult.IsSuccess)
			{
				var token = tokenResult.Data;
				Assert.NotNull(token);
			}
			else
			{
				Assert.Fail(tokenResult.Message);	
			}
		}
	}
}                                                                               