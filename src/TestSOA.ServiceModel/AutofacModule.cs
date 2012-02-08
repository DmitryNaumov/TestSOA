namespace TestSOA.ServiceModel
{
	using Autofac;

	internal sealed class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<ApplicationHost>().AsSelf().SingleInstance();
			builder.RegisterType<ServiceHost>().AsSelf().SingleInstance();
			builder.RegisterType<MessageBus>().AsImplementedInterfaces().SingleInstance();
		}
	}
}
