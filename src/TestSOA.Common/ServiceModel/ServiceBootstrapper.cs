namespace TestSOA.ServiceModel
{
	using Autofac;
	using TestSOA.Utilities;
	using Topshelf.Configuration.Dsl;
	using Topshelf.Shelving;

	public sealed class ServiceBootstrapper : Bootstrapper<IServiceHost>
	{
		public void InitializeHostedService(IServiceConfigurator<IServiceHost> serviceConfig)
		{
			Bootstrapper.InitLogger();

			var container = Bootstrapper.InitContainer();

			serviceConfig.ConstructUsing((description, name, serviceChannel) => container.Resolve<IServiceHost>(TypedParameter.From(serviceChannel)));
			serviceConfig.WhenStarted(service => { service.Start(); container.StartAll(); });
			serviceConfig.WhenStopped(service => container.Dispose());
		}
	}
}
