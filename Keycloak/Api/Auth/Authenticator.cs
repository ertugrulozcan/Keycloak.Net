using System;
using System.Collections.Generic;
using Keycloak.Core.Models.Auth;
using Keycloak.Rest.Models;

namespace Keycloak.Api.Auth
{
	public sealed class Authenticator
	{
		#region Singleton

		private static Authenticator self;

		public static Authenticator Current
		{
			get
			{
				if (self == null)
				{
					self = new Authenticator();
				}

				return self;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		private Authenticator()
		{
			
		}

		#endregion
		
		#region Methods

		public static IResponseResult<AuthorizationToken> GetToken(string baseUrl, Credentials credentials)
		{
			return GetToken(baseUrl, credentials, AccessType.Confidential, ClientProtocol.OpenIdConnect);
		}
		
		public static IResponseResult<AuthorizationToken> GetToken(string baseUrl, Credentials credentials, AccessType accessType, ClientProtocol protocol)
		{
			if (accessType == AccessType.Confidential)
			{
				return GetTokenAsConfidential(baseUrl, credentials, protocol);
			}
			
			if (accessType == AccessType.Public)
			{
				return GetTokenAsPublic(baseUrl, credentials, protocol);
			}
			
			if (accessType == AccessType.BearerOnly)
			{
				return GetTokenAsBearerOnly(baseUrl, credentials, protocol);
			}
			
			throw new Exception("Unknown access type!");
		}

		private static IResponseResult<AuthorizationToken> GetTokenAsConfidential(string baseUrl, Credentials credentials, ClientProtocol protocol)
		{
			var body = RequestBody.CreateUrlEncoded(new Dictionary<string, string>
			{
				{ "username", credentials.Username },
				{ "password", credentials.Password },
				{ "grant_type", credentials.GrantType },
				{ "client_id", credentials.ClientId },
				{ "client_secret", credentials.ClientSecret },
			});

			var tokenEndpoint = new TokenEndpoint(baseUrl);
			tokenEndpoint.UrlParams
				.SetRealm(new MasterRealm())
				.SetProtocol(protocol);

			return tokenEndpoint.Post<AuthorizationToken>(body, null, HeaderCollection.Add("Content-Type", "application/x-www-form-urlencoded"));
		}
		
		private static IResponseResult<AuthorizationToken> GetTokenAsPublic(string baseUrl, Credentials credentials, ClientProtocol protocol)
		{
			throw new NotImplementedException();
		}
		
		private static IResponseResult<AuthorizationToken> GetTokenAsBearerOnly(string baseUrl, Credentials credentials, ClientProtocol protocol)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}