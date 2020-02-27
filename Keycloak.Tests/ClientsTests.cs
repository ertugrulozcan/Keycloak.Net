using Keycloak.Api.Auth;
using Keycloak.Api.Clients;
using Keycloak.Core.Models.Clients;
using Keycloak.Rest.Models;
using NUnit.Framework;

namespace Keycloak.Tests
{
	public class ClientsTests : KeycloakUnitTestBase
	{
		[Test]
		public void GetClientsTest()
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
			
			ClientsEndpoint clientsEndpoint = new ClientsEndpoint(this.BASE_URL, "master");
			var getClientsResponse = clientsEndpoint.Get<Client[]>(headers: HeaderCollection.Add("Authorization", $"Bearer {tokenResult.Data.AccessToken}"));
			if (getClientsResponse.IsSuccess)
			{
				var clients = getClientsResponse.Data;
				Assert.NotNull(clients);
			}
			else
			{
				Assert.Fail(getClientsResponse.Message);
			}
		}
	}
}