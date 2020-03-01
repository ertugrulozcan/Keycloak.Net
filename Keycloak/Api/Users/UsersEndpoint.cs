using Keycloak.Helpers;
using Keycloak.Infrastructure;

namespace Keycloak.Api.Users
{
	public class UsersEndpoint : FullBaseEndpoint<UsersEndpoint.IUrlParams>
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
		
		public CredentialsEndpoint Credentials { get; }

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
			this.Credentials = new CredentialsEndpoint(this);
		}

		#endregion

		#region QueryParams

		public interface IUrlParams : Keycloak.Infrastructure.IUrlParams
		{
			IUrlParams SetUserId(string userId);
		}

		public class UsersUrlParams : UrlParamsBase, IUrlParams
		{
			public IUrlParams SetUserId(string userId)
			{
				this.SetKeyValue(USER_ID_TAG, userId);
				return this;
			}
		}
		
		public static class UrlParams
		{
			public static IUrlParams SetUserId(string userId)
			{
				var urlParams = new UsersUrlParams();
				urlParams.SetUserId(userId);
				return urlParams;
			}
		}
		
		#endregion
	}
}