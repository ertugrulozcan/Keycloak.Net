using System.Collections.Generic;
using Keycloak.Core.Models.Users;
using Keycloak.Rest.Models;

namespace Keycloak.Services.Interfaces
{
	public interface IUserService
	{
		IResponseResult<IEnumerable<User>> GetUsers();

		IResponseResult<User> GetUserById(string userId);

		IResponseResult<User> GetUserByUsername(string username);

		IResponseResult<int> GetUsersCount();

		IResponseResult<UserCredentials[]> GetUserCredentials();

		IResponseResult<User> CreateUser(string username, string firstName, string lastName, string emailAddress, string password);
	}
}