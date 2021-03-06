using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Keycloak.Api.Auth;
using Keycloak.Core.Models.Auth;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Keycloak.Tests
{
	public abstract class KeycloakUnitTestBase
	{
		#region Constants

		protected string BASE_URL { get; private set; }

		#endregion

		#region Properties

		protected Credentials Credentials { get; private set; }
		
		protected AuthorizationToken Token { get; private set; }

		#endregion

		#region Methods

		[SetUp]
		public void Setup()
		{
			var configuration = this.ReadAppSettings("appsettings.json", "Keycloak");
			this.BASE_URL = configuration["BaseUrl"];
			
			this.Credentials = new Credentials()
			{
				Username = configuration["Username"],
				Password = configuration["Password"],
				ClientId = configuration["ClientId"],
				ClientSecret = configuration["ClientSecret"],
				GrantType = "password"
			};
			
			var tokenResult = Authenticator.GetToken(this.BASE_URL, "master", this.Credentials, AccessType.Confidential, ClientProtocol.OpenIdConnect);
			if (tokenResult.IsSuccess)
			{
				var token = tokenResult.Data;
				Assert.NotNull(token);

				this.Token = token;
			}
			else
			{
				Assert.Fail(tokenResult.Message);	
			}
		}

		#endregion
		
		#region Helper Methods

		private Dictionary<string, string> ReadAppSettings(string fileName, string rootSection)
		{
			try
			{
				var builder = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile(fileName, optional: true, reloadOnChange: true);

				IConfigurationRoot configuration = builder.Build();
				var blupointSection = configuration.GetSection(rootSection);
				var apiUrls = blupointSection.GetChildren();
				return apiUrls.ToDictionary(x => x.Key, y => y.Value);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}

		#endregion
	}
}