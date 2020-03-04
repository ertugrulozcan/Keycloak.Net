using System.Collections.Generic;
using System.Net;
using Keycloak.Api.Users;
using Keycloak.Boot;
using Keycloak.Core.Models.Users;
using Keycloak.Extensions;
using Keycloak.Rest.Models;
using Keycloak.Services.Interfaces;

namespace Keycloak.Services
{
	public class UserService : AuthorizedServiceBase, IUserService
	{
		#region Endpoints

		private readonly UsersEndpoint usersEndpoint;

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="options"></param>
		/// <param name="authenticationService"></param>
		public UserService(IKeycloakOptions options, IAuthenticationService authenticationService) : base(options, authenticationService)
		{
			this.usersEndpoint = new UsersEndpoint(this.BASE_URL, this.MASTER_REALM);
		}

		#endregion
		
		#region Methdos

		public IResponseResult<IEnumerable<User>> GetUsers()
		{
			return this.ExecuteAuthorized(token => this.usersEndpoint.Get<IEnumerable<User>>(headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}")));
		}
		
		public IResponseResult<User> GetUserById(string userId)
		{
			return this.ExecuteAuthorized(token => this.usersEndpoint.Get<User>(
				urlParams: UsersEndpoint.UrlParams.SetUserId(userId),
				headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}")));
		}
		
		public IResponseResult<User> GetUserByUsername(string username)
		{
			return this.ExecuteAuthorized(token => this.usersEndpoint.Get<User>(
				headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}"),
				queryString: QueryString.Add("username", username)));
		}
		
		public IResponseResult<int> GetUsersCount()
		{
			return this.ExecuteAuthorized(token => this.usersEndpoint.UsersCount.Get<int>(headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}")));
		}
		
		public IResponseResult<UserCredentials[]> GetUserCredentials()
		{
			return this.ExecuteAuthorized(token => this.usersEndpoint.Credentials.Get<UserCredentials[]>(
				headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}"), 
				urlParams: UsersEndpoint.UrlParams.SetUserId("1294bd3e-c39e-4ac5-a0e2-f126ed7437d6")));
		}
		
		public IResponseResult<User> CreateUser(string username, string firstName, string lastName, string emailAddress, string password)
		{
			User user = new User()
			{
				Username = username,
				FirstName = firstName,
				LastName = lastName,
				EmailAddress = emailAddress,
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
						Value = password,
						CredentialData = "{\"hashIterations\":27500,\"algorithm\":\"pbkdf2-sha256\"}"
					}
				}
			};
			
			return this.ExecuteAuthorized(token =>
			{
				var createUserResponse = this.usersEndpoint.Post(
					body: user.ToRequestBody(),
					headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}"));
			
				if (createUserResponse.IsSuccess && createUserResponse.HttpCode == HttpStatusCode.Created)
				{
					return this.GetUserByUsername(username);
				}
				else
				{
					return new ResponseResult<User>(false, createUserResponse.Message);
				}
			});
		}

		#endregion
	}
}