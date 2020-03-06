using Keycloak.Api.Auth;
using Keycloak.Boot;
using Keycloak.Core.Models.Auth;
using Keycloak.Extensions.AspNetCore;
using Keycloak.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Keycloak.WebClient
{
	public class Startup
	{
		#region Properties

		public IConfiguration Configuration { get; }

		#endregion
		
		#region Constructors

		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		#endregion
		
		#region Methods

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
				options.Secure = CookieSecurePolicy.SameAsRequest;
			});

			services
				.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options => options.LoginPath = new PathString("/login"));
			
			services.AddCors(options =>
			{
				options.AddPolicy("cors-policy",
					builder =>
					{
						builder
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
					});
			});
			
			// Initializing Keycloak.Net
			var keycloakConfiguration = this.Configuration.GetSection("Keycloak");
			var keycloakOptions = new KeycloakOptions
			{
				BaseUrl = keycloakConfiguration["BaseUrl"],
				MasterRealm = keycloakConfiguration["MasterRealm"]
			};
			
			Bootstrapper bootstrapper = new Bootstrapper(keycloakOptions);
			bootstrapper.InitializeServices(services);
			var serviceProvider = services.BuildServiceProvider();
			
			// Login to keycloak admin
			Credentials keycloakCredentials = new Credentials
			{
				Username = keycloakConfiguration["Username"],
				Password = keycloakConfiguration["Password"],
				ClientId = keycloakConfiguration["ClientId"],
				ClientSecret = keycloakConfiguration["ClientSecret"],
				GrantType = "password"
			};

			IAuthenticationService authenticationService = serviceProvider.GetService<IAuthenticationService>();
			authenticationService.Login(keycloakCredentials, AccessType.Confidential, ClientProtocol.OpenIdConnect);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCors("cors-policy");
			app.UseCookiePolicy();

			app.UseMvc(this.SetRoutes);
		}

		private void SetRoutes(IRouteBuilder routes)
		{
			routes.MapRoute(
				"register",
				"/register",
				new { controller = "Home", action = "Register" });
			
			routes.MapRoute(
				"logout",
				"/logout",
				new { controller = "Home", action = "Logout" });
			
			routes.MapRoute(
				"login",
				"/login",
				new { controller = "Home", action = "Login" });
			
			routes.MapRoute(
				"default",
				"/",
				new { controller = "Home", action = "Index" });
		}
		
		#endregion
	}
}