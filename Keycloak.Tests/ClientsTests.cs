using Keycloak.Api.Clients;
using Keycloak.Core.Models.Clients;
using Keycloak.Core.ResponseModels.Client;
using Keycloak.Rest.Models;
using NUnit.Framework;

namespace Keycloak.Tests
{
	public class ClientsTests : KeycloakUnitTestBase
	{
		[Test]
		public void GetClientsTest()
		{
			ClientsEndpoint clientsEndpoint = new ClientsEndpoint(this.BASE_URL, "master");
			var getClientsResponse = clientsEndpoint.Get<Client[]>(headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"));
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
		
		[Test]
		public void GetClientsWithPaginationTest()
		{
			ClientsEndpoint clientsEndpoint = new ClientsEndpoint(this.BASE_URL, "master");
			var getClientsResponse = clientsEndpoint.Get<Client[]>(
				queryString: QueryString.Add("first", 0).Add("max", 20).Add("search", true),
				headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"));
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
		
		[Test]
		public void GetClientByIdTest()
		{
			ClientsEndpoint clientsEndpoint = new ClientsEndpoint(this.BASE_URL, "master");
			var getClientsResponse = clientsEndpoint.Get<Client>(
				urlParams: ClientsEndpoint.UrlParams.SetClientId("d121d5d0-dc1f-4916-8a9f-f5d19fc60d5b"),
				headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"));
			
			if (getClientsResponse.IsSuccess)
			{
				var client = getClientsResponse.Data;
				Assert.NotNull(client);
				Assert.AreEqual("d121d5d0-dc1f-4916-8a9f-f5d19fc60d5b", client.Id);
			}
			else
			{
				Assert.Fail(getClientsResponse.Message);
			}
		}
		
		[Test]
		public void GetClientSecretTest()
		{
			ClientsEndpoint clientsEndpoint = new ClientsEndpoint(this.BASE_URL, "master");
			
			var getClientSecretResponse = clientsEndpoint.ClientSecret.Get<ClientSecretResponseModel>(
				urlParams: ClientsEndpoint.UrlParams.SetClientId("d121d5d0-dc1f-4916-8a9f-f5d19fc60d5b"),
				headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"));
			
			if (getClientSecretResponse.IsSuccess)
			{
				var clientSecret = getClientSecretResponse.Data;
				Assert.NotNull(clientSecret);
				//Assert.AreEqual(this.Credentials.ClientSecret, clientSecret.Value);
			}
			else
			{
				Assert.Fail(getClientSecretResponse.Message);
			}
		}
	}
}