namespace TestSOA.ServiceModel
{
	using Autofac;
	using TestSOA.Utilities;
	using Topshelf;
	using log4net;

	public static class ApplicationBootstrapper
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(ApplicationBootstrapper));

		public static void Run()
		{
			Bootstrapper.InitLogger();

			var container = Bootstrapper.InitContainer();

			HostFactory.Run(hostConfig =>
			{
				hostConfig.BeforeStartingServices(() => Logger.Info("Starting services..."));
				hostConfig.AfterStartingServices(() => Logger.Info("All services have been started."));
				hostConfig.AfterStoppingServices(() => Logger.Info("All services have been stopped."));

				hostConfig.SetServiceName("ServiceHost");
				hostConfig.SetDisplayName("ServiceHost");
				hostConfig.SetDescription("ServiceHost");

				hostConfig.Service<IApplicationHost>(serviceConfig =>
				{
					serviceConfig.SetServiceName("ApplicationHost");
					serviceConfig.ConstructUsing((name, serviceChannel) => container.Resolve<IApplicationHost>(TypedParameter.From(serviceChannel)));
					serviceConfig.WhenStarted(service => { service.Start(); container.StartAll(); });
					serviceConfig.WhenStopped(service => container.Dispose());
				});

				hostConfig.EnableDashboard();
				hostConfig.RunAsNetworkService();
			});
		}
	}
}
