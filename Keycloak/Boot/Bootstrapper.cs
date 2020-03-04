using System;
using Keycloak.Ioc;

namespace Keycloak.Boot
{
	public class Bootstrapper
	{
		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="options"></param>
		public Bootstrapper(IKeycloakOptions options)
		{
			ServiceProvider.Current.RegisterInstance(options);
		}

		#endregion
		
		#region Methods

		public void InitializeServices()
		{
			var services = ServiceProvider.Current.GetServiceContracts();
			if (services != null)
			{
				foreach (var serviceContract in services)
				{
					var serviceImpl = ServiceProvider.Current.GetService(serviceContract);
					if (serviceImpl != null)
					{
						Console.WriteLine($"{serviceImpl.GetType().Name} resolved.");
					}
				}
			}
		}

		#endregion
	}
}