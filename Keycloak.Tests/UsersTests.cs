using Keycloak.Api.Users;
using Keycloak.Core.Models.Users;
using Keycloak.Rest.Models;
using NUnit.Framework;

namespace Keycloak.Tests
{
	public class UsersTests : KeycloakUnitTestBase
	{
		[Test]
		public void GetUsersTest()
		{
			UsersEndpoint usersEndpoint = new UsersEndpoint(this.BASE_URL, "master");
			var getUsersResponse = usersEndpoint.Get<User[]>(headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"));
			if (getUsersResponse.IsSuccess)
			{
				var users = getUsersResponse.Data;
				Assert.NotNull(users);
			}
			else
			{
				Assert.Fail(getUsersResponse.Message);
			}
		}
		
		[Test]
		public void GetUserByIdTest()
		{
			UsersEndpoint usersEndpoint = new UsersEndpoint(this.BASE_URL, "master");
			var urlParams = new UsersEndpoint.EndpointUrlParams().SetUserId("e60dc75f-8cbb-4f90-a443-96a0e20939f1");
			var getUsersResponse = usersEndpoint.Get<User>(
				urlParams: urlParams,
				headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"));
			
			if (getUsersResponse.IsSuccess)
			{
				var user = getUsersResponse.Data;
				Assert.NotNull(user);
				Assert.AreEqual("e60dc75f-8cbb-4f90-a443-96a0e20939f1", user.Id);
			}
			else
			{
				Assert.Fail(getUsersResponse.Message);
			}
		}
		
		[Test]
		public void GetUsersCountTest()
		{
			UsersEndpoint usersEndpoint = new UsersEndpoint(this.BASE_URL, "master");
			var getUsersCountResponse = usersEndpoint.UsersCount.Get<int>(headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"));
			if (getUsersCountResponse.IsSuccess)
			{
				var usersCount = getUsersCountResponse.Data;
				Assert.NotNull(usersCount);
			}
			else
			{
				Assert.Fail(getUsersCountResponse.Message);
			}
		}
	}
}