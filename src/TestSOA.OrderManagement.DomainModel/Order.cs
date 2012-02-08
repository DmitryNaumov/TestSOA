namespace TestSOA.OrderManagement.DomainModel
{
	using TestSOA.DomainModel;
	using TestSOA.OrderManagement.Messages;

	public sealed class Order : AggregateRoot<Order>
	{
		public EntityRef<Security> SecurityRef { get; private set; }

		public OrderState State { get; private set; }

		public string BookNote { get; private set; }

		public void InitializeWithSecurity(EntityRef<Security> securityRef)
		{
			ApplyChange(new OrderSubmittedEvent());
		}

		public void Book(string note)
		{
			ApplyChange(new OrderBookedEvent());
		}

		private void Apply(OrderSubmittedEvent @event)
		{
		}

		private void Apply(OrderBookedEvent @event)
		{
		}
	}
}
