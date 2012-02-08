namespace TestSOA.ServiceModel
{
	using Autofac;
	using Topshelf;
	using log4net;

	public static class Application
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(Application));

		public static void Start()
		{
			Bootstrapper.InitLogger();

			using (var container = Bootstrapper.InitContainer())
			{
				HostFactory.Run(hostConfig =>
				{
					hostConfig.BeforeStartingServices(() => Logger.Info("Starting services..."));
					hostConfig.AfterStartingServices(() => Logger.Info("All services have been started."));
					hostConfig.AfterStoppingServices(() => Logger.Info("All services have been stopped."));

					hostConfig.SetServiceName("ServiceHost");
					hostConfig.SetDisplayName("ServiceHost");
					hostConfig.SetDescription("ServiceHost");

					hostConfig.Service<ApplicationHost>(serviceConfig =>
					{
						serviceConfig.SetServiceName("ApplicationHost");
						serviceConfig.ConstructUsing((name, serviceChannel) => container.Resolve<ApplicationHost>(TypedParameter.From(serviceChannel)));
						serviceConfig.WhenStarted(host => host.Start());
						serviceConfig.WhenStopped(host => host.Stop());
					});

					hostConfig.EnableDashboard();
					hostConfig.RunAsNetworkService();
				});
			}
		}
	}
}
