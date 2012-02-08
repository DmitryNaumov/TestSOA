namespace TestSOA.ComponentModel
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Autofac;
	using Autofac.Builder;
	using Autofac.Core;
	using Autofac.Core.Lifetime;

	public static class RegistrationExtensions
	{
		public static void RegisterMatchingAssemblyTypes(this ContainerBuilder builder, Assembly assembly)
		{
			builder.RegisterCallback(componentRegistry => ScanAssembly(componentRegistry, assembly));
		}

		private static void ScanAssembly(IComponentRegistry componentRegistry, Assembly assembly)
		{
			var types = assembly.GetTypes()
				.Where(type => (type.IsClass && !type.IsAbstract) && (!type.IsGenericTypeDefinition && !type.IsSubclassOf(typeof(Delegate))))
				.ToArray();

			foreach (var type in types)
			{
				var implementedInterfaces = GetImplementedInterfaces(type);
				if (!implementedInterfaces.Any())
					continue;

				if (!HasMarkerAttribute(type))
				{
					var interfaceName = "I" + type.Name;
					if (implementedInterfaces.All(interfaceType => interfaceType.Name != interfaceName))
						continue;
				}

				var typedService = new TypedService(type);
				var data = new RegistrationData(typedService);

				data.AddServices(
					implementedInterfaces.Select(
						t =>
						{
							if (t.FullName == null)
							{
								return new TypedService(t.GetGenericTypeDefinition());
							}
							return new TypedService(t);
						}).ToArray());

				if (IsSingleInstancing(typedService.ServiceType))
				{
					data.Sharing = InstanceSharing.Shared;
					data.Lifetime = new RootScopeLifetime();
				}
				else if (IsInstancingPerLifetimeScope(typedService.ServiceType))
				{
					data.Sharing = InstanceSharing.Shared;
					data.Lifetime = new MatchingScopeLifetime(LifetimeScopeTags.RequestScope);
				}

				var registration = RegistrationBuilder.CreateRegistration(
					Guid.NewGuid(), data, new ConcreteReflectionActivatorData(typedService.ServiceType).Activator, data.Services);

				componentRegistry.Register(registration);
			}
		}

		private static Type[] GetImplementedInterfaces(Type type)
		{
			return type.GetInterfaces().Where(t => t != typeof(IDisposable)).ToArray();
		}

		private static bool HasMarkerAttribute(Type type)
		{
			var attr = (ComponentLifetimeAttribute)Attribute.GetCustomAttribute(type, typeof(ComponentLifetimeAttribute));
			return attr != null;
		}

		private static bool IsSingleInstancing(Type type)
		{
			var attr = (ComponentLifetimeAttribute)Attribute.GetCustomAttribute(type, typeof(ComponentLifetimeAttribute));
			return (attr != null) && (attr.LifetimeScope == ComponentLifetimeScope.SingleInstance);
		}

		private static bool IsInstancingPerLifetimeScope(Type type)
		{
			var attr = (ComponentLifetimeAttribute)Attribute.GetCustomAttribute(type, typeof(ComponentLifetimeAttribute));
			return (attr != null) && (attr.LifetimeScope == ComponentLifetimeScope.InstancePerLifetimeScope);
		}
	}
}
