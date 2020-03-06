using System;
using System.Diagnostics;
using System.Linq;
using Keycloak.Core.ResponseModels;
using Keycloak.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Keycloak.WebClient.Models;
using Keycloak.WebClient.ViewModels.Home;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Keycloak.WebClient.Controllers
{
	public class HomeController : ControllerBase
	{
		#region Services

		private readonly ITokenService tokenService;
		private readonly IAuthenticationService authenticationService;
		private readonly IClientService clientService;
		private readonly IUserService userService;

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="tokenService"></param>
		/// <param name="authenticationService"></param>
		/// <param name="clientService"></param>
		/// <param name="userService"></param>
		public HomeController(ITokenService tokenService, IAuthenticationService authenticationService, IClientService clientService, IUserService userService)
		{
			this.tokenService = tokenService;
			this.authenticationService = authenticationService;
			this.clientService = clientService;
			this.userService = userService;
		}

		#endregion

		#region Home Page

		public IActionResult Index()
		{
			return this.ExecuteAuthorized(token =>
			{
				HomeViewModel homeViewModel = new HomeViewModel();

				string tokenOnCookie = this.GetSessionToken();
				if (string.IsNullOrEmpty(tokenOnCookie))
				{
					return this.Redirect("/login");
				}
				
				var whoAmIResponse = this.userService.WhoAmI(tokenOnCookie);
				if (whoAmIResponse.IsSuccess)
				{
					var sessionUser = whoAmIResponse.Data;
					var meResponse = this.userService.GetUserById(sessionUser.UserId);
					if (meResponse.IsSuccess)
					{
						homeViewModel.Me = meResponse.Data;
					}
				}
				else
				{
					return this.Redirect("/login");
				}
			
				var getClientsResponse = this.clientService.GetClients();
				if (getClientsResponse.IsSuccess)
					homeViewModel.Clients = getClientsResponse.Data;
			
				var getUsersResponse = this.userService.GetUsers();
				if (getUsersResponse.IsSuccess)
					homeViewModel.Users = getUsersResponse.Data;
				
				return this.View(homeViewModel);
			});
		}

		#endregion

		#region Login

		[HttpGet]
		public IActionResult Login()
		{
			try
			{
				var viewModel = this.GenerateLoginViewModel();
				return this.View(viewModel);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				this.ModelState.AddModelError("Error", ex.Message);
				return this.View(new LoginViewModel());
			}
		}
		
		[HttpPost]
		public IActionResult Login(LoginViewModel loginViewModel)
		{
			try
			{
				if(!this.ModelState.IsValid)
				{
					return this.View(loginViewModel);
				}
				
				var loginResult = this.tokenService.GetToken(loginViewModel.ClientId, loginViewModel.Username, loginViewModel.Password);
				if (loginResult.IsSuccess)
				{
					this.SetSessionToken(loginResult.Data.AccessToken);
					return this.RedirectToAction("Index");
				}
				else
				{
					if (ErrorModel.TryParse(loginResult.Message, out ErrorModel err))
					{
						this.ModelState.AddModelError("Error", err.Message);
					}
					else
					{
						this.ModelState.AddModelError("Error", loginResult.Message);
					}
				}
			}
			catch (Exception ex)
			{
				this.ModelState.AddModelError(ex.HResult.ToString(), ex.Message);
			}
			
			try
			{
				var viewModel = this.GenerateLoginViewModel();
				return this.View(viewModel);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				this.ModelState.AddModelError("Error", ex.Message);
				return this.View(new LoginViewModel());
			}
		}

		#endregion
		
		#region Logout

		public IActionResult Logout()
		{
			var whoAmIResponse = this.userService.WhoAmI(this.GetSessionToken());
			if (whoAmIResponse.IsSuccess)
			{
				var sessionUser = whoAmIResponse.Data;
				var logourResult = this.authenticationService.Logout(sessionUser.UserId);
				if (logourResult.IsSuccess)
				{
					this.RemoveSessionToken();
				}
			}

			return this.Redirect("/login");
		}

		#endregion
		
		#region Register

		[HttpGet]
		public IActionResult Register()
		{
			return this.View(new RegisterViewModel());
		}
		
		[HttpPost]
		public IActionResult Register(RegisterViewModel viewModel)
		{
			try
			{
				if(!this.ModelState.IsValid)
				{
					return this.View(viewModel);
				}
				
				var registerResponse = this.userService.CreateUser(
					viewModel.Username,
					viewModel.FirstName,
					viewModel.LastName,
					viewModel.EmailAddress,
					viewModel.Password);

				if (registerResponse.IsSuccess)
				{
					return this.RedirectToAction("Login");
				}
				else
				{
					this.ModelState.AddModelError("Error", registerResponse.Message);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				this.ModelState.AddModelError(ex.HResult.ToString(), ex.Message);
			}
			
			return this.View(viewModel);
		}

		#endregion
		
		#region Methods

		private LoginViewModel GenerateLoginViewModel()
		{
			var getClientsResponse = this.clientService.GetClients();
			if (getClientsResponse.IsSuccess)
			{
				var clients = getClientsResponse.Data;
				LoginViewModel viewModel = new LoginViewModel
				{
					ClientList = clients.Select(x => new SelectListItem(x.Name, x.Id))
				};
					
				return viewModel;
			}
			else
			{
				throw new Exception(getClientsResponse.Message);
			}
		}
		
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
		}

		#endregion
	}
}