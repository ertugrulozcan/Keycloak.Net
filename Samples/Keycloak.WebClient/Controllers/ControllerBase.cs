using System;
using Keycloak.Core.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keycloak.WebClient.Controllers
{
	public class ControllerBase : Controller
	{
		#region Constants

		private const string ACCESS_TOKEN_COOKIE_KEY = "ACCESS_TOKEN";

		#endregion
		
		#region Methods

		protected IActionResult ExecuteAuthorized(Func<string, IActionResult> action)
		{
			string token = this.GetSessionToken();
			if (string.IsNullOrEmpty(token))
			{
				return this.Redirect("/login");
			}

			return action(token);
		}

		protected string GetSessionToken()
		{ 
			var cookies = this.HttpContext?.Request?.Cookies;
			if (cookies != null && cookies.ContainsKey(ACCESS_TOKEN_COOKIE_KEY))
			{
				return cookies[ACCESS_TOKEN_COOKIE_KEY];
			}

			return null;
		}
		
		protected void SetSessionToken(string token, DateTime? expireTime = null)
		{
			CookieOptions cookieOptions = new CookieOptions();
			
			if (expireTime.HasValue)  
				cookieOptions.Expires = expireTime.Value;  
			else  
				cookieOptions.Expires = DateTime.Now.AddHours(24);

			cookieOptions.IsEssential = true;
			
			this.HttpContext?.Response?.Cookies?.Append(ACCESS_TOKEN_COOKIE_KEY, token, cookieOptions); 
		}

		protected void RemoveSessionToken()
		{
			this.HttpContext?.Response?.Cookies?.Delete(ACCESS_TOKEN_COOKIE_KEY);
		}

		#endregion
	}
}