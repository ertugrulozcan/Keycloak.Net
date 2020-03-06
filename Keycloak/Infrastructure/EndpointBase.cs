using System.Collections.Generic;
using System.Net.Http;
using Keycloak.Helpers;
using Keycloak.Rest.Models;
using Keycloak.Rest;

namespace Keycloak.Infrastructure
{
	public abstract class EndpointBase<TUrlParams> : IEndpoint where TUrlParams : IUrlParams
	{
		#region Fields

		public readonly string BasePath;

		#endregion
		
		#region Properties

		private IRestHandler RestHandler { get; }

		public abstract string SelfPath { get; }

		public string Path
		{
			get
			{
				return this.GetPath();
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="basePath"></param>
		protected EndpointBase(string basePath)
		{
			this.BasePath = basePath;
			this.RestHandler = new RestSharpImplementation();
			//this.UrlParams = Activator.CreateInstance<TUrlParams>();
		}

		#endregion

		#region Methods

		private string GetPath()
		{
			var sections = new List<string>();
			if (this is IAuthorizedEndpoint)
				sections.Add($"/auth");
			if (this is IAdministratorEndpoint administratorEndpoint)
				sections.Add($"/{administratorEndpoint.AdminSlug}");
			if (this is IRealmBoundedEndpoint realmBoundedEndpoint)
				sections.Add($"{realmBoundedEndpoint.Slug}/{realmBoundedEndpoint.RealmName}");
				
			string path = string.Join(string.Empty, sections);
			string url = UrlHelper.ClearRepeatedSlashes($"{path}/{this.SelfPath}");

			return url;
		}

		protected IResponseResult ExecuteRequest(HttpMethod method, TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			string url = this.GenerateUrl(urlParams);
			return this.RestHandler.ExecuteRequest(method, url, body, queryString, headers);
		}
		
		protected IResponseResult<T> ExecuteRequest<T>(HttpMethod method, TUrlParams urlParams, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			string url = this.GenerateUrl(urlParams);
			return this.RestHandler.ExecuteRequest<T>(method, url, body, queryString, headers);
		}

		private string GenerateUrl(TUrlParams urlParams)
		{
			string url = $"{this.BasePath.TrimEnd('/')}/{this.GetPath().TrimStart('/')}";

			if (urlParams != null)
			{
				foreach (var urlParam in urlParams.UrlParamsDictionary)
				{
					url = UrlHelper.ReplaceOrRemove(url, urlParam.Key, urlParam.Value);
				}	
			}

			url = UrlHelper.ClearTags(url);
			
			return url;
		}

		#endregion
	}
}