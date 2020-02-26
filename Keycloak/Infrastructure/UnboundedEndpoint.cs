namespace Keycloak.Infrastructure
{
	public abstract class UnboundedEndpoint<TUrlParams> : EndpointBase<TUrlParams> where TUrlParams : IUrlParams
	{
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="baseUrl"></param>
		protected UnboundedEndpoint(string baseUrl) : base(baseUrl)
		{
			
		}

		#endregion
	}
}