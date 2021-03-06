﻿namespace TestSOA.OrderManagement.Services
{
	using TestSOA.DomainModel;
	using TestSOA.Messaging;
	using TestSOA.OrderManagement.DataAccess;
	using TestSOA.OrderManagement.DomainModel;
	using TestSOA.OrderManagement.Messages;

	internal sealed class CommandHandlers : IHandleMessages<BookOrderRequest>, IHandleMessages<SubmitOrderRequest>
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IOrderFactory _orderFactory;

		public CommandHandlers(IOrderRepository orderRepository, IOrderFactory orderFactory)
		{
			_orderRepository = orderRepository;
			_orderFactory = orderFactory;
		}

		public void Handle(BookOrderRequest request)
		{
			var orderRef = new EntityRef<Order>(request.OrderId);
			var order = _orderRepository.Get(orderRef);
			order.Book(request.Note);
		}

		public void Handle(SubmitOrderRequest request)
		{
			var securityRef = new EntityRef<Security>(request.SecurityId);
			var order = _orderFactory.Create(securityRef);
			_orderRepository.Save(order);
		}
	}
}
