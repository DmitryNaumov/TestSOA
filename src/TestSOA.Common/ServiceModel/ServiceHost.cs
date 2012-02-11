namespace TestSOA.ServiceModel
{
	using TestSOA.ComponentModel;
	using Topshelf.Model;

	[ComponentLifetime(ComponentLifetimeScope.SingleInstance)]
	internal sealed class ServiceHost : IServiceHost
	{
		private readonly IServiceChannel _serviceChannel;

		public ServiceHost(IServiceChannel serviceChannel)
		{
			_serviceChannel = serviceChannel;
		}

		public void Start()
		{
		}
	}
}
