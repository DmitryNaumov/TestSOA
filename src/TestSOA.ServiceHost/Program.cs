namespace TestSOA.ServiceModel
{
	using System;

	internal sealed class Program
	{
		[LoaderOptimization(LoaderOptimization.MultiDomainHost)]
		private static void Main()
		{
			ApplicationBootstrapper.Run();
		}
	}
}
