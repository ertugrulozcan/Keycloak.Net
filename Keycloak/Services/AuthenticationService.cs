using System;
using System.Net;
using System.Security.Authentication;
using Keycloak.Api.Auth;
using Keycloak.Api.Users;
using Keycloak.Boot;
using Keycloak.Core.Models.Auth;
using Keycloak.Rest.Models;
using Keycloak.Services.Interfaces;

namespace Keycloak.Services
{
	public class AuthenticationService : KeycloakServiceBase, IAuthenticationService
	{
		#region Endpoints

		private readonly UsersEndpoint usersEndpoint;

		#endregion
		
		#region Properties

		private Credentials Credentials { get; set; }
		
		private AuthorizationToken CurrentToken { get; set; }

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="options"></param>
		public AuthenticationService(IKeycloakOptions options) : base(options)
		{
			this.usersEndpoint = new UsersEndpoint(this.BASE_URL, this.MASTER_REALM);
		}

		#endregion
		
		#region Methods
		
		public IResponseResult<TResult> ExecuteAuthorized<TResult>(Func<AuthorizationToken, IResponseResult<TResult>> action)
		{
			try
			{
				var tokenResult = this.GetToken(AccessType.Confidential, ClientProtocol.OpenIdConnect);
				if (tokenResult.IsSuccess)
				{
					var response = action(tokenResult.Data);
					if (response.IsSuccess)
					{
						return response;
					}
					else if (response.HttpCode == HttpStatusCode.Unauthorized || response.Message == "{\"error\":\"HTTP 401 Unauthorized\"}")
					{
						var refreshTokenResult = this.GetToken(AccessType.Confidential, ClientProtocol.OpenIdConnect, true);
						if (refreshTokenResult.IsSuccess)
						{
							return action(refreshTokenResult.Data);
						}
						else
						{
							throw new AuthenticationException("Critical Error! Admin authentication failed!", new Exception(tokenResult.Message));
						}
					}
					else
					{
						throw new Exception(response.Message);
					}
				}
				else
				{
					throw new AuthenticationException("Critical Error! Admin authentication failed!", new Exception(tokenResult.Message));
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
		
		public IResponseResult<AuthorizationToken> Login(Credentials credentials, AccessType accessType, ClientProtocol protocol)
		{
			var tokenResponse = Authenticator.GetToken(this.BASE_URL, this.MASTER_REALM, credentials, accessType, protocol);
			if (tokenResponse.IsSuccess)
			{
				this.Credentials = credentials;	
			}
			else
			{
				throw new AuthenticationException(tokenResponse.Message);
			}

			return tokenResponse;
		}

		public IResponseResult<AuthorizationToken> GetToken(AccessType accessType, ClientProtocol protocol, bool forceRefreshToken = false)
		{
			if (this.Credentials == null)
			{
				throw new AuthenticationException("You have not logged-in yet!");
			}

			if (!forceRefreshToken && this.CurrentToken != null)
			{
				return new ResponseResult<AuthorizationToken>(true, "CurrentToken") { Data = this.CurrentToken };
			}
			
			var tokenResult = Authenticator.GetToken(this.BASE_URL, this.MASTER_REALM, this.Credentials, accessType, protocol);
			if (tokenResult.IsSuccess)
			{
				this.CurrentToken = tokenResult.Data;
			}

			return tokenResult;
		}

		public IResponseResult Logout(string userId)
		{
			var response = this.ExecuteAuthorized(token => this.usersEndpoint.Logout.Post(
				headers: HeaderCollection.Add("Authorization", $"Bearer {token.AccessToken}"),
				urlParams: UsersEndpoint.UrlParams.SetUserId(userId)));

			if (response.IsSuccess)
				return new ResponseResult(true);
			else
				return new ResponseResult(false, response.Message);
		}
		
		#endregion
	}
}