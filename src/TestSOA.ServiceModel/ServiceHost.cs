namespace TestSOA.ServiceModel
{
	using System.Collections.Generic;
	using Autofac;

	public sealed class ServiceHost
	{
		private readonly IEnumerable<IStartable> _startables;

		public ServiceHost(IEnumerable<IStartable> startables)
		{
			_startables = startables;
		}

		public void Start()
		{
			foreach (var startable in _startables)
			{
				startable.Start();
			}
		}
	}
}
