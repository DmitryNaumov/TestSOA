namespace TestSOA.Messaging
{
	public interface IMessageBus
	{
		void Send<T>(T request) where T : ICommand;

		void Reply<T>(T response) where T : IResponse;

		void Publish<T>(T @event) where T : IEvent;
	}
}
