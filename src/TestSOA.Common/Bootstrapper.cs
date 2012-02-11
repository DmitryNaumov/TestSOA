namespace TestSOA
{
	using System;
	using System.IO;
	using Autofac;
	using Autofac.Builder;
	using Autofac.Configuration;
	using log4net;
	using log4net.Config;

	internal static class Bootstrapper
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(Bootstrapper));

		public static void InitLogger()
		{
			var configurationFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config"));
			if (configurationFile.Exists)
			{
				XmlConfigurator.ConfigureAndWatch(configurationFile);
				Logger.DebugFormat("Logging configuration loaded: {0}", configurationFile.FullName);
			}
			else
			{
				// if we can't find the log4net configuration file, perform a basic configuration which at
				// least logs to trace/debug, which means we can attach a debugger to the process!
				BasicConfigurator.Configure();
			}
		}

		public static IContainer InitContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule<AutofacModule>();

			var configurationFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "autofac.config"));
			if (configurationFile.Exists)
			{
				builder.RegisterModule(new ConfigurationSettingsReader("autofac", configurationFile.FullName));
				Logger.DebugFormat("Container configuration loaded: {0}", configurationFile.FullName);
			}

			// use container.StartAll() when you are ready
			return builder.Build(ContainerBuildOptions.IgnoreStartableComponents);
		}
	}
}
