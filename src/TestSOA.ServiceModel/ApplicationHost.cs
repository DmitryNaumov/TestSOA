namespace TestSOA.ServiceModel
{
	using Topshelf.FileSystem;
	using Topshelf.Messages;
	using Topshelf.Model;

	internal sealed class ApplicationHost
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

		public void Stop()
		{
		}
	}
}
