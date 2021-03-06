using System;
using System.Collections.Generic;
using System.Linq;
using Keycloak.Helpers;

namespace Keycloak.Rest.Models
{
	public static class HeaderCollection
	{
		public static IHeaderCollection Add(string key, object value)
		{
			return new RequestHeaders(new Dictionary<string, object> { { key, value } });
		}
	}
	
	public interface IHeaderCollection : IDictionary<string, object>
	{
		IHeaderCollection AddHeader(string key, object value);

		IHeaderCollection AddHeader(KeyValuePair<string, object> pair);
		
		IHeaderCollection RemoveHeader(string key);
	}
	
	public class RequestHeaders : Dictionary<string, object>, IHeaderCollection
	{
		#region Constructors

		/// <summary>
		/// Constructor 1
		/// </summary>
		internal RequestHeaders() : this(new Dictionary<string, object>())
		{ }
		
		/// <summary>
		/// Constructor 2
		/// </summary>
		/// <param name="dictionary"></param>
		internal RequestHeaders(Dictionary<string, object> dictionary) : base(dictionary)
		{
			
		}

		#endregion

		#region Methods

		public IHeaderCollection AddHeader(string key, object value)
		{
			if (!this.ContainsKey(key))
				this.Add(key, value);
			else
				this[key] = value;
			
			return this;
		}

		public IHeaderCollection AddHeader(KeyValuePair<string, object> pair)
		{
			return this.AddHeader(pair.Key, pair.Value);
		}

		public IHeaderCollection RemoveHeader(string key)
		{
			if (this.ContainsKey(key))
			{
				this.Remove(key);
			}

			return this;
		}

		public override string ToString()
		{
			return string.Join("&", this.Select(x => $"{x.Key}={Uri.EscapeUriString(StringHelper.ToStringAsRestFormat(x.Value))}"));
		}

		#endregion
	}
}