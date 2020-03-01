using Keycloak.Helpers;
using Keycloak.Infrastructure;

namespace Keycloak.Api.Clients
{
	public sealed class ClientsEndpoint : FullBaseEndpoint<ClientsEndpoint.IUrlParams>
	{
		#region Constants

		private const string CLIENT_ID_TAG = "CLIENT_ID";

		#endregion
		
		#region Properties

		public override string SelfPath
		{
			get
			{
				return $"/clients/{CLIENT_ID_TAG.ToUrlParam()}";
			}
		}

		#endregion

		#region Sub Endpoints

		public ClientSecretEndpoint ClientSecret { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <param name="realmSlug"></param>
		public ClientsEndpoint(string baseUrl, string realmSlug) : base(baseUrl, realmSlug)
		{
			this.ClientSecret = new ClientSecretEndpoint(this);
		}

		#endregion

		#region QueryParams
		
		public interface IUrlParams : Keycloak.Infrastructure.IUrlParams
		{
			IUrlParams SetClientId(string clientId);
		}

		public class ClientsUrlParams : UrlParamsBase, IUrlParams
		{
			public IUrlParams SetClientId(string clientId)
			{
				this.SetKeyValue(CLIENT_ID_TAG, clientId);
				return this;
			}
		}
		
		public static class UrlParams
		{
			public static IUrlParams SetClientId(string clientId)
			{
				var urlParams = new ClientsUrlParams();
				urlParams.SetClientId(clientId);
				return urlParams;
			}
		}

		#endregion
	}
}