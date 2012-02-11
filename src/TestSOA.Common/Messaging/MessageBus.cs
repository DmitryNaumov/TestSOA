namespace TestSOA.Messaging
{
	using System;
	using MassTransit;
	using TestSOA.ComponentModel;

	[ComponentLifetime(ComponentLifetimeScope.SingleInstance)]
	internal sealed class MessageBus : IMessageBus
	{
		private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);

		private readonly IServiceBus _serviceBus;

		public MessageBus(IServiceBus serviceBus)
		{
			_serviceBus = serviceBus;
		}

		public void Send<TRequest>(TRequest request)
			where TRequest : Request
		{
			_serviceBus.PublishRequest(request, config =>
			{
				// one way request - response not expected
			});
		}

		public void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseCallback, Action timeoutCallback)
			where TRequest : Request
			where TResponse : Response
		{
			Send(request, responseCallback, timeoutCallback, DefaultTimeout);
		}

		public void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseCallback, Action timeoutCallback, TimeSpan timeout)
			where TRequest : Request
			where TResponse : Response
		{
			_serviceBus.PublishRequest(request, config =>
			{
				config.Handle(responseCallback);

				if (timeoutCallback != null)
				{
					config.HandleTimeout(timeout, timeoutCallback);
				}
			});
		}

		public void Reply<TResponse>(TResponse response) where TResponse : Response
		{
			_serviceBus.Context().Respond(response);
		}

		public void Publish<TEvent>(TEvent @event) where TEvent : Event
		{
			_serviceBus.Publish(@event);
		}
	}
}
