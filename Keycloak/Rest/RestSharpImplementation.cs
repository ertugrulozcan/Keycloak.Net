using System;
using System.Collections.Generic;
using System.Net.Http;
using Keycloak.Extensions;
using Keycloak.Rest.Models;
using RestSharp;
using RequestBody = Keycloak.Rest.Models.RequestBody;

namespace Keycloak.Rest
{
	public class RestSharpImplementation : IRestHandler
	{
		#region Methods

		public IResponseResult<TResult> ExecuteRequest<TResult>(HttpMethod method, string url, RequestBody body, IDictionary<string, object> parameters, IDictionary<string, object> headers)
		{
			var response = this.ExecuteRequest(method, url, body, parameters, headers);
			if (response.IsSuccess)
			{
				return response.Cast(x => Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(x.Data?.ToString()));	
			}
			else
			{
				return response.Cast(x => default(TResult));
			}
		}
		
		public IResponseResult ExecuteRequest(HttpMethod method, string url, RequestBody body, IDictionary<string, object> parameters, IDictionary<string, object> headers)
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new UriFormatException("Api url is null or empty!");
			}
			
			ResponseResult responseResult = null;

			try
			{
				RestClient client = new RestClient(url);
				RestRequest request = new RestRequest(method.ToRestSharpHttpMethod());

				if (headers != null)
				{
					foreach (var header in headers)
					{
						if (!string.IsNullOrEmpty(header.Key) && header.Value != null && !string.IsNullOrEmpty(header.Value.ToString()))
						{
							request.AddHeader(header.Key, header.Value.ToString());
						}
					}
				}

				if (parameters != null)
				{
					foreach (var parameter in parameters)
					{
						if (!string.IsNullOrEmpty(parameter.Key) && parameter.Value != null && !string.IsNullOrEmpty(parameter.Value.ToString()))
						{
							request.AddParameter(parameter.Key, parameter.Value.ToString());
						}
					}
				}

				if (body != null && !string.IsNullOrEmpty(body.Context))
				{
					if (body.Type == RequestBody.BodyTypes.Json)
					{
						request.AddJsonBody(body);
					}
					else if (body.Type == RequestBody.BodyTypes.Xml)
					{
						request.AddXmlBody(body);
					}
					else if (body.Type == RequestBody.BodyTypes.UrlEncoded)
					{
						foreach (var row in body.Context.Split(Environment.NewLine))
						{
							var pair = row.Split(':');
							request.AddParameter(pair[0], pair[1]);
						}
					}
					else
					{
						request.Body = new RestSharp.RequestBody(body.ContentType, body.Context, ParameterType.RequestBody);
					}
				}

				var response = client.Execute(request);
				if (response.IsSuccessful)
				{
					responseResult = new ResponseResult(true, response.Content) { Data = response.Content, RawData = response.RawBytes };
				}
				else
				{
					if (!string.IsNullOrEmpty(response.ErrorMessage))
					{
						responseResult = new ResponseResult(response.StatusCode, response.ErrorMessage);
					}
					else
					{
						responseResult = new ResponseResult(response.StatusCode, response.Content);
					}
				}
			}
			catch (Exception ex)
			{
				responseResult = new ResponseResult(false, ex.Message) { Exception = ex };
			}

			return responseResult;
		}

		#endregion
	}
}