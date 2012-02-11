namespace TestSOA.Utilities
{
	using System.Collections.Generic;
	using Autofac;

	internal static class ContainerExtensions
	{
		public static void StartAll(this IComponentContext context)
		{
			foreach (var startable in context.Resolve<IEnumerable<IStartable>>())
			{
				startable.Start();
			}
		}
	}
}
