﻿namespace TestSOA.OrderManagement.DataAccess
{
	using Autofac;
	using TestSOA.ComponentModel;

	internal sealed class AutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterMatchingAssemblyTypes(ThisAssembly);
		}
	}
}