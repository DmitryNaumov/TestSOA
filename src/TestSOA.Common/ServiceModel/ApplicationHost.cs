namespace TestSOA.ServiceModel
{
	using TestSOA.ComponentModel;
	using Topshelf.FileSystem;
	using Topshelf.Messages;
	using Topshelf.Model;

	[ComponentLifetime(ComponentLifetimeScope.SingleInstance)]
	internal sealed class ApplicationHost : IApplicationHost
	{
		private readonly IServiceChannel _serviceChannel;

		public ApplicationHost(IServiceChannel serviceChannel)
		{
			_serviceChannel = serviceChannel;
		}

		public void Start()
		{
			var message = new CreateShelfService(
				"TopShelf.DirectoryMonitor",
				ShelfType.Internal,
				typeof(DirectoryMonitorBootstrapper));

			_serviceChannel.Send(message);
		}
	}
}
