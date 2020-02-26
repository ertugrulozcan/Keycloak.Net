using Keycloak.Core.Models.Realms;

namespace Keycloak.Api
{
	public sealed class MasterRealm : Realm
	{
		#region Constructors
		
		public MasterRealm() : base("master")
		{
			
		}
		
		#endregion
	}
}