using System.Collections.Generic;
using Keycloak.Api.Users;
using Keycloak.Core.Models.Users;
using Keycloak.Extensions;
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
			var getUsersResponse = usersEndpoint.Get<User>(
				urlParams: UsersEndpoint.UrlParams.SetUserId("d90b30ec-49b9-44cc-94cb-c0a846db6f6c"),
				headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"));
			
			if (getUsersResponse.IsSuccess)
			{
				var user = getUsersResponse.Data;
				Assert.NotNull(user);
				Assert.AreEqual("d90b30ec-49b9-44cc-94cb-c0a846db6f6c", user.Id);
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
		
		[Test]
		public void GetUserCredentialsTest()
		{
			UsersEndpoint usersEndpoint = new UsersEndpoint(this.BASE_URL, "master");
			
			var getUserCredentialsResponse = usersEndpoint.Credentials.Get<UserCredentials[]>(
				headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"), 
				urlParams: UsersEndpoint.UrlParams.SetUserId("d90b30ec-49b9-44cc-94cb-c0a846db6f6c"));
			
			if (getUserCredentialsResponse.IsSuccess)
			{
				var usersCredentials = getUserCredentialsResponse.Data;
				Assert.NotNull(usersCredentials);
			}
			else
			{
				Assert.Fail(getUserCredentialsResponse.Message);
			}
		}
		
		//[Test]
		public void CreateUserTest()
		{
			User user = new User()
			{
				Username = "ertugrul.ozcan",
				FirstName = "Ertuğrul",
				LastName = "Özcan",
				EmailAddress = "ertugrul.ozcan@demirorenteknoloji.com",
				IsEnabled = true,
				TotP = false,
				EmailVerified = false,
				Access = new UserAccess()
				{
					Impersonate = true,
					Manage = true,
					View = true,
					MapRoles = true,
					ManageGroupMembership = true
				},
				Credentials = new List<UserCredentials>
				{
					new UserCredentials
					{
						CredentialType = "password",
						Value = "<PASSWORD>",
						CredentialData = "{\"hashIterations\":27500,\"algorithm\":\"pbkdf2-sha256\"}"
					}
				}
			};
			
			UsersEndpoint usersEndpoint = new UsersEndpoint(this.BASE_URL, "master");
			var createUserResponse = usersEndpoint.Post(
				body: user.ToRequestBody(),
				headers: HeaderCollection.Add("Authorization", $"Bearer {this.Token.AccessToken}"));
			
			if (createUserResponse.IsSuccess)
			{
				Assert.AreEqual(createUserResponse.HttpCode, 201);
			}
			else
			{
				Assert.Fail(createUserResponse.Message);
			}
		}
	}
}