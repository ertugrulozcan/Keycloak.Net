using Keycloak.Helpers;
using Keycloak.Infrastructure;

namespace Keycloak.Api.Users
{
	public class UsersEndpoint : FullBaseEndpoint<UsersEndpoint.EndpointUrlParams>
	{
		#region Constants

		private const string USER_ID_TAG = "USER_ID";

		#endregion
		
		#region Properties

		public override string SelfPath
		{
			get
			{
				return $"/users/{USER_ID_TAG.ToUrlParam()}";
			}
		}

		#endregion

		#region Sub Endpoints

		public UsersCountEndpoint UsersCount { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmSlug"></param>
		public UsersEndpoint(string baseUrl, string realmSlug) : base(baseUrl, realmSlug)
		{
			this.UsersCount = new UsersCountEndpoint(this);
		}

		#endregion

		#region QueryParams

		public class EndpointUrlParams : UrlParamsBase
		{
			public EndpointUrlParams SetUserId(string userId)
			{
				this.SetKeyValue(USER_ID_TAG, userId);
				return this;
			}
		}

		#endregion
	}
}