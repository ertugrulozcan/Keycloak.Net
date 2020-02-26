using System;
using System.Net.Http;
using RestSharp;

namespace Keycloak.Extensions
{
	public static class RestSharpExtensions
	{
		public static Method ToRestSharpHttpMethod(this HttpMethod systemHttpMethod)
		{
			if (systemHttpMethod == HttpMethod.Get)
				return Method.GET;
			else if (systemHttpMethod == HttpMethod.Post)
				return Method.POST;
			else if (systemHttpMethod == HttpMethod.Put)
				return Method.PUT;
			else if (systemHttpMethod == HttpMethod.Delete)
				return Method.DELETE;
			else if (systemHttpMethod == HttpMethod.Head)
				return Method.HEAD;
			else if (systemHttpMethod == HttpMethod.Options)
				return Method.OPTIONS;
			else if (systemHttpMethod == HttpMethod.Patch)
				return Method.PATCH;
			else
				throw new Exception("Unknown http method!");
		}
	}
}