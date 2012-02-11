namespace TestSOA.Messaging
{
	using System;
	using TestSOA.Annotations;

	public interface IMessageBus
	{
		/// <summary>
		/// Sends one-way request message
		/// </summary>
		/// <typeparam name="TRequest">Request message type</typeparam>
		/// <param name="request">Request message</param>
		void Send<TRequest>([NotNull] TRequest request)
			where TRequest : Request;

		/// <summary>
		/// Sends request/response (RPC style) message
		/// </summary>
		/// <typeparam name="TRequest">Request message type</typeparam>
		/// <typeparam name="TResponse">Response message type</typeparam>
		/// <param name="request">Request message</param>
		/// <param name="responseCallback">Response handler</param>
		/// <param name="timeoutCallback">Timeout handler</param>
		void Send<TRequest, TResponse>([NotNull] TRequest request, [NotNull] Action<TResponse> responseCallback, Action timeoutCallback = null)
			where TRequest : Request
			where TResponse : Response;

		/// <summary>
		/// Sends request/response (RPC style) message
		/// </summary>
		/// <typeparam name="TRequest">Request message type</typeparam>
		/// <typeparam name="TResponse">Response message type</typeparam>
		/// <param name="request">Request message</param>
		/// <param name="responseCallback">Response handler</param>
		/// <param name="timeoutCallback">Timeout handler</param>
		/// <param name="timeout">Operation timeout</param>
		void Send<TRequest, TResponse>([NotNull] TRequest request, [NotNull] Action<TResponse> responseCallback, Action timeoutCallback, TimeSpan timeout)
			where TRequest : Request
			where TResponse : Response;

		/// <summary>
		/// Sends response back to caller
		/// </summary>
		/// <typeparam name="TResponse">Response message type</typeparam>
		/// <param name="response">Response message</param>
		void Reply<TResponse>([NotNull] TResponse response) where TResponse : Response;

		/// <summary>
		/// Broadcasts event message to all subscribers
		/// </summary>
		/// <typeparam name="TEvent">Event message type</typeparam>
		/// <param name="event">Event message</param>
		void Publish<TEvent>([NotNull] TEvent @event) where TEvent : Event;
	}
}
