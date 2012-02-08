namespace TestSOA.ServiceModel
{
	using System;
	using Autofac;
	using NServiceBus;
	using TestSOA.Messaging;
	using IMessage = TestSOA.Messaging.IMessage;
	using ICommand = TestSOA.Messaging.ICommand;
	using IEvent = TestSOA.Messaging.IEvent;

	internal sealed class MessageBus : IMessageBus, IStartable, IDisposable
	{
		private readonly Configure _config;

		private volatile IStartableBus _startableBus;

		public MessageBus(ILifetimeScope rootScope)
		{
			_config = Configure.With()
				// configure infrastructure
				.Log4Net()
				.AutofacBuilder(rootScope)
				// configure message bus
				.DefiningMessagesAs(type => !type.IsAbstract && typeof(IMessage).IsAssignableFrom(type))
				.DefiningCommandsAs(type => !type.IsAbstract && typeof(ICommand).IsAssignableFrom(type))
				.DefiningEventsAs(type => !type.IsAbstract && typeof(IEvent).IsAssignableFrom(type))
				.DefineEndpointName(AppDomain.CurrentDomain.FriendlyName)
				.UnicastBus()
					.LoadMessageHandlers()
				// configure transport
				.XmlSerializer()
				.MsmqTransport();
		}

		public IBus Bus
		{
			get
			{
				EnsureStarted();
				return (IBus)_startableBus;
			}
		}

		public void Start()
		{
			EnsureStarted();
		}

		public void Dispose()
		{
			if (_startableBus != null)
			{
				_startableBus.Dispose();
				_startableBus = null;
			}
		}

		public void Send<T>(T request) where T : ICommand
		{
			Bus.SendLocal(request);
		}

		public void Reply<T>(T response) where T : IResponse
		{
			Bus.Reply(response);
		}

		public void Publish<T>(T @event) where T : IEvent
		{
			Bus.Publish(@event);
		}

		private void EnsureStarted()
		{
			if (_startableBus == null)
			{
				lock (this)
				{
					if (_startableBus == null)
					{
						var startableBus = _config.CreateBus();
						startableBus.Start();

						_startableBus = startableBus;
					}
				}
			}
		}
	}
}
