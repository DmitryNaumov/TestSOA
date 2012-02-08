namespace TestSOA.ServiceModel
{
	using Autofac;
	using Topshelf.Configuration.Dsl;
	using Topshelf.Shelving;

	public sealed class ServiceBootstrapper : Bootstrapper<ServiceHost>
	{
		public void InitializeHostedService(IServiceConfigurator<ServiceHost> serviceConfig)
		{
			Bootstrapper.InitLogger();

			var container = Bootstrapper.InitContainer();

			serviceConfig.HowToBuildService(name => container.Resolve<ServiceHost>());
			serviceConfig.WhenStarted(service => service.Start());
			serviceConfig.WhenStopped(service => container.Dispose());
		}
	}
}
