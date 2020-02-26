namespace Keycloak.Core.Models.Realms
{
	public class Realm : IRealm
	{
		#region Properties

		public string Name { get; }

		#endregion
		
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name"></param>
		protected Realm(string name)
		{
			this.Name = name;
		}

		#endregion

		#region Methods

		public override string ToString()
		{
			return this.Name;
		}

		#endregion
	}
}