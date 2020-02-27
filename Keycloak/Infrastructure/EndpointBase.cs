using System;
using System.Net.Http;
using Keycloak.Helpers;
using Keycloak.Rest.Models;
using Keycloak.Rest;

namespace Keycloak.Infrastructure
{
	public abstract class EndpointBase<TUrlParams> : IEndpoint where TUrlParams : IUrlParams
	{
		#region Properties

		private IRestHandler RestHandler { get; }
		
		public string BaseUrl { get; }
		
		public abstract string Slug { get; }
		
		public TUrlParams UrlParams { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		protected EndpointBase(string baseUrl)
		{
			this.BaseUrl = baseUrl;
			this.RestHandler = new RestSharpImplementation();
			this.UrlParams = Activator.CreateInstance<TUrlParams>();
		}

		#endregion

		#region Methods

		protected IResponseResult ExecuteRequest(HttpMethod method, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			string url = this.GenerateUrl();
			return this.RestHandler.ExecuteRequest(method, url, body, queryString, headers);
		}
		
		protected IResponseResult<T> ExecuteRequest<T>(HttpMethod method, RequestBody body = null, IQueryString queryString = null, IHeaderCollection headers = null)
		{
			string url = this.GenerateUrl();
			return this.RestHandler.ExecuteRequest<T>(method, url, body, queryString, headers);
		}

		private string GenerateUrl()
		{
			string url = $"{this.BaseUrl.TrimEnd('/')}/{this.Slug.TrimStart('/')}";

			foreach (var urlParam in this.UrlParams.UrlParamsDictionary)
			{
				url = UrlHelper.ReplaceOrRemove(url, urlParam.Key, urlParam.Value);
			}

			url = UrlHelper.ClearTags(url);
			
			return url;
		}

		#endregion
	}
}